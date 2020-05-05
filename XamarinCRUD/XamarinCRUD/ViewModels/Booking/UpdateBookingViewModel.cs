using XamarinCRUD.Helpers;
using XamarinCRUD.Models;
using System;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinCRUD.LocalDatabase;

namespace XamarinCRUD.ViewModels.Booking
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

        // Local services
        LocalBookingService localBookingService;

        public UpdateBookingViewModel()
        {
            Booking = new SampleModel();

            localBookingService = new LocalBookingService();
        }

        public async void UpdateBooking()
        {
            try
            {
                int updatedId = await localBookingService.UpdateAsync(Booking);
                if (updatedId > 0)
                {
                    MessageNotificationHelper.ShowMessageSuccess("Booking has been updated");

                    NavigationHelper.GoToMainPage();
                }
                else
                {
                    MessageNotificationHelper.ShowMessageFail("Unable to update booking");
                }

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
