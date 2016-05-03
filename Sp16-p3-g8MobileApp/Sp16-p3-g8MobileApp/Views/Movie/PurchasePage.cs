using System;

using Xamarin.Forms;
using System.Linq;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using Sp16p3g8MobileApp.Models;
using Sp16p3g8MobileApp.Views.Movie;

namespace Sp16p3g8MobileApp
{
    public class PurchasePage : ContentPage
    {
        ObservableCollection<PurchaseDetail> purchases = new ObservableCollection<PurchaseDetail>();

        protected override async void OnAppearing()
        {
           
                base.OnAppearing();

                var movieService = new MovieService();
                var response = await movieService.GetPurchaseAsync();

                foreach (var purchase in response)
                {
                    purchases.Add(new PurchaseDetail()
                    {
                        
                        Id = purchase.Id,
                        Name =purchase.Name,
                        InventoryCount =purchase.InventoryCount,
                        ScreenNumber = purchase.ScreenNumber,
                        date = purchase.date,
                        Price =purchase.Price,
                        time = purchase.time,
                        type =purchase.type
                       

                    });
               }           
        }

        public PurchasePage()
        {
            Title = "Purchases";
            
            ListView listView = new ListView();
            listView.ItemsSource = purchases;
            listView.HasUnevenRows = true;
            listView.SeparatorColor = Color.FromHex("#ddd");


            listView.ItemTemplate = new DataTemplate(typeof(PurchaseTemplate));


            var layout = new StackLayout { };
          
            layout.Children.Add(listView);

            Content = layout;

        }

    }
}








