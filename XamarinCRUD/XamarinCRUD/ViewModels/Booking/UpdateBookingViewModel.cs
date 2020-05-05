using MobilePOS.Helpers;
using MobilePOS.Models;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace MobilePOS.ViewModels.Booking
{
    public class UpdateBookingViewModel
    {
        // Data
        public SampleModel Booking { get; set; }

        // Commands
        public ICommand BookingCommand
        {
            get
            {
                return new Command(UpdateBooking);
            }
        }

        public UpdateBookingViewModel()
        {
            Booking = new SampleModel();
        }

        public async void UpdateBooking()
        {
            try
            {
                var updatedBooking = Booking;

                MessageNotificationHelper.ShowMessageSuccess("Booking has been updated");
                await NavigationHelper.PopAsyncSingle();

                //APIResponse apiResponse = await BookingService.UpdateBooking(1, booking);
                //if (apiResponse != null && apiResponse.Success)
                //{
                //    MessageNotificationHelper.ShowMessageSuccess("Booking has been updated");

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
