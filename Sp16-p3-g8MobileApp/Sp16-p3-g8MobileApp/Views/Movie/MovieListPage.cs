using System;

using Xamarin.Forms;
using System.Linq;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace Sp16p3g8MobileApp
{
	public class MovieListPage : ContentPage
	{


		ObservableCollection<Movie> movies = new ObservableCollection<Movie> ();
		public MovieListPage ()
		{

			var response = Movie.GetMovieList();
			List<Movie> results = new List<Movie>();
			results = response.OrderBy(p=>p.Title).ToList();	

			foreach (var movie in results) {
				movies.Add(new Movie(){
					ID = movie.ID,	
					Title = movie.Title, 
					ReleaseDate = movie.ReleaseDate, 
					Rating = movie.Rating, 
					Description = movie.Description
				}) ;		

			Padding = new Thickness (0, Device.OnPlatform (20, 0, 0), 0, 0);

			/**
			Implementing the search functionality
			**/

			Title = "Movies";
			Padding = new Thickness(20, Device.OnPlatform(20, 20, 20),20,20);
			SearchBar movieSearchBar = new SearchBar{
				Placeholder = "Search Movies",
			
			};


			ListView listView = new ListView ();
			listView.ItemsSource = movies;
	
			movieSearchBar.TextChanged += (sender, e) => {
				if(string.IsNullOrWhiteSpace(movieSearchBar.Text))
					listView.ItemsSource = movies;
				else
					listView.ItemsSource = movies.Where(p=>p.Title.ToLower().Contains(movieSearchBar.Text.ToLower()));

			};

			movieSearchBar.SearchButtonPressed += (sender, e) => {
				if(!string.IsNullOrEmpty(movieSearchBar.Text)){
					listView.ItemsSource = movies.Where(p=>p.Title.ToLower().Contains(movieSearchBar.Text.ToLower()));
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
					Movie item = (Movie)e.SelectedItem;
					listView.SelectedItem = null;
					await Navigation.PushAsync(new MovieDetailPage(item));
				}

			};
		}

		}			
	}

}







