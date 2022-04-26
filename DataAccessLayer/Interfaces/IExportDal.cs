using EntityLayer.ResponseModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IExportDal
    {
        Task<IEnumerable<InvoiceInformation>> GetExportsAsync(DateTime begindate, DateTime enddate,string agentNumber);
        IEnumerable<InvoiceInformation> GetExports(DateTime begindate, DateTime enddate, string agentNumber);
        InvoiceInformation GetExport(string fileNumber);

    }
}
