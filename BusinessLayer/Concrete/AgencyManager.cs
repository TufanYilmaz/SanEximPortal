using BusinessLayer.Interfaces;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Repositories;
using EntityLayer.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Concrete
{
    public class AgencyManager : IAgencyService
    {
        IAgencyDal _agencyDal;
        public AgencyManager(IConfiguration config)
        {
            if (_agencyDal == null)
            {
                _agencyDal = new AgencyRepository(config);
            }
        }

        public AgencyManager(IConfiguration config, IAgencyDal agencyDal)
        {
            _agencyDal = agencyDal;
        }
        public AgencyManager(IAgencyDal agencyDal)
        {
            _agencyDal = agencyDal;
        }

        public int Add(Agency model)
        {
            return _agencyDal.Add(model);
        }

        public int AddOrUpdate(Agency model)
        {
            return _agencyDal.AddOrUpdate(model);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Agency Get(int id)
        {
            return _agencyDal.Get(id);
        }

        public IEnumerable<Agency> GetAll()
        {
            return _agencyDal.GetAll();
        }

        public int Update(Agency model)
        {
            var curr=Get(model.Id);
            return _agencyDal.Update(curr,model);
        }
    }
}
