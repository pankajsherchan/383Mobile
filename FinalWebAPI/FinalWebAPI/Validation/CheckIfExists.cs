using FinalWebAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinalWebAPI.Validation
{
    public class CheckIfExists: ValidationAttribute
    {
        private FinalWebAPIContext db = new FinalWebAPIContext();

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            var newuser = validationContext.ObjectInstance as Models.User;

            if (newuser == null)
            {
                return new ValidationResult("User is Empty");
            }




            var user = db.Users.FirstOrDefault(u => u.Email == (string)value && u.Id != newuser.Id);

            if (user == null)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Email Already Exists");
            }


        }

    }
}

        

