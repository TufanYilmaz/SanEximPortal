using System;
using System.ComponentModel.DataAnnotations;

namespace SanEximPortal.ViewModels
{
    public class TransportSelectionViewModel
    {
        [Display(Name = "Yetkili Firma")]
        public string AgentName { get; set; } = "CEO";
        [Display(Name ="Başlangıç Tarihi")]
        public DateTime BeginDate { get; set; } = DateTime.UtcNow;
        [Display(Name ="Bitiş Tarihi")]
        public DateTime EndDate { get; set; } = DateTime.UtcNow;
    }
}
