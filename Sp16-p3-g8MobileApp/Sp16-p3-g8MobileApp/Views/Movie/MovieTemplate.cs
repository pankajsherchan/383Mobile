using System;

using Xamarin.Forms;

namespace Sp16p3g8MobileApp
{
	public class MovieTemplate : ViewCell
	{
		public MovieTemplate ()
		{
			var NameLabel = new Label
			{
				Font = Font.SystemFontOfSize (NamedSize.Medium)
						.WithAttributes (FontAttributes.Bold)

				};
			NameLabel.SetBinding(Label.TextProperty, new Binding("Movie.Name"));



//			var Release = new Label
//			{
//				Font = Font.SystemFontOfSize (NamedSize.Micro),
//				XAlign = TextAlignment.End,
//				HorizontalOptions = LayoutOptions.FillAndExpand
//
//					//.WithAttributes (FontAttributes.Bold)
//
//			};
//			LocationLabel.SetBinding(Label.TextProperty, new Binding("Location"));
//
//
//			var DescriptionLabel = new Label
//			{
//				Font = Font.SystemFontOfSize (NamedSize.Micro),
//				XAlign = TextAlignment.End,
//				HorizontalOptions = LayoutOptions.FillAndExpand
//
//					//.WithAttributes (FontAttributes.Bold)
//
//			};
//			DescriptionLabel.SetBinding(Label.TextProperty, new Binding("Description"));
//
//
//			var PointsLabel = new Label
//			{
//				Font = Font.SystemFontOfSize (NamedSize.Micro),
//				XAlign = TextAlignment.End,
//				HorizontalOptions = LayoutOptions.FillAndExpand
//
//					//.WithAttributes (FontAttributes.Bold)
//
//			};
//			PointsLabel.SetBinding(Label.TextProperty, new Binding("Points"));
//
//
//			var DurationLabel = new Label
//			{
//				Font = Font.SystemFontOfSize (NamedSize.Micro),
//				XAlign = TextAlignment.End,
//				HorizontalOptions = LayoutOptions.FillAndExpand
//
//					//.WithAttributes (FontAttributes.Bold)
//
//			};
//			DurationLabel.SetBinding(Label.TextProperty, new Binding("Duration"));
//

			View = new StackLayout {

				Children = {NameLabel},

				Orientation = StackOrientation.Horizontal
			};

		}
	}

}


