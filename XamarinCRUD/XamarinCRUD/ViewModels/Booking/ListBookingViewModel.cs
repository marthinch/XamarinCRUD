using XamarinCRUD.APIServices;
using XamarinCRUD.Helpers;
using XamarinCRUD.Models;
using XamarinCRUD.Views.Booking;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinCRUD.LocalDatabase;

namespace XamarinCRUD.ViewModels.Booking
{
    public class ListBookingViewModel : BaseViewModel
    {
        // Data
        private List<Models.Booking> bookings;
        public List<Models.Booking> Bookings
        {
            get
            {
                return bookings;
            }
            set
            {
                OnPropertyChanged();
            }
        }

        // Commands
        public ICommand AddCommand
        {
            get
            {
                return new Command(AddBooking);
            }
        }

        // Local services
        LocalBookingService localBookingService;

        public ListBookingViewModel()
        {
            localBookingService = new LocalBookingService();
        }

        private async void AddBooking()
        {
            await NavigationHelper.PushAsyncSingle(new BookingPage());
        }

        public async Task<List<Models.Booking>> GetAllBooking()
        {
            bookings = await localBookingService.GetAllAsync();
           
            //APIResponse apiResponse = await BookingService.GetAllBooking();
            //if (apiResponse != null && apiResponse.Success)
            //{
            //    // Casting the api content
            //    var bookings = (List<Booking>)apiResponse.Content;
            //    if (bookings != null && bookings.Count > 0)
            //        Bookings.AddRange(bookings);
            //}
            //else
            //{
            //    if (apiResponse.Messages != null)
            //    {
            //        string message = apiResponse.Messages.FirstOrDefault();

            //        MessageNotificationHelper.ShowMessageFail(message);
            //    }
            //}

            return bookings;
        }

        public async void GetSelectedBooking(Models.Booking booking)
        {
            await NavigationHelper.PushAsyncSingle(new DetailBookingPage(booking));
        }
    }
}
