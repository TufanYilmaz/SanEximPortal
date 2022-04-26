using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityLayer.RequestModels
{
    public partial class SaneximGetExportRequest
    {
        [JsonProperty("GetExport")]
        public GetExport GetExport { get; set; }
    }

    public partial class GetExport
    {
        [JsonProperty("AgentNumber")]
        public string AgentNumber { get; set; }

        [JsonProperty("BeginDate")]
        public DateTimeOffset BeginDate { get; set; }

        [JsonProperty("EndDate")]
        public DateTimeOffset EndDate { get; set; }
    }
}
