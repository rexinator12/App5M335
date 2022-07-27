using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App5
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            collectionView.ItemsSource = await App.Database.GetPeopleAsync();
        }

        async void OnButtonClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(nameEntry.Text) && !string.IsNullOrWhiteSpace(pubN.Text))
            {
                await App.Database.SavePersonAsync(new Game
                {
                    Name = nameEntry.Text,
                    PublisherName = pubN.Text, 
                    Publishdate = pubD.Date,
                });

                nameEntry.Text = string.Empty;
                pubN.Text = string.Empty;
                pubD.Date = DateTime.Now;

                collectionView.ItemsSource = await App.Database.GetPeopleAsync();
                await DisplayAlert("Eingefügt!", "Spiel wurde eingefügt", "OK");
            }
        }
    }
}
