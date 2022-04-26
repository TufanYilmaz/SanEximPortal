using System;
using System.ComponentModel.DataAnnotations;

namespace SanEximPortal.Models
{
    public class TransportGeneralModel : EntityLayer.ResponseModels.InvoiceInformation
    {
        [Display(Name = "Uçuş No",Description ="Air")]
        public string FlightNumber { get; set; }
        [Display(Name = "Hava Yolu Şirketi", Description = "Air")]
        public string AirlineCompany { get; set; }


        [Display(Name = "Cmr No", Description = "Ground")]
        public string CmrNo { get; set; }
        [Display(Name = "Cmr Tarihi", Description = "Ground")]
        public DateTime CmrDate { get; set; }
        [Display(Name = "Araç Plakası", Description = "Ground")]
        public string VehicleLicancePlate { get; set; }
        [Display(Name = "Açıklama", Description = "Ground")]
        public string Description { get; set; }


        [Display(Name = "Aktarma Limanı Kalkış Tarihi", Description = "Sea")]
        public DateTime TransferPortDepartureDate { get; set; }
        [Display(Name = "Aktarma Limanı Varış Tarihi", Description = "Sea")]
        public DateTime TransferPortArrivalDate { get; set; }
        [Display(Name = "Yük Gümrükten Çıkış Tarihi", Description = "Sea")]
        public DateTime GoodsExportExitDate { get; set; }
        [Display(Name = "Varış Limanı", Description = "Sea")]
        public string ArrivalPort { get; set; }
        [Display(Name = "Aktarma Limanı", Description = "Sea")]
        public string TransferPort { get; set; }
        [Display(Name = "Gemi Adı")]
        public string ShipName { get; set; }
        [Display(Name = "İnşa Tarihi")]
        public DateTime ConstructionDate { get; set; }
        [Display(Name = "Bayrağı")]
        public string Flag { get; set; }
        [Display(Name = "imo No")]
        public string ImoNo { get; set; }
        [Display(Name = "Acenta")]
        public string Agency { get; set; }
        [Display(Name = "Sigorta Oranı")]
        public double InsuranceRate { get; set; }
        [Display(Name = "Yükleme Durumu")]
        public bool IsDelivered { get; set; }
    }
}
