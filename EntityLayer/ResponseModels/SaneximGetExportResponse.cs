using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EntityLayer.ResponseModels
{
    public partial class SaneximGetExportResponse
    {
        [JsonProperty("InvoiceInformation")]
        public InvoiceInformation[] InvoiceInformation { get; set; }
    }

    public partial class InvoiceInformation
    {
        [JsonProperty("InvoiceSerial"),Display(Name="Fatura Seri")]
        public string InvoiceSerial { get; set; }

        [JsonProperty("IncoiceNumber")]
        [Display(Name="Fatura No")]
        public string IncoiceNumber { get; set; }

        [JsonProperty("ExchangeCenter")]
        [Display(Name ="Kambiyo Merkezi")]
        public string ExchangeCenter { get; set; }

        [Display(Name ="Kambiyo Kodu")]
        [JsonProperty("Exchange")]
        public string Exchange { get; set; }

        [Display(Name ="Müşteri Numarası")]
        [JsonProperty("CustomerNumber")]
        public string CustomerNumber { get; set; }

        [Display(Name ="Müşteri Adı")]
        [JsonProperty("Name")]
        public string Name { get; set; }

        [Display(Name ="İhracat Numarası")]
        [JsonProperty("FileNumber")]
        public string FileNumber { get; set; }

        [Display(Name ="Agent Number")]
        [JsonProperty("AgentNumber")]
        public string AgentNumber { get; set; }

        [Display(Name ="Nakliyeci Adı")]
        [JsonProperty("OrganizationName")]
        public string OrganizationName { get; set; }

        [Display(Name ="Taşıma Tipi")]
        [JsonProperty("ShippingType")]
        public string ShippingType { get; set; }//Hava - Kara - Deniz

        [Display(Name ="Taşıma Şekli")]
        [JsonProperty("ShippingTypeDescription")]
        public string ShippingTypeDescription { get; set; }

        [Display(Name ="Ülke Kodu")]
        [JsonProperty("CountryKey")]
        public string CountryKey { get; set; }

        [Display(Name ="Ülke Adı")]
        [JsonProperty("CountryName")]
        public string CountryName { get; set; }
    }
}
