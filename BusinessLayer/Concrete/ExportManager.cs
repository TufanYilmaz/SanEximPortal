using BusinessLayer.Interfaces;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Repositories;
using EntityLayer.ResponseModels;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ExportManager : IExportService
    {
        IExportDal _exportDal;
        public ExportManager(IConfiguration config)
        {
            if (_exportDal == null)
            {
                _exportDal = new ExportRepository(config);
            }
        }
        public ExportManager(IExportDal exportDal)
        {
            _exportDal=exportDal;
        }
        public ExportManager(IConfiguration config,IExportDal exportDal)
        {
            _exportDal = exportDal;
        }

        public InvoiceInformation GetExport(string fileNumber)
        {
            return _exportDal.GetExport(fileNumber);
        }

        public IEnumerable<InvoiceInformation> GetExports(DateTime begindate, DateTime enddate, string agentNumber)
        {
            return _exportDal.GetExports(begindate, enddate, agentNumber);
        }

        public async Task<IEnumerable<InvoiceInformation>> GetExportsAsync(DateTime begindate, DateTime enddate, string agentNumber)
        {
            return await _exportDal.GetExportsAsync(begindate, enddate, agentNumber);
        }
    }
}
