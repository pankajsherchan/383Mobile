using System;

using Xamarin.Forms;

namespace Sp16p3g8MobileApp
{
	public class MovieEditPage : ContentPage
	{
		public MovieEditPage (Movie movie)
		{
			Title = "Edit Movie";

			var NameEntry = new Entry {Placeholder = "Name", HorizontalOptions= LayoutOptions.FillAndExpand, 
				Text =movie.Name};
			var ReleaseDateEntry = new Entry {Placeholder = "Location", HorizontalOptions= LayoutOptions.FillAndExpand, Text=movie.ReleaseDate};
			var RatingEntry = new Entry {Placeholder = "Points", HorizontalOptions= LayoutOptions.FillAndExpand ,
				Text=movie.Rating.ToString()};
			var DescriptionEntry = new Entry { 
				WidthRequest = 300,
				HeightRequest = 200,
				Placeholder = "Description",
				//	HorizontalOptions = LayoutOptions.Start
				HorizontalOptions= LayoutOptions.FillAndExpand,
				Text=movie.Description
			};
			var editButton = new Button{Text = "SaveChanges", 
				FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Button))  };

			Content = new StackLayout {
				Children = { NameEntry, ReleaseDateEntry, RatingEntry, DescriptionEntry, editButton }
			};

		}
	}

}


