using EntityLayer.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer.Repositories
{
    public class UserMOCKRepository : BaseRepo, Interfaces.IUserDal
    {
        static List<User> users = new List<User>()
                    {
                        new User()
                        {
                            Id = 1,
                            CreatedDate = DateTime.Now,
                            Email="yilmaz@tufan.com",
                            Password="11223344",
                            FirmTitle="Sanko A.Ş.",
                            Role=Role.admin.ToString(),
                            DocumentReceivers="tufan@sanko.com.tr"

                        },
                        new User()
                        {
                            Id = 2,
                            CreatedDate = DateTime.Now,
                            Email="super@super.com",
                            Password="11223344",
                            FirmTitle="Superfilm A.Ş.",
                            Role=Role.user.ToString(),
                            DocumentReceivers="super@sanko.com.tr"

                        },new User()
                        {
                            Id = 3,
                            CreatedDate = DateTime.Now,
                            Email="cimko@cimko.com",
                            Password="11223344",
                            FirmTitle="Çimko A.Ş.",
                            Role=Role.user.ToString(),
                            DocumentReceivers="cimko@sanko.com.tr;tufan@sanko.com.tr;tufan@yilmaz.com.tr"

                        },new User()
                        {
                            Id = 4,
                            CreatedDate = DateTime.Now,
                            Email="hastane@hastane.com",
                            Password="11223344",
                            FirmTitle="Hastane A.Ş.",
                            Role=Role.user.ToString(),

                        },new User()
                        {
                            Id = 5,
                            CreatedDate = DateTime.Now,
                            Email="enerji@enerji.com",
                            Password="11223344",
                            FirmTitle="Enerji A.Ş.",
                            Role=Role.user.ToString(),

                        },
                    };
        public UserMOCKRepository(IConfiguration config) : base(config)
        {
        }

        public int Add(User user)
        {
            int lastId=users.Max(t => t.Id);
            user.Id=++lastId;
            users.Add(user);
            return lastId;
        }

        public int AddOrUpdate(User model)
        {
            var current = Get(model.Id);
            if (current == null)
            {
                return Add(model);
            }
            else
            {
                return Update(current, model);
            }
        }

        public bool ChangePassword(int id, string password)
        {
            var index = users.FindIndex(t => t.Id == id);
            users[index].Password = password;
            return true;
        }

        public void Delete(int id)
        {
            users.Remove(users.Find(i => i.Id == id));
        }

        public User Get(int id)
        {
            return users.Find(t=>t.Id==id);
        }

        public IEnumerable<User> GetAll()
        {
            return users;
        }

        public User GetUserByUsername(string Username)
        {
            return users.Find(t=>t.Email== Username);
        }

        public int Update(User current, User update)
        {
            //var user = users.Find(t => t.Id == current.Id);
            var index = users.FindIndex(t => t.Id == current.Id);
            users[index]=update;
            return update.Id;
        }
    }
}
