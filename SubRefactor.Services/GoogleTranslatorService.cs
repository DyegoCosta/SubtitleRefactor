using Google.API.Translate;

namespace SubRefactor.Services
{
    public class GoogleTranslatorService
    {
        public string Translate(string text, string from, string to)
        {
            return new TranslateClient("http://localhost/").Translate(text, from, to);
        }
    }
}
