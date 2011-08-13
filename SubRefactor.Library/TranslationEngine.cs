using System.IO;
using SubRefactor.Services;
using SubRefactor.Domain;
using SubRefactor.Library.Infrastructure;
namespace SubRefactor.Library
{
    public class TranslationEngine
    {
        protected string BingApiId = "038694F962E12E433B37594FC55A89BD5F12FDAF";
        protected string GoogleApiId = "AIzaSyBOfomKkck9IAImlFP_uG80a2HT9giUUno";

        public void Translate(Subtitle subtitle, Translators api, string fromLanguage, string toLanguage, string toEmail)
        {
            foreach (var quote in subtitle.Quotes)
                switch (api)
                {
                    case Translators.Bing:
                        quote.QuoteLine = new MicrosoftTranslatorProxy().Translate(BingApiId, quote.QuoteLine, fromLanguage, toLanguage, "text/html", "general");
                        break;
                    case Translators.Google:
                        quote.QuoteLine = new GoogleTranslatorService().Translate(quote.QuoteLine, fromLanguage, toLanguage);
                        break;
                }

            var stream = new SubtitleHandler().WriteSubtitle(subtitle.Quotes);

            const string message = "This is the subtitle that you translated";

            new Mail().SendMail("smtp.gmail.com", 587, "subrefactor@gmail.com", toEmail, "SubRefactor",
                message, stream, subtitle.Name);
        }
    }
}
