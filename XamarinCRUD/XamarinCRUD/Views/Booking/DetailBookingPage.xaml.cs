using XamarinCRUD.Models;
using XamarinCRUD.ViewModels.Booking;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinCRUD.Views.Booking
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailBookingPage : ContentPage
    {
        private DetailBookingViewModel detailBookingViewModel;

        public DetailBookingPage(Models.Booking booking = null)
        {
            InitializeComponent();

            detailBookingViewModel = new DetailBookingViewModel();

            if (booking != null)
                detailBookingViewModel.Booking = booking;

            BindingContext = detailBookingViewModel;
        }
    }
}