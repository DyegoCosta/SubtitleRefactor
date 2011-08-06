using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Mvc;
using SubRefactor.Domain;
using SubRefactor.Library;
using SubRefactor.Library.Languages;
using SubRefactor.Models;

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
            subtitleSynchronizationViewModel.Subtitle = (Subtitle)HttpContext.Session["EditableSubtitle"];

            #region Validations

            if (subtitleSynchronizationViewModel.Delay == 0)
                ModelState.AddModelError("Delay", "Must not be 0.");

            if (!ModelState.IsValid)
                return View("Synchronize", model: subtitleSynchronizationViewModel);

            #endregion

            dynamic delay = subtitleSynchronizationViewModel.Delay;
            delay = TimeSpan.FromMilliseconds(delay);
            
            IList<Quote> synchronizedQuotes;

            try
            {
                synchronizedQuotes = new SynchronizationEngine().SyncSubtitle(subtitleSynchronizationViewModel.Subtitle.Quotes, delay);
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError("Delay", ex.Message);
                return View("Synchronize", subtitleSynchronizationViewModel);
            }

            subtitleSynchronizationViewModel.Subtitle.Quotes = synchronizedQuotes;
            HttpContext.Session["EditableSubtitle"] = subtitleSynchronizationViewModel.Subtitle;

            var stream = new SubtitleHandler().WriteSubtitle(synchronizedQuotes);            

            return File(stream.GetBuffer(), "text/plain", subtitleSynchronizationViewModel.Subtitle.Name);
        }

        [HttpGet]
        public ActionResult Translate()
        {
            ViewBag.Languages = new ServicesLanguages().GetBingLanguages();
            ViewBag.Translators = new List<Translators>() { Translators.Bing, Translators.Google };

            return View("Translate");
        }

        [HttpPost]
        public ActionResult Translate(SubtitleTranslationViewModel subtitleTranslationViewModel)
        {
            subtitleTranslationViewModel.Subtitle = (Subtitle)HttpContext.Session["EditableSubtitle"];

            #region Validations

            if (string.IsNullOrEmpty(subtitleTranslationViewModel.FromLanguage))
                ModelState.AddModelError("FromLanguage", "Select a language");

            if (string.IsNullOrEmpty(subtitleTranslationViewModel.ToLanguage))
                ModelState.AddModelError("ToLanguage", "Select a language");

            if (!ModelState.IsValid)
                return View(viewName:"Translate", model: subtitleTranslationViewModel);

            #endregion

            ViewBag.Languages = subtitleTranslationViewModel.Translator == Translators.Bing ?
                                                                            new ServicesLanguages().GetBingLanguages() :
                                                                            new ServicesLanguages().GetGoogleLanguages();
            ViewBag.Translators = new List<Translators>() { 
                                        Translators.Bing,
                                        Translators.Google
                                      };
            
            foreach (var quote in subtitleTranslationViewModel.Subtitle.Quotes)
                quote.QuoteLine = new TranslationEngine().Translate(
                                                            subtitleTranslationViewModel.Translator,
                                                            quote.QuoteLine,
                                                            subtitleTranslationViewModel.FromLanguage,
                                                            subtitleTranslationViewModel.ToLanguage
                                                         );
            
            HttpContext.Session["EditableSubtitle"] = subtitleTranslationViewModel.Subtitle;

            var stream = new SubtitleHandler().WriteSubtitle(subtitleTranslationViewModel.Subtitle.Quotes);
            return File(stream.GetBuffer(), "text/plain", subtitleTranslationViewModel.Subtitle.Name);
        }

        [HttpGet]
        public ActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UploadSubtitleToSession(HttpPostedFileBase file)
        {
            if (Path.GetExtension(file.FileName) != ".srt")
                return Redirect(Request.UrlReferrer.AbsoluteUri);

            var quotes = new SubtitleHandler().ReadSubtitle(file.InputStream);

            var subtitle = new Subtitle(quotes);
            subtitle.Name = Path.GetFileName((file.FileName));

            HttpContext.Session["OriginalSubtitle"] = subtitle;
            HttpContext.Session["EditableSubtitle"] = subtitle;

            return Redirect(Request.UrlReferrer.AbsoluteUri);
        }

        public ActionResult ClearSubtitleSession()
        {
            HttpContext.Session["OriginalSubtitle"] = null;

            return Redirect(Request.UrlReferrer.AbsoluteUri);
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
