using System;
using System.ComponentModel.DataAnnotations;

namespace SanEximPortal.Models
{
    public class GroundTransportInfo:TransportInfo
    {
        [Display(Name ="Cmr No")]
        public string CmrNo { get; set; }
        [Display(Name ="Cmr Tarihi")]
        public DateTime? CmrDate { get; set; }
        [Display(Name ="Araç Plakası")]
        public string VehicleLicancePlate { get; set; }
        [Display(Name ="Açıklama")]
        public string Description { get; set; }


    }
}
