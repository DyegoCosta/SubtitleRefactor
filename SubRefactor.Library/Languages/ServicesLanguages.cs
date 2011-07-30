using System.Collections.Generic;
using System.Linq;
using System.Collections;

namespace SubRefactor.Library.Languages
{
    public class ServicesLanguages
    {
        public IList GetBingLanguages()
        {
            var languages = new Dictionary<string, string>
                                {
                                    {"Arabic", "ar"},
                                    {"Czech", "ar"},
                                    {"Danish", "ar"},
                                    {"German", "ar"},
                                    {"English", "ar"},
                                    {"Estonian", "ar"},
                                    {"Finnish", "ar"},
                                    {"French", "ar"},
                                    {"Dutch", "ar"},
                                    {"Greek", "ar"},
                                    {"Hebrew", "ar"},
                                    {"Haitian Creole", "ar"},
                                    {"Hungarian", "ar"},
                                    {"Indonesian", "ar"},
                                    {"Italian", "ar"},
                                    {"Japanese", "ar"},
                                    {"Korean", "ar"},
                                    {"Lithuanian", "ar"},
                                    {"Latvian", "ar"},
                                    {"Norwegian", "ar"},
                                    {"Polish", "ar"},
                                    {"Portuguese", "ar"},
                                    {"Romanian", "ar"},
                                    {"Spanish", "ar"},
                                    {"Russian", "ar"},
                                    {"Slovak", "ar"},
                                    {"Slovene", "ar"},
                                    {"Swedish", "ar"},
                                    {"Thai", "ar"},
                                    {"Turkish", "ar"},
                                    {"Ukrainian", "ar"},
                                    {"Vietnamese", "ar"},
                                    {"Simplified Chinese", "ar"},
                                    {"Traditional Chinese", "ar"}
                                };

            return languages.ToList();
        }

        public IList GetGoogleLanguages()
        {
            var languages = new Dictionary<string, string>
                                {
                                    {"Afrikaans", "af"},
                                    {"Albanian", "sq"},
                                    {"Arabic", "ar"},
                                    {"Belarusian", "be"},
                                    {"Bulgarian", "bg"},
                                    {"Catalan", "ca"},
                                    {"Chinese Simplified", "zh-CN"},
                                    {"Chinese Traditional", "zh-TW"},
                                    {"Croatian", "hr"},
                                    {"Czech", "cs"},
                                    {"Danish", "da"},
                                    {"Dutch", "nl"},
                                    {"English", "en"},
                                    {"Estonian", "et"},
                                    {"Filipino", "tl"},
                                    {"Finnish", "fi"},
                                    {"French", "fr"},
                                    {"Galician", "gl"},
                                    {"German", "de"},
                                    {"Greek", "el"},
                                    {"Haitian Creole", "ht"},
                                    {"Hebrew", "iw"},
                                    {"Hindi", "hi"},
                                    {"Hungarian", "hu"},
                                    {"Icelandic", "is"},
                                    {"Indonesian", "id"},
                                    {"Irish", "ga"},
                                    {"Italian", "it"},
                                    {"Japanese", "ja"},
                                    {"Latvian", "lv"},
                                    {"Lithuanian", "lt"},
                                    {"Macedonian", "mk"},
                                    {"Malay", "ms"},
                                    {"Maltese", "mt"},
                                    {"Norwegian", "no"},
                                    {"Persian", "fa"},
                                    {"Polish", "pl"},
                                    {"Portuguese", "pt"},
                                    {"Romanian", "ro"},
                                    {"Russian", "ru"},
                                    {"Serbian", "sr"},
                                    {"Slovak", "sk"},
                                    {"Slovenian", "sl"},
                                    {"Spanish", "es"},
                                    {"Swahili", "sw"},
                                    {"Swedish", "sv"},
                                    {"Thai", "th"},
                                    {"Turkish", "tr"},
                                    {"Ukrainian", "uk"},
                                    {"Vietnamese", "vi"},
                                    {"Welsh", "cy"},
                                    {"Yiddish", "yi"}
                                };

            return languages.ToList();
        }
    }
}
