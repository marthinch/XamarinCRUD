using XamarinCRUD.Models;
using XamarinCRUD.ViewModels.Booking;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinCRUD.Views.Booking
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BookingPage : ContentPage
    {
        private CreateBookingViewModel createBookingViewModel;
        private UpdateBookingViewModel updateBookingViewModel;

        public BookingPage()
        {
            InitializeComponent();

            createBookingViewModel = new CreateBookingViewModel();

            // Set default text
            Title = "Create Booking";
            ButtonBooking.Text = "Create";

            BindingContext = createBookingViewModel;
        }

        public BookingPage(SampleModel booking = null)
        {
            if (booking == null)
                return;

            InitializeComponent();

            updateBookingViewModel = new UpdateBookingViewModel();
            updateBookingViewModel.Booking = booking;

            // Set default text
            Title = "Update Booking";
            ButtonBooking.Text = "Update";

            BindingContext = updateBookingViewModel;
        }
    }
}