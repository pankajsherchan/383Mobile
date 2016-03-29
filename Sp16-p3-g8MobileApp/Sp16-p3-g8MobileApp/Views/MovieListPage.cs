using System;

using Xamarin.Forms;
using System.Linq;

namespace Sp16p3g8MobileApp
{
	public class MovieListPage : ContentPage
	{
		public MovieListPage ()
		{
			Padding = new Thickness (0, Device.OnPlatform (20, 0, 0), 0, 0);
			var listView = new ListView ();
			listView.ItemsSource = Movie.GetMovieList ();
			//listView.ItemTemplate = new DataTemplate (typeof(TaskCellTemplate));
			listView.ItemTemplate = new DataTemplate (typeof(MovieTemplate));


			//this line is important to run the async method
			/**
//			 	var command = new Command (async () => {
//				var webService = new RestService ();
//				var webServiceCall = await webService.GetMovieAsync ();
//				Lv.ItemsSource = webServiceCall;
//
//				
//			});
			/**
			button.Command = command;
			command.Execute (null);
		**/
		

		///	Lv.ItemTemplate = new DataTemplate (typeof(TextCell));




			var layout = new StackLayout{};
			layout.Children.Add (listView);

			Content = layout;

			listView.ItemSelected += async (sender, e) => 
			{
				var todoItem = (Movie)e.SelectedItem;
				var todoPage = new MovieDetailPage (todoItem); // so the new page shows correct data
				await Navigation.PushAsync (todoPage);
			};

				}
			}


}
