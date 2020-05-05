using XamarinCRUD.APIServices;
using XamarinCRUD.Helpers;
using XamarinCRUD.Models;
using XamarinCRUD.Views.Booking;
using System;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinCRUD.LocalDatabase;

namespace XamarinCRUD.ViewModels.Booking
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

        // Local services
        LocalBookingService localBookingService;

        public DetailBookingViewModel()
        {
            localBookingService = new LocalBookingService();
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
                    int deletedId = await localBookingService.DeleteAsync(Booking);
                    if (deletedId > 0)
                    {
                        MessageNotificationHelper.ShowMessageSuccess("Booking has been deleted");
                        await NavigationHelper.PopAsyncSingle();
                    }
                    else
                    {
                        MessageNotificationHelper.ShowMessageFail("Unable to delete booking");
                    }

                    //APIResponse apiResponse = await BookingService.DeleteBooking(0);
                    //if (apiResponse != null && apiResponse.Success)
                    //{
                    //    MessageNotificationHelper.ShowMessageSuccess("Booking has been deleted");
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
