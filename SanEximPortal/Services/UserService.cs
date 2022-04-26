using EntityLayer.Models;
using SanEximPortal.Services.Interfaces;
using System.Collections.Generic;

namespace SanEximPortal.Services
{
    public class UserService : IUserService
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
