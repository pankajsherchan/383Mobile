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
				Text = "Name:" +movie.Name,
					Font = Font.SystemFontOfSize (NamedSize.Small)
				};

				var descriptionLabel = new Label {
					Text = "Description:"+movie.Description,
					Font = Font.SystemFontOfSize (NamedSize.Medium)
				};

				var RatingLabel = new Label {
				Text = "Rating:" +movie.Rating,
					Font = Font.SystemFontOfSize (NamedSize.Medium)
				};

				var ReleaseDateLabel = new Label {
				Text = "ReleaseDate: "+ movie.ReleaseDate,
					Font = Font.SystemFontOfSize (NamedSize.Medium)
				};
				
           

				Content = new ScrollView {
					Content = new StackLayout {
						Spacing = 10,
					Children = { NameLabel, descriptionLabel, RatingLabel, ReleaseDateLabel }
					}
				};

				
			}
		}

}


