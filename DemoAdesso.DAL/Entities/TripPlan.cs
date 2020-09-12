using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoAdesso.Models
{
    public class TripPlan
    {
        //Destination points
        public int Id { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public DateTime TripDate { get; set; }
        public string Description { get; set; }
        public int NumberOfSeats { get; set; }
        public int SeatsTaken { get; set; }

        public TripPlan(string from, string to, DateTime tripDate, string description, int numberOfSeats)
        {
            From = from;
            To = to;
            TripDate = tripDate;
            Description = description;
            NumberOfSeats = numberOfSeats;
        }
    }
}
