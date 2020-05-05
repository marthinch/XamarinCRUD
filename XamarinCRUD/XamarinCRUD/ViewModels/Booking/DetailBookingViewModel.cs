using MobilePOS.APIServices;
using MobilePOS.Helpers;
using MobilePOS.Models;
using MobilePOS.Views.Booking;
using System;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace MobilePOS.ViewModels.Booking
{
    public class DetailBookingViewModel
    {
        // Data
        public SampleModel Booking { get; set; }

        // Commands
        public ICommand UpdateBookingCommand
        {
            get
            {
                return new Command(UpdateBooking);
            }
        }
        public ICommand DeleteBookingCommand
        {
            get
            {
                return new Command(DeleteBooking);
            }
        }

        public async void UpdateBooking()
        {
            await NavigationHelper.PushAsyncSingle(new BookingPage(Booking));
        }

        public async void DeleteBooking()
        {
            try
            {
                bool isDeleted = await Application.Current.MainPage.DisplayAlert("Warning", "Are you sure want to delete this item?", "OK", "Cancel");
                if (isDeleted)
                {
                    MessageNotificationHelper.ShowMessageSuccess("Item has been deleted");
                    await NavigationHelper.PopAsyncSingle();

                    //APIResponse apiResponse = await BookingService.DeleteBooking(0);
                    //if (apiResponse != null && apiResponse.Success)
                    //{
                    //    MessageNotificationHelper.ShowMessageSuccess("Item has been deleted");
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
