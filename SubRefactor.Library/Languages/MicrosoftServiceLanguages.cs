using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace SubRefactor.Library.Languages
{
    public class MicrosoftServiceLanguages
    {
        public IEnumerable GetLanguages()
        {
            var languages = new Dictionary<string, string>();

            languages.Add("العربية", "ar");
            languages.Add("česky, čeština", "cs");
            languages.Add("Dansk", "da");
            languages.Add("Deutsch", "de");
            languages.Add("English", "en");
            languages.Add("Eesti, eesti keel", "et");
            languages.Add("Suomi, suomen kieli", "fi");
            languages.Add("Français", "fr");
            languages.Add("Nederlands, Vlaams", "nl");
            languages.Add("Ελληνικά", "el");
            languages.Add("עברית", "he");
            languages.Add("Kreyòl ayisyen", "ht");
            languages.Add("Magyar", "hu");
            languages.Add("Bahasa Indonesia", "id");
            languages.Add("Italiano", "it");
            languages.Add("日本語", "ja");
            languages.Add("한국어", "ko");
            languages.Add("Lietuvių kalba", "lt");
            languages.Add("Latviešu valoda", "lv");
            languages.Add("Norsk", "no");
            languages.Add("Polski", "pl");
            languages.Add("Português", "pt");
            languages.Add("Română", "ro");
            languages.Add("Español", "es");
            languages.Add("русский язык", "ru");
            languages.Add("Slovenčina", "sk");
            languages.Add("Slovenščina", "sl");
            languages.Add("Svenska", "sv");
            languages.Add("ไทย	", "th");
            languages.Add("Türkçe", "tr");
            languages.Add("Yкраїнська", "uk");
            languages.Add("Tiếng Việt", "vi");
            languages.Add("中文", "zh-CHS");
            languages.Add("Traditional Chinese", "zh-CHT");

            return languages.ToList();
        }
    }
}
