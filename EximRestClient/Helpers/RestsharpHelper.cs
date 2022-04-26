﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EximRestClient.Helpers
{
    public static class RestsharpHelper
    {
        public static string GetBasicAuthBase64String(string username, string password)
        {
            string auth = username + ":" + password;
            byte[] inArray = System.Text.UTF8Encoding.UTF8.GetBytes(auth);
            var result = Convert.ToBase64String(inArray);
            result = "Basic " + result;
            return result;
        }
    }
}