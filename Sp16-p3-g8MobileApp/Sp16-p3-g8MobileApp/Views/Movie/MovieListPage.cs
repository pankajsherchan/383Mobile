using System;

using Xamarin.Forms;
using System.Linq;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using Sp16p3g8MobileApp.Models;

namespace Sp16p3g8MobileApp
{
	public class MovieListPage : ContentPage
	{


		ObservableCollection<Showtime> movies = new ObservableCollection<Showtime> ();
        private Boolean initialized = false;

        protected override async void OnAppearing()
        {
            if (!initialized)
            {
                base.OnAppearing();

                var movieService = new MovieService();
                var response = await movieService.GetMovieAsync();

                foreach (var movie in response)
                {
                    movies.Add(new Showtime()
                    {
                        Id = movie.Id,
                        Screen = movie.Screen,
                        StartDateTime = movie.StartDateTime,
                        ScreenId = movie.ScreenId,
                        Movie = movie.Movie,
                        MovieId =movie.MovieId

                    });
                }
            }
            initialized = true;
        }
        public MovieListPage ()
		{

			/**
			Implementing the search functionality
			**/

			Title = "Movies";
            Padding = new Thickness(0, Device.OnPlatform(20, 0, 0), 0, 0);
            SearchBar movieSearchBar = new SearchBar{
				Placeholder = "Search Movies",
			
			};


			ListView listView = new ListView ();
			listView.ItemsSource = movies;
	
			movieSearchBar.TextChanged += (sender, e) => {
				if(string.IsNullOrWhiteSpace(movieSearchBar.Text))
					listView.ItemsSource = movies;
				else
					listView.ItemsSource = movies.Where(p=>p.Movie.Name.Contains(movieSearchBar.Text.ToLower()));

			};

			movieSearchBar.SearchButtonPressed += (sender, e) => {
				if(!string.IsNullOrEmpty(movieSearchBar.Text)){
					listView.ItemsSource = movies.Where(p=>p.Movie.Name.ToLower().Contains(movieSearchBar.Text.ToLower()));
				}
			};

			listView.ItemTemplate = new DataTemplate (typeof(MovieTemplate));


			var layout = new StackLayout{};
			layout.Children.Add (movieSearchBar);
			layout.Children.Add (listView);

			Content = layout;

			listView.ItemSelected += async (sender, e) => 
			{
				if (e.SelectedItem != null)
				{
					Showtime item = (Showtime)e.SelectedItem;
					listView.SelectedItem = null;
					await Navigation.PushAsync(new ShowTimeDetailPage(item));
				}

			};
		}

		}			
}








