using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace Sp16p3g8MobileApp {
    public class ConfirmationPage : ContentPage {
        public ConfirmationPage(string URL) {

            //Call example
            //new NavigationPage(new ConfirmationPage("http://www.robertsspaceindustries.com"));

            Content = new StackLayout {
                Children = {
                    #if __IOS__
                    new Button {Text="Go Back" }, 
                    #endif
                      new WebView() { Source = URL, VerticalOptions=LayoutOptions.FillAndExpand }
                }, Spacing=10
            };
            

        }
    }
}
