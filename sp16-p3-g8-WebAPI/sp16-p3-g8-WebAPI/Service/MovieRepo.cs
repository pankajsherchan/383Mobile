using sp16_p3_g8_WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace sp16_p3_g8_WebAPI.Service
{
    public class MovieRepo : MovieInterface
    {
        private sp16_p3_g8_WebAPIContext db = new sp16_p3_g8_WebAPIContext();


        //Save Changes in Database
        public void save()
        {
            db.SaveChanges();
        }


        //Get
        public IEnumerable<Movie> Getmovies()
        {
            return db.movies;
        }


        //Get by ID
        public Movie Getmovies(int id)
        {
            Movie movies = db.movies.Find(id);

            return movies;
        }


        //Put
        public void Putmovies(Movie movies)
        {
            db.Entry(movies).State = EntityState.Modified;

        }     


       //Post
        public void Postmovies(Movie movies)
        {
            db.movies.Add(movies);
        }


        //Delete
        public bool Deletemovies(int id)
        {
            Movie movies = db.movies.Find(id);

            if (movies == null)
            {
                return false;
            }
            else
            {
                db.movies.Remove(movies);
                db.SaveChanges();

                return true;

            }
        }


        //Dispose
        public void dispose()
        {
            db.Dispose();
        }


        //MoviesExists
        public bool moviesExists(int id)
        {
            return db.movies.Count(e => e.moviesId == id) > 0;
        }
    }

}