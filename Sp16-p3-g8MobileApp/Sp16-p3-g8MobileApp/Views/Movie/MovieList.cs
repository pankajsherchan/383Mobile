using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace Sp16p3g8MobileApp.Views.Movie
{
    public class MovieList : ContentPage
    {
        public MovieList()
        {
            Label header = new Label
            { Text = "Movies",
              Font = Font.SystemFontOfSize(35),
              HorizontalOptions = LayoutOptions.Center
            };

            var cell = new DataTemplate(typeof(ImageCell));

            cell.SetBinding(TextCell.TextProperty, "Movie.Name");
            cell.SetBinding(TextCell.DetailProperty, new Binding("Movie.ReleaseDate", stringFormat: "{0}"));
            cell.SetBinding(ImageCell.ImageSourceProperty, "movie6.png");

          
        }
    }
}
