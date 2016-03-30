using System;

using Xamarin.Forms;

namespace Sp16p3g8MobileApp
{
	public class MovieDetailPage : ContentPage
	{
		public MovieDetailPage (Movie movie)
		{
			
				Padding = new Thickness (10, Device.OnPlatform (20, 0, 0), 10, 0);
				BackgroundColor = Color.Yellow;



				var NameLabel = new Label {
				Text = "Name:" +movie.Title,
					Font = Font.SystemFontOfSize (NamedSize.Small)
				};

				var descriptionLabel = new Label {
					Text = "Description:"+movie.Description,
					Font = Font.SystemFontOfSize (NamedSize.Medium)
				};

				var RatingLabel = new Label {
				Text = "Points:" +movie.Rating,
					Font = Font.SystemFontOfSize (NamedSize.Medium)
				};

				var ReleaseDateLabel = new Label {
				Text = "Location: "+ movie.ReleaseDate,
					Font = Font.SystemFontOfSize (NamedSize.Medium)
				};
				

				var DeleteButton = new Button {
					Text = "Delete",
					BackgroundColor = Color.Red };


				var EditButton = new Button {
					Text = "Edit",
					BackgroundColor = Color.Red };


				Content = new ScrollView {
					Content = new StackLayout {
						Spacing = 10,
					Children = { NameLabel, descriptionLabel, RatingLabel, ReleaseDateLabel,DeleteButton, EditButton }
					}
				};
//
				EditButton.Clicked +=(o,e) => 
				{
					Navigation.PushAsync( new MovieEditPage(movie));
				};
			}
		}

}


