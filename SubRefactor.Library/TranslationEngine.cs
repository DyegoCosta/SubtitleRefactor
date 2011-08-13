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
        private readonly Subtitle _subtitle;
        private readonly Translators _api;
        private readonly string _fromLanguage;
        private readonly string _toLanguage;
        private readonly string _toEmail;

        public TranslationEngine(Subtitle subtitle, Translators api, string fromLanguage, string toLanguage, string toEmail)
        {
            _subtitle = subtitle;
            _api = api;
            _fromLanguage = fromLanguage;
            _toLanguage = toLanguage;
            _toEmail = toEmail;
        }

        public void Translate()
        {           
            foreach (var quote in _subtitle.Quotes)
                switch (_api)
                {
                    case Translators.Bing:
                        quote.QuoteLine = new MicrosoftTranslatorProxy().Translate(BingApiId, quote.QuoteLine, _fromLanguage, _toLanguage, "text/html", "general");
                        break;
                    case Translators.Google:
                        quote.QuoteLine = new GoogleTranslatorService().Translate(quote.QuoteLine, _fromLanguage, _toLanguage);
                        break;
                }

            var stream = new SubtitleHandler().WriteSubtitle(_subtitle.Quotes);

            const string message = "This is the subtitle that you translated";

            new Mail().SendMail("smtp.gmail.com", 587, "subrefactor@gmail.com", _toEmail, "SubRefactor",
                message, stream, _subtitle.Name);
        }
    }
}
