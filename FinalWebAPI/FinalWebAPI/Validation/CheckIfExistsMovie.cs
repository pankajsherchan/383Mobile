using FinalWebAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinalWebAPI.Validation
{
    public class CheckIfExistsMovie : ValidationAttribute
    {
       
            private FinalWebAPIContext db = new FinalWebAPIContext();

            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {

                var newMovie = validationContext.ObjectInstance as Models.Movie;

                if (newMovie == null)
                {
                    return new ValidationResult("movie is Empty");
                }




                var movieInDatabase = db.Movies.FirstOrDefault(u => u.Name == (string)value && u.Id != newMovie.Id);

                if (movieInDatabase == null)
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult("Movie Already Exists");
                }


            }

        }
    
}
