using ImageCircle.Forms.Plugin.Abstractions;
using System;

using Xamarin.Forms;

namespace Sp16p3g8MobileApp
{
	public class MovieTemplate : ViewCell
	{
		public MovieTemplate ()
		{

            var image = new CircleImage {
                //BorderColor = Color.White,
                //BorderThickness = 3,
                HeightRequest =51,
                WidthRequest =51,
                Aspect=Aspect.AspectFill,
                HorizontalOptions=LayoutOptions.Center,
                VerticalOptions =LayoutOptions.Center,
                BackgroundColor = Color.White

                
            };
            image.SetBinding(Image.SourceProperty , "movie2.png");

            var NameLabel = new Label
            {
                FontFamily = "HelveticaNeue-Medium" ,
                FontSize = 18,
                TextColor = Color.FromHex("#666")
            };
			NameLabel.SetBinding(Label.TextProperty, "Movie.Name");

            var ReleaseDateLabel = new Label
            {
                FontAttributes = FontAttributes.Bold,
                FontSize = 13,
                TextColor = Color.FromHex("#666")

            };


            ReleaseDateLabel.SetBinding(Label.TextProperty, new Binding("Movie.ReleaseDate", stringFormat :"{0} year"));

            var statusLayout = new StackLayout {

                Orientation = StackOrientation.Horizontal,
                Children = { ReleaseDateLabel}
            };

            var ratingLabel = new Label {
                FontSize =13,
                TextColor = Color.Gray

            };

            ratingLabel.SetBinding(Label.TextProperty, new Binding("Movie.Rating", stringFormat: "{0}"));
            var ratingImage = new Image
            {
                Source = "star.png",
                HeightRequest =13,
                WidthRequest =13
            };

            var ratingStack = new StackLayout {

                Spacing =3,
                Orientation =StackOrientation.Horizontal,
                Children = {ratingImage, ratingLabel}
            };
            var DetailLayout = new StackLayout {
                Padding = new Thickness(10,0,0,0),
                Spacing =0,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Children = {NameLabel, statusLayout , ratingStack}
            };

            var tapImage = new Image {
                Source = "tap.png",
                HorizontalOptions = LayoutOptions.End,
                HeightRequest= 13
            };

            var finalLayout = new StackLayout {
                Spacing = 0,
                Padding = new Thickness(10, 10, 10, 10),
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Children = { image, DetailLayout, tapImage}
            };
            this.View = finalLayout;

		}
	}

}


