using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Google.API.Translate;
using Newtonsoft.Json;

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
