using MobilePOS.APIServices;
using MobilePOS.Helpers;
using MobilePOS.Models;
using MobilePOS.Views.Booking;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MobilePOS.ViewModels.Booking
{
    public class ListBookingViewModel
    {
        // Binding Properties
        public List<object> Bookings { get; set; }

        // Commands
        public ICommand AddBookingCommand
        {
            get
            {
                return new Command(AddBooking);
            }
        }

        private async void AddBooking()
        {
            await NavigationHelper.PushAsyncSingle(new BookingPage());
        }

        public List<object> GetAllBooking()
        {
            Bookings = new List<object>();

            for (int i = 0; i <= 10; i++)
            {
                SampleModel newItem = new SampleModel
                {
                    Id = i,
                    Name = "Item " + i,
                    Email = "Email " + i,
                    PhoneNumber = "08123456789" + i
                };

                Bookings.Add(newItem);
            }

            //APIResponse apiResponse = await BookingService.GetAllBooking();
            //if (apiResponse != null && apiResponse.Success)
            //{
            //    // Casting the api content
            //    var bookings = (List<object>)apiResponse.Content;
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

        public async void GetSelectedBooking(object booking)
        {
            await NavigationHelper.PushAsyncSingle(new DetailBookingPage((SampleModel)booking));
        }
    }
}
