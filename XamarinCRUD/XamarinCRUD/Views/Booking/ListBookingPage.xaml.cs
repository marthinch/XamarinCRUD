using MobilePOS.Models;
using MobilePOS.ViewModels.Booking;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobilePOS.Views.Booking
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListBookingPage : ContentPage
    {
        private ListBookingViewModel listBookingViewModel;

        public ListBookingPage()
        {
            InitializeComponent();

            listBookingViewModel = new ListBookingViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            listBookingViewModel.Bookings = listBookingViewModel.GetAllBooking();

            BindingContext = listBookingViewModel;
        }

        private void ListViewBooking_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            SampleModel item = (SampleModel)e.Item;
            if (item == null)
                return;

            listBookingViewModel.GetSelectedBooking(item);
        }
    }
}
