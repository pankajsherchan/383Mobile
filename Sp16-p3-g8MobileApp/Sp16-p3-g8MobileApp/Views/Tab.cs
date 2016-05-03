using Sp16p3g8MobileApp.Views.Movie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Sp16p3g8MobileApp.Views
{
   public class Tab : TabbedPage
    {

            private readonly Page tab1Page;
            private readonly Page tab2Page;
            private readonly Page tab3Page;

            public Tab()
            {
                Title = "383 Management App";
                tab1Page = new MovieListPage() { Title = "Movies" };
                tab2Page = new HomePage() { Title = "Scan your code" };
                tab3Page = new PurchasePage() { Title = "Your Purchase History" };

                Children.Add(tab1Page);
                Children.Add(tab2Page);
                Children.Add(tab3Page);
            }

            public void SwitchToTab1()
            {
                CurrentPage = tab1Page;
            }

            public void SwitchToTab2()
            {
                CurrentPage = tab2Page;
            }

            public void SwitchToTab3()
            {
                CurrentPage = tab3Page;
            }
        }
    

}
