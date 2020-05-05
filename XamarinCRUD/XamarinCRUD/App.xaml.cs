using XamarinCRUD.Views.Booking;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinCRUD
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new MainPage();
            MainPage = new NavigationPage(new ListBookingPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {

        }
    }
}
