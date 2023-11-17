using System.Net.Http.Json;
using System.Text.Json.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace BlazorApp1.Shared
{
    public class HotelBookingService : IHotelBookingService
    {

        string base_url = $"https://localhost:7040/api/HotelBooking/";
        private readonly HttpClient _httpClient;

        public HotelBookingService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateEditBooking(int id, int roomNumber, string guestName)
        {
            var booking = new Booking
            {
                Id = id,
                RoomNumber = roomNumber,
                GuestName = guestName
            };

            var request = new HttpRequestMessage(HttpMethod.Post, base_url + "CreateEdit");
            request.Headers.Add("Origin", "https://localhost:7034"); // Dodaj swój adres klienta

            request.Content = new StringContent(JsonConvert.SerializeObject(booking), Encoding.UTF8, "application/json");

            var response = await _httpClient.SendAsync(request);
            var data = await response.Content.ReadAsStringAsync();
            Console.WriteLine(data);
            response.EnsureSuccessStatusCode();

        }

        public async Task<Booking> GetBooking(int id)
        {
            return await _httpClient.GetFromJsonAsync<Booking>(base_url + $"Get?id={id}");
        }

        public async Task DeleteBooking(int id)
        {
            var response = await _httpClient.DeleteAsync(base_url + $"Delete?id={id}");
            response.EnsureSuccessStatusCode();
        }

        public async Task<List<Booking>> GetAllBookings()
        {
            return await _httpClient.GetFromJsonAsync<List<Booking>>(base_url + "GetAll");
        }
    }

}
