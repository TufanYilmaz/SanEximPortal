using EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Interfaces
{
    public interface IBaseDal<TModel> where TModel : BaseModel
    {
        int AddOrUpdate(TModel model);
        TModel Get(int id);
        IEnumerable<TModel> GetAll();
        //void AddRange(IEnumerable<TModel> models);
        //bool Delete(int id);
        //void DeleteRange(params int[] modelIds);
        //void DeleteRange(IEnumerable<TModel> models);
    }
}
