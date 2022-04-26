using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EntityLayer.Models
{
    public enum Role
    {
        //[Display]
        user = 0,
        //[Display]
        admin = 1,
    }
    public class User:BaseModel
    {
        [Display(Name="E-Posta"),Required(ErrorMessage ="Kullanıcı adı (Email) Zorunludur")]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "Email")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Hatalı E-Posta")]
        public string Email { get; set; }
        [Display(Name="Firma Ünvanı")]
        [JsonProperty(PropertyName = "FirmTitle")]
        public string FirmTitle { get; set; }
        [Display(Name = "Vergi Numarası")]
        [StringLength(11, ErrorMessage = "Vergi Kimlik Numarası 10 veya 11 karakter olmalıdır", MinimumLength = 10)]
        [JsonProperty(PropertyName = "VKN")]
        public string VKN { get; set; }
        [Display(Name="Alıcılar E-Posta")]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "DocumentReceivers")]
        public string DocumentReceivers { get; set; }
        [Display(Name="Sap Lojistik Id")]
        [JsonProperty(PropertyName = "SAPLogisticId")]
        public int? SAPLogisticId { get; set; }
        [Display(Name="Parola"), Required(ErrorMessage = "Parola Zorunludur")]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name="Rol"),Required(ErrorMessage ="Bu alan Gereklidir")]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "Role")]
        public string Role { get; set; }
        [Display(Name="Oluşturulma Tarihi")]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "CreatedDate")]
        public DateTime CreatedDate { get; set; }
    }
}
