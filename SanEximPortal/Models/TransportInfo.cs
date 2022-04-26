using EntityLayer.Models;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace SanEximPortal.Models
{
    public class TransportInfo
    {
        [Display(Name = "İhracat Numarası")]
        [JsonProperty("FileNumber")]
        public string FileNumber { get; set; }
        [Display(Name = "Sevk Tarihi")]
        public DateTime? ConsignmentDate { get; set; }
        [Display(Name = "Tahmini Varış Tarihi")]
        public DateTime? EstimatedArrivalDate { get; set; }
        [Display(Name = "Gerçekleşen Tarihi")]
        public DateTime? ActualDate { get; set; }
        [Display(Name = "Çıkış Gümrüğü")]
        public string ExitCustoms { get; set; }
        [Display(Name = "GÇB NO")]
        public string CustomsExitDeclaration { get; set; }
        [Display(Name = "Gümrük Tescil No")]
        public string CustomsRegistrationNumber { get; set; }
        [Display(Name = "Nereden")]
        public string From { get; set; }
        [Display(Name = "Nereye")]
        public string To { get; set; }
        public Agency Agent { get; set; } = new Agency();


    }
}
