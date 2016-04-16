using Sp16p3g8MobileApp.Models;
using System;

using Xamarin.Forms;

namespace Sp16p3g8MobileApp
{
	public class ShowTimeDetailPage : ContentPage
	{
		public ShowTimeDetailPage (Showtime showtime)
		{
			
				Padding = new Thickness (10, Device.OnPlatform (20, 0, 0), 10, 0);
				BackgroundColor = Color.Yellow;



				var NameLabel = new Label {
				Text = "Name:" +showtime.Movie.Name,
					Font = Font.SystemFontOfSize (NamedSize.Small)
				};

				var descriptionLabel = new Label {
					Text = "Description:"+showtime.Movie.Description,
					Font = Font.SystemFontOfSize (NamedSize.Medium)
				};

				var RatingLabel = new Label {
				Text = "Rating:" +showtime.Movie.Rating,
					Font = Font.SystemFontOfSize (NamedSize.Medium)
				};

				var ReleaseDateLabel = new Label {
				Text = "ReleaseDate: "+ showtime.Movie.ReleaseDate,
					Font = Font.SystemFontOfSize (NamedSize.Medium)
				};

            var ScreenNumber = new Label
            {
                    Text = "ScreenNumber: " + showtime.Screen.ScreenNumber,
                    Font = Font.SystemFontOfSize(NamedSize.Small)
            };

            var StartTime = new Label
            {
                Text = "StartTime: " + showtime.StartDateTime,
                Font = Font.SystemFontOfSize(NamedSize.Small)
            };



            Content = new ScrollView {
					Content = new StackLayout {
						Spacing = 10,
					Children = { NameLabel, descriptionLabel, RatingLabel, ReleaseDateLabel, ScreenNumber , StartTime }
					}
				};

				
			}
		}

}


