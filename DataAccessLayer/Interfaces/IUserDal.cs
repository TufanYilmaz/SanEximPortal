using EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Interfaces
{
    public interface IUserDal:IBaseDal<User>
    {
        User GetUserByUsername(string Username);
        int Add(User user);
        int Update(User current,User update);
        void Delete(int id);
        bool ChangePassword(int id,string password);
    }
}
