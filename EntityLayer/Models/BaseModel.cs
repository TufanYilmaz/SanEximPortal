using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityLayer.Models
{
    public  class BaseModel
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "Id")]
        public int Id { get; set; }
    }
}
