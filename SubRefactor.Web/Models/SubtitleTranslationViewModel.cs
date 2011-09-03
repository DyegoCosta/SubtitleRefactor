using System.ComponentModel.DataAnnotations;
using SubRefactor.Domain;
using SubRefactor.Library;

namespace SubRefactor.Models
{
    public class SubtitleTranslationViewModel
    {
        [Required]
        public Translators Translator { get; set; }

        [Required]
        public string FromLanguage { get; set; }
        
        [Required]
        public string ToLanguage { get; set; }
    }
}