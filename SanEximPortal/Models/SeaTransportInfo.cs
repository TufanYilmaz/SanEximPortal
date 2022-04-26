using System;
using System.ComponentModel.DataAnnotations;

namespace SanEximPortal.Models
{
    public class SeaTransportInfo:TransportInfo
    {
        [Display(Name ="Aktarma Limanı Kalkış Tarihi")]
        public DateTime? TransferPortDepartureDate { get; set; }
        [Display(Name ="Aktarma Limanı Varış Tarihi")]
        public DateTime? TransferPortArrivalDate { get; set; }
        [Display(Name ="Yük Gümrükten Çıkış Tarihi")]
        public DateTime? GoodsExportExitDate { get; set; }
        [Display(Name ="Varış Limanı")]
        public string ArrivalPort { get; set; }
        [Display(Name ="Aktarma Limanı")]
        public string TransferPort { get; set; }
        [Display(Name ="Gemi Adı")]
        public string ShipName { get; set; }
        [Display(Name ="İnşa Tarihi")]
        public DateTime? ConstructionDate { get; set; }
        [Display(Name ="Bayrağı")]
        public string Flag { get; set; }
        [Display(Name ="imo No")]
        public string ImoNo { get; set; }
        [Display(Name ="Acenta")]
        public string Agency { get; set; }
        [Display(Name = "Sigorta Oranı")]
        public double InsuranceRate { get; set; }
        [Display(Name = "Yükleme Durumu")]
        public bool IsDelivered { get; set; }

    }
}
