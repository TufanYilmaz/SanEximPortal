using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Models
{
    public class Agency : BaseModel
    {
        [Display(Name = "Acenta Ünvanı")]
        [JsonProperty(PropertyName = "AgencyTitle")]
        public string AgencyTitle { get; set; }
        [Display(Name = "Acenta Ek Bilgi")]
        [JsonProperty(PropertyName = "AgencyDescription")]
        public string AgencyDescription { get; set; }
        [Display(Name = "Acenta İlgili Kişi")]
        [JsonProperty(PropertyName = "AgencyRelevantPerson")]
        public string AgencyRelevantPerson { get; set; }
        [JsonProperty(PropertyName = "Phone")]
        [Display(Name = "Tel")]
        public string Phone { get; set; }
        [JsonProperty(PropertyName = "Fax")]
        [Display(Name = "Fax")]
        public string Fax { get; set; }
        [JsonProperty(PropertyName = "Email")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Hatalı E-Posta")]
        public string Email { get; set; }
    }
}
