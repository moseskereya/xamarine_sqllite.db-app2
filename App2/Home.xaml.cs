using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Home : ContentPage
    {
        public Home()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            ListView.ItemsSource = await App.Database.GetPeopleAsync();
        }


        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(nameEntry.Text) && !String.IsNullOrWhiteSpace(AgeEntry.Text) && !String.IsNullOrWhiteSpace(NationalityEntry.Text) && !String.IsNullOrWhiteSpace(countryEntry.Text))
            {
                await App.Database.SavePersonAsync(new Person
                {
                    Name = nameEntry.Text,
                    Nationality = NationalityEntry.Text,
                    Age = int.Parse(AgeEntry.Text),
                    Location = countryEntry.Text
                });

                nameEntry.Text = AgeEntry.Text = countryEntry.Text = NationalityEntry.Text = string.Empty;
                ListView.ItemsSource = await App.Database.GetPeopleAsync();
            }
        }
    }
}