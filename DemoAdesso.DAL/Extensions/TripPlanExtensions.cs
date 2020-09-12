using DemoAdesso.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoAdesso.Extensions
{
    public static class TripPlanExtensions
    {
        public static bool HasEmptySpot(this TripPlan tripPlan)
        {
            return tripPlan.NumberOfSeats != tripPlan.SeatsTaken; 
        }
    }
}
