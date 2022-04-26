using EntityLayer.Models;

namespace DataAccessLayer.Interfaces
{
    public interface IAgencyDal : IBaseDal<Agency>
    {
        int Add(Agency model);
        int Update(Agency current, Agency update);
    }
}
