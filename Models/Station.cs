using System;
namespace MetroApp.Models
{
    public class Station
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public string StationTogether1 { get; set; }

        public string StationTogether2 { get; set; }

        public string LineCode1 { get; set; }

        public double Lat { get; set; }

        public double Lon { get; set; }

        public StationAddress Address { get; set; }
    }
}
