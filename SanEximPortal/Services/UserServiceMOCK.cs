using EntityLayer.Models;
using System.Collections.Generic;

namespace SanEximPortal.Services
{
    public class UserServiceMOCK : Interfaces.IUserService
    {
        public User Authenticate(string username, string password)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public User GetById(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
