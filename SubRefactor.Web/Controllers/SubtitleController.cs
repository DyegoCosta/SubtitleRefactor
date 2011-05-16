using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;
using SubRefactor.Library;
using SubRefactor.Models;
using SubRefactor.Library.Languages;
using System.Collections;

namespace SubRefactor.Controllers
{
    public class SubtitleController : Controller
    {
        //
        // GET: /Subtitle/Synchronization

        [HttpGet]
        public ActionResult Synchronize()
        {
            return View();
        }

        //
        // POST: /Subtitle/Synchronization

        [HttpPost]
        public ActionResult Synchronize(SubtitleSynchronizationViewModel subtitleSynchronizationViewModel)
        {
            #region Validations

            if (subtitleSynchronizationViewModel.File == null)
                ModelState.AddModelError("File", "A file is required.");
            else
            {
                string extension = Path.GetExtension(subtitleSynchronizationViewModel.File.FileName);
                if (extension != ".srt")
                    ModelState.AddModelError("File", "The subtitle must be a .srt file");
            }

            if (subtitleSynchronizationViewModel.Delay == 0)
                ModelState.AddModelError("Delay", "Must not be 0.");

            if (!ModelState.IsValid)
                return View(subtitleSynchronizationViewModel);

            #endregion

            dynamic delay = subtitleSynchronizationViewModel.Delay;
            bool negativeDelay = ((int)(delay)).IsNegative();
            delay = TimeSpan.FromMilliseconds(delay);
            
            var synchronizedQuotes = 
                new SynchronizationEngine().SyncSubtitle(
                                                subtitleSynchronizationViewModel.File.InputStream,
                                                delay,
                                                negativeDelay
                                             );

            string newSubtitleName = string.Format("{0}_Synchronized_{1}_{2}_{3}{4}",
                                                    Path.GetFileNameWithoutExtension(subtitleSynchronizationViewModel.File.FileName),
                                                    negativeDelay ? "decreased" : "increased",
                                                    delay as string,
                                                    DateTime.Now.TimeOfDay.ToString().Replace(':', '-'),
                                                    Path.GetExtension(subtitleSynchronizationViewModel.File.FileName)
                                                  );

            new SubtitleHandler().WriteSubtitle(synchronizedQuotes, newSubtitleName);

            return View();
        }

        //
        // GET: /Subtitle/Translate

        [HttpGet]
        public ActionResult Translate()
        {
            #region ViewBags

            ViewBag.Languages = new ServicesLanguages().GetBingLanguages();
            ViewBag.Translators = new List<Translators>() { Translators.Bing, Translators.Google };

            #endregion

            return View();
        }

        //
        // POST: /Subtitle/Translate

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
            {
                string extension = Path.GetExtension(subtitleTranslationViewModel.File.FileName);
                if (extension != ".srt")
                    ModelState.AddModelError("File", "The subtitle must be a .srt file");
            }

            if (string.IsNullOrEmpty(subtitleTranslationViewModel.FromLanguage))
                ModelState.AddModelError("FromLanguage", "Select a language");

            if (string.IsNullOrEmpty(subtitleTranslationViewModel.ToLanguage))
                ModelState.AddModelError("ToLanguage", "Select a language");

            if (!ModelState.IsValid)
                return View(subtitleTranslationViewModel);

            #endregion

            var quotes = new SubtitleHandler().ReadSubtitle(subtitleTranslationViewModel.File.InputStream);

            foreach (var item in quotes)
                item.QuoteLine = new TranslationEngine().Translate(
                                                            subtitleTranslationViewModel.Translator,
                                                            item.QuoteLine,
                                                            subtitleTranslationViewModel.FromLanguage,
                                                            subtitleTranslationViewModel.ToLanguage
                                                         );

            string newSubtitleName = string.Format("{0}_Translated_{1}_{2}_{3}{4}",
                                                    Path.GetFileNameWithoutExtension(subtitleTranslationViewModel.File.FileName),
                                                    subtitleTranslationViewModel.FromLanguage,
                                                    subtitleTranslationViewModel.ToLanguage,
                                                    DateTime.Now.TimeOfDay.ToString().Replace(':', '-'),
                                                    Path.GetExtension(subtitleTranslationViewModel.File.FileName)
                                                  );

            new SubtitleHandler().WriteSubtitle(quotes, newSubtitleName);            

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
