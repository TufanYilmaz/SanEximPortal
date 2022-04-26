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
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        public UserManager(IConfiguration config)
        {
            if (_userDal == null)
            {
                _userDal = new UserRepository(config);
            }
        }

        public UserManager(IConfiguration config, IUserDal userDal)
        {
            _userDal = userDal;
        }
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public int AddOrUpdate(User model)
        {
            return _userDal.AddOrUpdate(model);

        }
        public User Get(int id)
        {
            return _userDal.Get(id);
        }

        public IEnumerable<User> GetAll()
        {
            return _userDal.GetAll();

        }

        public User GetUserByName(string username)
        {
            return _userDal.GetUserByUsername(username);
        }

        public int Add(User model)
        {
            return _userDal.Add(model);
        }

        public int Update(User model)
        {
            var current=Get(model.Id);
            return _userDal.Update(current, model);
        }

        public void Delete(int id)
        {
            _userDal.Delete(id);
        }

        public bool ChangePassword(int id, string password)
        {
            return _userDal.ChangePassword(id, password);
        }
    }
}
