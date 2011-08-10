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
        public ActionResult Synchronize(int milliseconds)
        {
            var subtitle = (Subtitle)Session["EditableSubtitle"];

            #region Validations

            if (milliseconds == 0)
                ModelState.AddModelError("millisseconds", "Must not be 0.");

            if (!ModelState.IsValid)
                return View("Synchronize");

            #endregion

            dynamic delay = milliseconds;
            delay = TimeSpan.FromMilliseconds(delay);

            IList<Quote> synchronizedQuotes;

            try
            {
                synchronizedQuotes = new SynchronizationEngine().SyncSubtitle(subtitle.Quotes, delay);
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError("Delay", ex.Message);
                return View("Synchronize");
            }

            subtitle.Quotes = synchronizedQuotes;

            Session["EditableSubtitle"] = subtitle;

            return View();            
        }        

        [HttpGet]
        public ActionResult Translate()
        {
            ViewBag.Languages = new ServicesLanguages().GetBingLanguages();
            ViewBag.Translators = new List<Translators>() { Translators.Bing, Translators.Google };

            return View("Translate");
        }

        [HttpPost]
        public ActionResult Translate(SubtitleTranslationViewModel subtitleTranslationViewModel, string email)
        {
            subtitleTranslationViewModel.Subtitle = (Subtitle)Session["EditableSubtitle"];

            #region Validations

            if (string.IsNullOrEmpty(subtitleTranslationViewModel.FromLanguage))
                ModelState.AddModelError("FromLanguage", "Select a language");

            if (string.IsNullOrEmpty(subtitleTranslationViewModel.ToLanguage))
                ModelState.AddModelError("ToLanguage", "Select a language");

            if (!ModelState.IsValid)
                return View(viewName: "Translate", model: subtitleTranslationViewModel);

            #endregion

            ViewBag.Languages = subtitleTranslationViewModel.Translator == Translators.Bing ?
                                                                            new ServicesLanguages().GetBingLanguages() :
                                                                            new ServicesLanguages().GetGoogleLanguages();
            ViewBag.Translators = new List<Translators>() { 
                                        Translators.Bing,
                                        Translators.Google
                                      };

            new TranslationEngine().Translate(subtitleTranslationViewModel.Subtitle, subtitleTranslationViewModel.Translator,
                                                subtitleTranslationViewModel.FromLanguage, subtitleTranslationViewModel.ToLanguage);

            return View();
        }

        [HttpGet]
        public ActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoadSubtitleToSession(HttpPostedFileBase file)
        {
            if (Path.GetExtension(file.FileName) != ".srt")
                return Redirect(Request.UrlReferrer.AbsoluteUri);

            var quotes = new SubtitleHandler().ReadSubtitle(file.InputStream);

            var subtitle = new Subtitle(quotes);
            subtitle.Name = Path.GetFileName((file.FileName));

            Session["OriginalSubtitle"] = subtitle;
            Session["EditableSubtitle"] = subtitle;

            return Redirect(Request.UrlReferrer.AbsoluteUri);
        }

        [HttpGet]
        public ActionResult Preview()
        {
            return View();
        }

        public ActionResult Download()
        {
            var subtitle = (Subtitle)Session["EditableSubtitle"];

            var stream = new SubtitleHandler().WriteSubtitle(subtitle.Quotes);

            return File(stream.GetBuffer(), "text/plain", subtitle.Name);
        }

        public ActionResult ClearSubtitleSession()
        {
            Session["OriginalSubtitle"] = null;

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
