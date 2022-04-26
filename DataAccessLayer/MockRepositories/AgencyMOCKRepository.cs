using DataAccessLayer.Interfaces;
using EntityLayer.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer.Repositories
{
    public class AgencyMOCKRepository : BaseRepo, IAgencyDal
    {
        public AgencyMOCKRepository(IConfiguration config) : base(config)
        {
        }

        static List<Agency> agents = new List<Agency>() 
        {
            new Agency()
            {
                Id = 1,
                AgencyDescription ="Acenta 1",
                AgencyRelevantPerson ="Acenta 1 ilgili kişi",
                AgencyTitle ="Acenta Başlangıç",
                Email = "acenta1@acenta.com",
                Fax ="555 55 550",
                Phone="555 55 55",
                
            },
            new Agency()
            {
                Id=2,
                 AgencyDescription ="Acenta 2",
                AgencyRelevantPerson ="Acenta 2 ilgili kişi",
                AgencyTitle ="Acenta ABC",
                Email = "acenta2@acenta.com",
                Fax ="544 44 440",
                Phone="544 44 44",
            }
        };

        public int Add(Agency model)
        {
            model.Id = agents.Max(m => m.Id);
            agents.Add(model);
            return model.Id;
        }

        public int AddOrUpdate(Agency model)
        {
            if (model.Id > 0)
            {
                var curr=Get(model.Id);
                 return Update(curr,model);
            }
            else
            {
                return Add(model);
            }
        }

        public Agency Get(int id)
        {
            return agents.First(a => a.Id == id);
        }

        public IEnumerable<Agency> GetAll()
        {
            return agents;
        }

        public int Update(Agency current, Agency update)
        {
            return 0;
        }
    }
}
