using sp16_p3_g8_WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sp16_p3_g8_WebAPI.DTO_Service
{
    public class DTOFactory
    {
        public MovieDTO createMoviesDTO (Movie movie)
        {
            MovieDTO _movDto = new MovieDTO
            {
                title = movie.title,
                genre = movie.genre,
                actors = movie.actors,
                description = movie.description,
                releaseDate = movie.releaseDate,
                rating = movie.rating

            };
            return _movDto;
           
        }
    }
}