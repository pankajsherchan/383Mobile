using FinalWebAPI.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalWebAPI.APIHelper
{
    public class CheckRole
    {
        private FinalWebAPIContext db = new FinalWebAPIContext();
        public User GetUser()
        {

            string email = HttpContext.Current.User.Identity.GetUserName();

            User userInDatabase = db.Users.Where(u => u.Email == email).FirstOrDefault();

            return userInDatabase;
        }
    }
}