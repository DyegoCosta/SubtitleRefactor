using SubRefactor.Services;
namespace SubRefactor.Library
{
    public class TranslationEngine
    {
        protected string BingApiId = "038694F962E12E433B37594FC55A89BD5F12FDAF";
        protected string GoogleApiId = "AIzaSyBOfomKkck9IAImlFP_uG80a2HT9giUUno";

        public string Translate(Translators api, string text, string from, string to)
        {
            switch (api)
            {
                case Translators.Bing:
                    return new MicrosoftTranslatorService().Translate(BingApiId, text, from, to, "text/html", "general");
                    
                case Translators.Google:
                    return new GoogleTranslatorService().Translate(text, from, to);
                    
                default:
                    return "";
            }
        }
    }
}
