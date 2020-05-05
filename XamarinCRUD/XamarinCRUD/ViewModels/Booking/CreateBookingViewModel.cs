using MobilePOS.Helpers;
using MobilePOS.Models;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace MobilePOS.ViewModels.Booking
{
    public class CreateBookingViewModel
    {
        // Data
        public SampleModel Booking { get; set; }

        // Commands
        public ICommand BookingCommand
        {
            get
            {
                return new Command(CreateBooking);
            }
        }

        public CreateBookingViewModel()
        {
            Booking = new SampleModel();
        }

        public async void CreateBooking()
        {
            try
            {
                Booking.Id = 1;

                MessageNotificationHelper.ShowMessageSuccess("Booking has been created");
                await NavigationHelper.PopAsyncSingle();

                //APIResponse apiResponse = await BookingService.CreateBooking(Booking);
                //if (apiResponse != null && apiResponse.Success)
                //{
                //    MessageNotificationHelper.ShowMessageSuccess("Booking has been created");
                //    await Navigation.PopAsync();
                //}
                //else
                //{
                //    if (apiResponse.Messages != null)
                //    {
                //        string message = apiResponse.Messages.FirstOrDefault();
                //        MessageNotificationHelper.ShowMessageFail(message);
                //    }
                //}
            }
            catch (MobileException exception)
            {
                MessageNotificationHelper.ShowMessageFail(exception.Message);
            }
            catch (Exception exception)
            {
                MessageNotificationHelper.ShowMessageError(exception.GetBaseException().Message);
            }
        }
    }
}
