using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Mvc;
using SubRefactor.Domain;
using SubRefactor.Library;
using SubRefactor.Models;
using System.Threading;

namespace SubRefactor.Controllers
{
    public class SubtitleController : Controller
    {
        private Subtitle _subtitle;

        [HttpGet]
        public ActionResult Synchronize()
        {
            return View("Synchronize");
        }

        [HttpPost]
        public ActionResult Synchronize(int milliseconds)
        {
            _subtitle = (Subtitle)Session["EditableSubtitle"];

            var cloneSubtitle = _subtitle.Clone();

            #region Validations

            if (milliseconds == 0)
                ModelState.AddModelError("millisseconds", "Must not be 0.");

            if (!ModelState.IsValid)
                return View("Synchronize");

            #endregion

            dynamic delay = milliseconds;
            delay = TimeSpan.FromMilliseconds(delay);            

            try
            {
                cloneSubtitle.Quotes = new SynchronizationEngine().SyncSubtitle(cloneSubtitle.Quotes, delay);
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError("Delay", ex.Message);
                return View("Synchronize");
            }

            Session["EditableSubtitle"] = cloneSubtitle;

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
            _subtitle = (Subtitle)Session["EditableSubtitle"];            

            ViewBag.Languages = subtitleTranslationViewModel.Translator == Translators.Bing ?
                                                                            new ServicesLanguages().GetBingLanguages() :
                                                                            new ServicesLanguages().GetGoogleLanguages();
            ViewBag.Translators = new List<Translators>() { 
                                        Translators.Bing,
                                        Translators.Google
                                      };

            #region Validations

            if (string.IsNullOrEmpty(subtitleTranslationViewModel.FromLanguage))
                ModelState.AddModelError("FromLanguage", "Select a language");

            if (string.IsNullOrEmpty(subtitleTranslationViewModel.ToLanguage))
                ModelState.AddModelError("ToLanguage", "Select a language");

            if (!ModelState.IsValid)
                return View("Translate", subtitleTranslationViewModel);

            #endregion
            
            var translationEngine = new TranslationEngine((Subtitle)_subtitle.Clone(), subtitleTranslationViewModel.Translator,
                                                subtitleTranslationViewModel.FromLanguage, subtitleTranslationViewModel.ToLanguage, email);

            var thread = new Thread(new ThreadStart(translationEngine.Translate));
            thread.Start();

            return View("Translate");
        }

        [HttpGet]
        public ActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(FormCollection form)
        {
            _subtitle = (Subtitle)Session["EditableSubtitle"];

            for (var i = 0; i < form.Count; i++)
                _subtitle.Quotes[i].QuoteLine = form[i];

            Session["EditableSubtitle"] = _subtitle;

            return View();
        }

        [HttpPost]
        public ActionResult LoadSubtitleToSession(HttpPostedFileBase file)
        {
            if (file == null || Path.GetExtension(file.FileName) != ".srt")
                if (Request.UrlReferrer != null)
                    return Redirect(Request.UrlReferrer.AbsoluteUri);
                else
                    return RedirectToAction("Index", "Home");

            var quotes = new SubtitleHandler().ReadSubtitle(file.InputStream);

            _subtitle = new Subtitle(quotes) { Name = Path.GetFileName((file.FileName)) };

            Session["OriginalSubtitle"] = _subtitle;
            Session["EditableSubtitle"] = _subtitle.Clone();

            if (Request.UrlReferrer != null)
                return Redirect(Request.UrlReferrer.AbsoluteUri);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Preview()
        {
            return View("Preview");
        }

        public ActionResult Download()
        {
            _subtitle = (Subtitle)Session["EditableSubtitle"];

            var stream = new SubtitleHandler().WriteSubtitle(_subtitle.Quotes);

            return File(stream.GetBuffer(), "text/plain", _subtitle.Name);
        }

        public ActionResult ClearSubtitleSession()
        {
            Session["OriginalSubtitle"] = null;
            Session["EditableSubtitle"] = null;

            if (Request.UrlReferrer != null)
                return Redirect(Request.UrlReferrer.AbsoluteUri);

            return RedirectToAction("Index", "Home");
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
