using System.ComponentModel.DataAnnotations;

namespace SanEximPortal.Models
{
    public class AirTransportInfo:TransportInfo
    {
        [Display(Name = "Uçuş No")]
        public string FlightNumber { get; set; }
        [Display(Name = "Hava Yolu Şirketi")]
        public string AirlineCompany { get; set; }

    }
}
