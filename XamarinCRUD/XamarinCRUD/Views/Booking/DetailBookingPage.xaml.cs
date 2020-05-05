using MobilePOS.Models;
using MobilePOS.ViewModels.Booking;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobilePOS.Views.Booking
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailBookingPage : ContentPage
    {
        private DetailBookingViewModel detailBookingViewModel;

        public DetailBookingPage(SampleModel booking = null)
        {
            InitializeComponent();

            detailBookingViewModel = new DetailBookingViewModel();

            if (booking != null)
                detailBookingViewModel.Booking = booking;

            BindingContext = detailBookingViewModel;
        }
    }
}