using System;
using System.Collections.Generic;
using System.Text;

namespace LoggingKata
{
    public class TacoBell : ITrackable
    {
        public TacoBell(string name, double lat, double longish)
        {
            Name = name;
            var myPoint = new Point();
            myPoint.Latitude = lat;
            myPoint.Longitude = longish;
            Location = myPoint;
        }
        public string Name { get; set; }
        public Point Location { get; set; }
    }
}
