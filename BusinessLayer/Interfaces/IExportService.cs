using EntityLayer.ResponseModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface IExportService
    {
        Task<IEnumerable<InvoiceInformation>> GetExportsAsync(DateTime begindate, DateTime enddate, string agentNumber);
        IEnumerable<InvoiceInformation> GetExports(DateTime begindate, DateTime enddate, string agentNumber);
        InvoiceInformation GetExport(string fileNumber);
    }
}
