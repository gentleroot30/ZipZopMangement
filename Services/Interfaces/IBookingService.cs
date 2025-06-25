using ZipZop.Modals;

namespace ZipZop.Services.Interfaces
{
    public interface IBookingService
    {
        Task<Booking?> Book(Booking booking); 
        Task<bool> Cancel(int id);
    }
}