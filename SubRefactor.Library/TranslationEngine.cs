using SubRefactor.Services;
using SubRefactor.Domain;
using SubRefactor.Library.Infrastructure;
namespace SubRefactor.Library
{
    public class TranslationEngine
    {
        protected string BingApiId = "038694F962E12E433B37594FC55A89BD5F12FDAF";
        protected string GoogleApiId = "AIzaSyBOfomKkck9IAImlFP_uG80a2HT9giUUno";

        public void Translate(Subtitle subtitle, Translators api, string from, string to)
        {
            foreach (var quote in subtitle.Quotes)
                switch (api)
                {
                    case Translators.Bing:
                        quote.QuoteLine = new MicrosoftTranslatorProxy().Translate(BingApiId, quote.QuoteLine, from, to, "text/html", "general");
                        break;
                    case Translators.Google:
                        quote.QuoteLine = new GoogleTranslatorService().Translate(quote.QuoteLine, from, to);
                        break;
                }

            var stream = new SubtitleHandler().WriteSubtitle(subtitle.Quotes);       
     
            new Mail().SendMail("smtp.google.com", "dyego.costa@live.com", "dyego.costa@live.com", "SubRefactor",
                "This is your translated subtitle", stream, "subtitle.srt");
        }
    }
}
