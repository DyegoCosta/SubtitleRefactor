using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace SubRefactor.Library.Languages
{
    public class ServicesLanguages
    {
        public IEnumerable GetBingLanguages()
        {
            var languages = new Dictionary<string, string>();

            languages.Add("Arabic", "ar");
            languages.Add("Czech", "ar");
            languages.Add("Danish", "ar");
            languages.Add("German", "ar");
            languages.Add("English", "ar");
            languages.Add("Estonian", "ar");
            languages.Add("Finnish", "ar");
            languages.Add("French", "ar");
            languages.Add("Dutch", "ar");
            languages.Add("Greek", "ar");
            languages.Add("Hebrew", "ar");
            languages.Add("Haitian Creole", "ar");
            languages.Add("Hungarian", "ar");
            languages.Add("Indonesian", "ar");
            languages.Add("Italian", "ar");
            languages.Add("Japanese", "ar");
            languages.Add("Korean", "ar");
            languages.Add("Lithuanian", "ar");
            languages.Add("Latvian", "ar");
            languages.Add("Norwegian", "ar");
            languages.Add("Polish", "ar");
            languages.Add("Portuguese", "ar");
            languages.Add("Romanian", "ar");
            languages.Add("Spanish", "ar");
            languages.Add("Russian", "ar");
            languages.Add("Slovak", "ar");
            languages.Add("Slovene", "ar");
            languages.Add("Swedish", "ar");
            languages.Add("Thai", "ar");
            languages.Add("Turkish", "ar");
            languages.Add("Ukrainian", "ar");
            languages.Add("Vietnamese", "ar");
            languages.Add("Simplified Chinese", "ar");
            languages.Add("Traditional Chinese", "ar");

            return languages.ToList();
        }

        public IEnumerable GetGoogleLanguages()
        {
            var languages = new Dictionary<string, string>();

            languages.Add("Afrikaans", "af");
            languages.Add("Albanian", "sq");
            languages.Add("Arabic", "ar");
            languages.Add("Belarusian", "be");
            languages.Add("Bulgarian", "bg");
            languages.Add("Catalan", "ca");
            languages.Add("Chinese Simplified", "zh-CN");
            languages.Add("Chinese Traditional", "zh-TW");
            languages.Add("Croatian", "hr");
            languages.Add("Czech", "cs");
            languages.Add("Danish", "da");
            languages.Add("Dutch", "nl");
            languages.Add("English", "en");
            languages.Add("Estonian", "et");
            languages.Add("Filipino", "tl");
            languages.Add("Finnish", "fi");
            languages.Add("French", "fr");
            languages.Add("Galician", "gl");
            languages.Add("German", "de");
            languages.Add("Greek", "el");
            languages.Add("Haitian Creole", "ht");
            languages.Add("Hebrew", "iw");
            languages.Add("Hindi", "hi");
            languages.Add("Hungarian", "hu");
            languages.Add("Icelandic", "is");
            languages.Add("Indonesian", "id");
            languages.Add("Irish", "ga");
            languages.Add("Italian", "it");
            languages.Add("Japanese", "ja");
            languages.Add("Latvian", "lv");
            languages.Add("Lithuanian", "lt");
            languages.Add("Macedonian", "mk");
            languages.Add("Malay", "ms");
            languages.Add("Maltese", "mt");
            languages.Add("Norwegian", "no");
            languages.Add("Persian", "fa");
            languages.Add("Polish", "pl");
            languages.Add("Portuguese", "pt");
            languages.Add("Romanian", "ro");
            languages.Add("Russian", "ru");
            languages.Add("Serbian", "sr");
            languages.Add("Slovak", "sk");
            languages.Add("Slovenian", "sl");
            languages.Add("Spanish", "es");
            languages.Add("Swahili", "sw");
            languages.Add("Swedish", "sv");
            languages.Add("Thai", "th");
            languages.Add("Turkish", "tr");
            languages.Add("Ukrainian", "uk");
            languages.Add("Vietnamese", "vi");
            languages.Add("Welsh", "cy");
            languages.Add("Yiddish", "yi");

            return languages.ToList();
        }
    }
}
