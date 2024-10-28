using System.Security.Cryptography.X509Certificates;

namespace TravelCore.Areas.Admin.Models
{
    public class DestinationModel
    {

        public string? city { get; set; }
        public string? Daynight { get; set; }
        public double Price { get; set; }
        public int Capacity { get; set; }

    }
}
