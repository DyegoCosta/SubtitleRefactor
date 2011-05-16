using SubRefactor.Services.Proxys;

namespace SubRefactor.Library
{
    public class TranslationEngine
    {
        protected string BingAppId = "038694F962E12E433B37594FC55A89BD5F12FDAF";

        public string Translate(Translators api, string text, string from, string to)
        {
            switch (api)
            {
                case Translators.Microsoft:
                    return new MicrosoftTranslatorService().Translate(BingAppId, text, from, to, "text/html", "general");

                default:
                    return "";
            }
        }
    }
}
