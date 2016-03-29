using System;

using Xamarin.Forms;

namespace Sp16p3g8MobileApp
{
	public class LogIn : ContentPage
	{
		public LogIn ()
		{
			Title = "Profile";
			Icon = "Profile.png";

			var UsernameEntry = new Entry{ Placeholder = "Username" };
			var PasswordEntry = new Entry { Placeholder = "Password" };
			var loginButton = new Button {Text = "Login", TextColor = Color.White,
				BackgroundColor = Color.FromHex ("77D065")
			};

			Content = new StackLayout {
				Spacing = 20,
				Padding = 50,
				VerticalOptions = LayoutOptions.Center,
				Children = { UsernameEntry, PasswordEntry, loginButton }
										
							
			};

			loginButton.Clicked +=(o,e) => 
			{
				Navigation.PushAsync( new MovieListPage());
			};
		
		}
	}
}

