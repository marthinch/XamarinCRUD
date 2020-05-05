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
    public class ListBookingViewModel
    {
        // Data
        public List<SampleModel> Bookings { get; set; }

        // Commands
        public ICommand AddBookingCommand
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

        public async Task<List<SampleModel>> GetAllBooking()
        {
            Bookings = new List<SampleModel>();

            var bookings = await localBookingService.GetAllAsync();
            if (bookings != null && bookings.Count > 0)
                Bookings.AddRange(bookings);

            //APIResponse apiResponse = await BookingService.GetAllBooking();
            //if (apiResponse != null && apiResponse.Success)
            //{
            //    // Casting the api content
            //    var bookings = (List<SampleModel>)apiResponse.Content;
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

            return Bookings;
        }

        public async void GetSelectedBooking(SampleModel booking)
        {
            await NavigationHelper.PushAsyncSingle(new DetailBookingPage(booking));
        }
    }
}
