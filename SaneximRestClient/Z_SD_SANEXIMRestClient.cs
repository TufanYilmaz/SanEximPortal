using RestSharp;
using SaneximRestClient.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Deserializer = Newtonsoft.Json.JsonConvert;
using EntityLayer.RequestModels;
using EntityLayer.ResponseModels;

namespace SaneximRestClient
{
    public class Z_SD_SANEXIMRestClient
    {
        string BASE_URL { get; set; } = @"https://s4npoq.sanko.com.tr:44300";
        readonly string USERNAME = "ENT_SANEXIM";
        readonly string PASSWORD = "8vzMgdAnJH";
        public readonly JsonSerializerSettings serializerSettings = new JsonSerializerSettings()  { DateFormatString = "yyyy-MM-dd" };
        public Z_SD_SANEXIMRestClient(string username,string password)
        {
            USERNAME = username;
            PASSWORD = password;
        }
        public async Task<IEnumerable<InvoiceInformation>> GetExport(DateTime beginDate,DateTime endDate,string agentNumber)
        {
            var listResult = new List<InvoiceInformation>();
            var restClient = new RestClient(BASE_URL);
            var request = new RestRequest(SaneximMethods.Z_SD_SANEXIM_GET_EXPORT,Method.POST);
            var requestObject = new SaneximGetExportRequest()
            {
                GetExport=new GetExport()
                {
                    AgentNumber=agentNumber,
                    BeginDate=beginDate,
                    EndDate=endDate,
                }
            };
            
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", RestsharpHelper.GetBasicAuthBase64String(USERNAME, PASSWORD));
            request.AddJsonBody(JsonConvert.SerializeObject(requestObject, serializerSettings));

            try
            {
                var response = await restClient.ExecuteAsync(request);
                var res = Deserializer.DeserializeObject<SaneximGetExportResponse>(response.Content);
                listResult = res.InvoiceInformation.ToList();
                 
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return listResult;
            //return null;
        }
        //public async Task<IRestResponse<T>> ExecuteRequestAsync<T>(RestClient client, IRestRequest request) where T: class
        //{
        //    var taskCom = new TaskCompletionSource<IRestResponse<T>>();
        //    await client.ExecuteAsync<T>(request, response =>
        //    {
        //        if (response.ErrorException != null)
        //        {
        //            throw new ApplicationException("bir hata oluştu:\n", response.ErrorException);
        //        }
        //        taskCom.SetResult(response);
        //    },null);
        //    return await taskCom.Task;
        //}
    }
}