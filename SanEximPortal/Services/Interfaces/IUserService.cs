﻿using EntityLayer.Models;
using System.Collections.Generic;


namespace SanEximPortal.Services.Interfaces
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
        IEnumerable<User> GetAll();
        User GetById(int id);
    }
}
