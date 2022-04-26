using DataAccessLayer.Interfaces;
using EntityLayer.ResponseModels;
using Microsoft.Extensions.Configuration;
using EximRestClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class ExportRepository : BaseRepo, IExportDal
    {
        public ExportRepository(IConfiguration config) : base(config)
        {
            username = config["SanEximParameters:Username"];
            password = config["SanEximParameters:Password"];

        }
        readonly string username;
        readonly string password;
        public async Task<IEnumerable<InvoiceInformation>> GetExportsAsync(DateTime begindate, DateTime enddate,string agentNumber)
        {
            Z_SD_SANEXIMRestClient client=new Z_SD_SANEXIMRestClient(username,password);
            var res = await client.GetExport(begindate, enddate, agentNumber);
            return res;
        }

        public  IEnumerable<InvoiceInformation> GetExports(DateTime begindate, DateTime enddate, string agentNumber)
        {
            return GetExportsAsync(begindate, enddate, agentNumber).Result;
        }

        public InvoiceInformation GetExport(string fileNumber)
        {
            throw new NotImplementedException();
        }
    }
}
