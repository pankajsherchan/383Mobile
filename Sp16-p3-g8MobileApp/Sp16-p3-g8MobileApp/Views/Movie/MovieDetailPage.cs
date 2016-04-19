using Sp16p3g8MobileApp.Models;
using System;

using Xamarin.Forms;

namespace Sp16p3g8MobileApp
{
	public class ShowTimeDetailPage : ContentPage
	{
		public ShowTimeDetailPage (Showtime showtime)
		{
            Title = "Watch this Movie";
            BindingContext = showtime;
			
				Padding = new Thickness (10, Device.OnPlatform (20, 0, 0), 10, 0);

            //Application myApp = Application.Current;
            //myApp.Resources.Add(new Xamarin.Forms.Style(typeof(Page))
            //{
            //    Setters =
            //    {
            //        new Xamarin.Forms.Setter {Property =Page.BackgroundImageProperty, Value = new Uri(showtime.Movie.Poster) }

            //    }

            //});



            //var NameLabel = new Label
            //{
            //    Text = "Name:" + showtime.Movie.Name,
            //    Font = Font.SystemFontOfSize(NamedSize.Small)
            //};

            var NameLabel = new Label
            {
            };
            NameLabel.SetBinding(Label.TextProperty, "Movie.Name");

            var image = new Image {};
            image.SetBinding(Image.SourceProperty, "Movie.Poster");

            var showDate = new Label { };
          
            showDate.SetBinding(Label.TextProperty, new Binding("StartDate ", stringFormat: "Date: {0}"));

            var showTime = new Label { };

            showTime.SetBinding(Label.TextProperty, new Binding("StartTime ", stringFormat: "Time: {0}"));


            var screenLabel = new Label { };
            screenLabel.SetBinding(Label.TextProperty, new Binding("Screen.ScreenNumber", stringFormat: "Screen:{0}"));

            var descriptionLabel = new Label { };
            descriptionLabel.SetBinding(Label.TextProperty, new Binding("Movie.Plot", stringFormat: "Overview :{0}"));

            var ActorsLabel = new Label { };
            ActorsLabel.SetBinding(Label.TextProperty, new Binding("Movie.Actors", stringFormat: "Cast :{0}"));

            var GenreLabel = new Label { };
            ActorsLabel.SetBinding(Label.TextProperty, new Binding("Movie.Genre", stringFormat: "Genre :{0}"));

            var AwardsLabel = new Label { };
            AwardsLabel.SetBinding(Label.TextProperty, new Binding("Movie.Awards", stringFormat: "Awards :{0}"));




            var grid = new Grid();
            grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto});
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(2, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(2, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(2, GridUnitType.Star) });
           
            grid.Children.Add(NameLabel, 0, 0);
            grid.Children.Add(descriptionLabel, 0, 1);
            grid.Children.Add(showDate, 1, 0);
            grid.Children.Add(showTime, 1, 1);



            Content = new ScrollView {
					Content = new StackLayout {
						Spacing = 10,
                        
					Children = {image , grid }
					}
				};

				
			}
		}

}


