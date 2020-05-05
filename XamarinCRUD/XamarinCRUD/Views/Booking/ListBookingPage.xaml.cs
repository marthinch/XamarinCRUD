using XamarinCRUD.Models;
using XamarinCRUD.ViewModels.Booking;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinCRUD.Views.Booking
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

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            ListViewBooking.ItemsSource = await listBookingViewModel.GetAllBooking();

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
