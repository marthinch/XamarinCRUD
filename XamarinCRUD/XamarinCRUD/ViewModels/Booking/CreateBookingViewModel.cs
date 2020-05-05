using XamarinCRUD.Helpers;
using XamarinCRUD.Models;
using System;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinCRUD.LocalDatabase;

namespace XamarinCRUD.ViewModels.Booking
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

        // Local services
        LocalBookingService localBookingService;

        public CreateBookingViewModel()
        {
            Booking = new SampleModel();

            localBookingService = new LocalBookingService();
        }

        public async void CreateBooking()
        {
            try
            {
                Booking.Id = DateTime.Now.ToString();

                int createdId = await localBookingService.SaveAsync(Booking);
                if (createdId > 0)
                {
                    MessageNotificationHelper.ShowMessageSuccess("Booking has been created");
                    await NavigationHelper.PopAsyncSingle();
                }
                else
                {
                    MessageNotificationHelper.ShowMessageFail("Unable to create booking");
                }

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
