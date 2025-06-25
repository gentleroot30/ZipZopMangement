using ZipZop.Data;
using ZipZop.Modals;
using ZipZop.Services.Interfaces;

namespace ZipZop.Services.Implementations
{
    public class BookingService : IBookingService
    {
        private readonly ApplicationDbContext _context;

        public BookingService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Booking?> Book(Booking booking)
        {
            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();
            return booking;
        }

        public Task<Booking?> Booking(Booking booking)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Cancel(int bookingId)
        {
            var booking = await _context.Bookings.FindAsync(bookingId);
            if (booking == null) return false;

            _context.Bookings.Remove(booking);
            await _context.SaveChangesAsync();
            return true;
        }
    }


}
