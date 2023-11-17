namespace BlazorApp1.Shared
{
    public interface IHotelBookingService
    {
        Task CreateEditBooking(int id, int roomNumber, string guestName);
        Task<Booking> GetBooking(int id);
        Task DeleteBooking(int id);
        Task<List<Booking>> GetAllBookings();
    }
}
