using System;
using System.ComponentModel.DataAnnotations;

namespace Autoveod_MVC.Models
{
    public class Autovedu
    {
        public int Id { get; set; }
        [Required]
        public string Tellija { get; set; }
        [Required]
        public string Alguspunkt { get; set; }
        [Required]
        public string Lõpppunkt { get; set; }
        [Required]
        [Display(Name = "Kohale Joudmise Aeg")]
        public DateTime KohalejoudmiseAeg { get; set; }
        [Display(Name = "Auto Number")]
        public string AutoNr { get; set; }
        [Display(Name = "Juhi Eesnimi")]
        public string JuhtEesnimi { get; set; }
        [Display(Name = "Juhi Perenimi")]
        public string JuhtPerenimi { get; set; }
        public bool Valmis { get; set; }
    }
}
