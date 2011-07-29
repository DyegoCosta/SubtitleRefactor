using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;
using SubRefactor.Library;
using SubRefactor.Models;
using SubRefactor.Library.Languages;
using System.Collections;
using SubRefactor.Domain;

namespace SubRefactor.Controllers
{
    public class SubtitleController : Controller
    {
        [HttpGet]
        public ActionResult Synchronize()
        {
            return View("Synchronize");
        }

        [HttpPost]
        public ActionResult Synchronize(SubtitleSynchronizationViewModel subtitleSynchronizationViewModel)
        {
            #region Validations

            if (subtitleSynchronizationViewModel != null && subtitleSynchronizationViewModel.File == null)
                ModelState.AddModelError("File", "A file is required.");
            else
            {
                if (subtitleSynchronizationViewModel != null)
                {
                    string extension = Path.GetExtension(subtitleSynchronizationViewModel.File.FileName);
                    if (extension != ".srt")
                        ModelState.AddModelError("File", "The subtitle must be a .srt file");
                }
            }

            if (subtitleSynchronizationViewModel != null && subtitleSynchronizationViewModel.Delay == 0)
                ModelState.AddModelError("Delay", "Must not be 0.");

            if (!ModelState.IsValid)
                return View("Synchronize", model: subtitleSynchronizationViewModel);

            #endregion

            dynamic delay = subtitleSynchronizationViewModel.Delay;
            delay = TimeSpan.FromMilliseconds(delay);

            var quotes = new SubtitleHandler().ReadSubtitle(subtitleSynchronizationViewModel.File.InputStream);
            IList<Quote> synchronizedQuotes;

            try
            {
                synchronizedQuotes = new SynchronizationEngine().SyncSubtitle(quotes, delay);
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError("Delay", ex.Message);
                return View(subtitleSynchronizationViewModel);
            }

            var stream = new SubtitleHandler().WriteSubtitle(synchronizedQuotes);

            return this.File(stream.GetBuffer(), "text/plain", subtitleSynchronizationViewModel.File.FileName);
        }

        [HttpGet]
        public ActionResult Translate()
        {
            #region ViewBags

            ViewBag.Languages = new ServicesLanguages().GetBingLanguages();
            ViewBag.Translators = new List<Translators>() { Translators.Bing, Translators.Google };

            #endregion

            return View("Translate");
        }

        [HttpPost]
        public ActionResult Translate(SubtitleTranslationViewModel subtitleTranslationViewModel)
        {
            #region ViewBags

            ViewBag.Languages = subtitleTranslationViewModel.Translator == Translators.Bing ?
                                                                            new ServicesLanguages().GetBingLanguages() :
                                                                            new ServicesLanguages().GetGoogleLanguages();
            ViewBag.Translators = new List<Translators>() { 
                                        Translators.Bing,
                                        Translators.Google
                                      };

            #endregion

            #region Validations

            if (subtitleTranslationViewModel.File == null)
                ModelState.AddModelError("File", "A file is required.");
            else
                if (Path.GetExtension(subtitleTranslationViewModel.File.FileName) != ".srt")
                    ModelState.AddModelError("File", "The subtitle must be a .srt file");

            if (string.IsNullOrEmpty(subtitleTranslationViewModel.FromLanguage))
                ModelState.AddModelError("FromLanguage", "Select a language");

            if (string.IsNullOrEmpty(subtitleTranslationViewModel.ToLanguage))
                ModelState.AddModelError("ToLanguage", "Select a language");

            if (!ModelState.IsValid)
                return View(viewName:"Translate", model: subtitleTranslationViewModel);

            #endregion

            var quotes = new SubtitleHandler().ReadSubtitle(subtitleTranslationViewModel.File.InputStream);

            foreach (var quote in quotes)
                quote.QuoteLine = new TranslationEngine().Translate(
                                                            subtitleTranslationViewModel.Translator,
                                                            quote.QuoteLine,
                                                            subtitleTranslationViewModel.FromLanguage,
                                                            subtitleTranslationViewModel.ToLanguage
                                                         );

            var stream = new SubtitleHandler().WriteSubtitle(quotes);
            return File(stream.GetBuffer(), "text/plain", subtitleTranslationViewModel.File.FileName);
        }

        [HttpGet]
        public ActionResult Edit()
        {
            return View();
        }

        #region Ajax

        [OutputCache(Duration = 0, VaryByParam = "None")]
        public ActionResult ListLanguagesByTranslator(string id)
        {
            IEnumerable languages = new Dictionary<string, string>();

            if (id == "Bing")
                languages = new ServicesLanguages().GetBingLanguages();
            if (id == "Google")
                languages = new ServicesLanguages().GetGoogleLanguages();

            return Json(languages, JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}
