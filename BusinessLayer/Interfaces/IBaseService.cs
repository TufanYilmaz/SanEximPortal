using EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interfaces
{
    public interface IBaseService<TModel> where TModel : BaseModel
    {
        int AddOrUpdate(TModel model);
        TModel Get(int id);
        IEnumerable<TModel> GetAll();
        int Add(TModel model);
        int Update(TModel model);
        void Delete(int id);
    }
}
