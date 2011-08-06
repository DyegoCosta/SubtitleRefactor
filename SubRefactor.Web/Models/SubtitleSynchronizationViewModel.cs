using System.ComponentModel.DataAnnotations;
using SubRefactor.Domain;

namespace SubRefactor.Models
{
    public class SubtitleSynchronizationViewModel
    {
        public Subtitle Subtitle { get; set; }

        [Required]
        public int Delay { get; set; }
    }
}
