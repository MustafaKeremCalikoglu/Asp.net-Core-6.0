using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using TravelCore.Areas.Admin.Models;

namespace TravelCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin")]

    public class BookingHotelSearchController : Controller
    {   

        public async Task<IActionResult> Index()
        {
            
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://booking-com.p.rapidapi.com/v1/hotels/search?children_ages=5%2C0&page_number=0&adults_number=2&children_number=2&room_number=1&include_adjacency=true&units=metric&categories_filter_ids=class%3A%3A2%2Cclass%3A%3A4%2Cfree_cancellation%3A%3A1&checkout_date=2025-01-19&dest_id=-553173&filter_by_currency=AED&dest_type=city&checkin_date=2025-01-18&order_by=popularity&locale=en-gb"),
                Headers =
    {
        { "x-rapidapi-key", "f319629a1fmsh4023684e2263f60p189b29jsne6a4765a669f" },
        { "x-rapidapi-host", "booking-com.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<BookingHotelSearchViewModel>(body);

                return View(values.result);
            }
        }


        
    }
}
