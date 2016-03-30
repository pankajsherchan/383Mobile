using sp16_p3_g8_WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sp16_p3_g8_WebAPI.Service
{
    interface MovieInterface 
    {
       void save();
       IEnumerable<Movie> Getmovies();

        Movie Getmovies(int id);

        void Putmovies(Movie movies);

        void Postmovies(Movie movies);

        bool Deletemovies(int id);

        void dispose();

        bool moviesExists(int id);
    }
}
