using DemoAdesso.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoAdesso
{
    public static class PathFinder
    {
        //Bunun normalde Graf ile yapılması gerekir ancak o daha kapsamlı olacak.
        public static List<TripPlan> FilterList(string from, string to, List<TripPlan> plans)
        {
            List<TripPlan> filteredList = new List<TripPlan>();
            var fromCoordinates = Array.ConvertAll(from.Split(','), s => int.Parse(s));
            var toCoordinates = Array.ConvertAll(to.Split(','), s => int.Parse(s));

            foreach (var plan in plans)
            {
                var planFrom = Array.ConvertAll(plan.From.Split(','), s => int.Parse(s)); ;
                var planTo = Array.ConvertAll(plan.To.Split(','), s => int.Parse(s));

                if (planFrom[0] <= planTo[0])
                {
                    if (fromCoordinates[0] >= planFrom[0] && fromCoordinates[0] <= planTo[0] && toCoordinates[0] >= fromCoordinates[0])
                    {
                        if(planFrom[1]>= planTo[1])
                        {
                            if (fromCoordinates[1] >= planFrom[1] && fromCoordinates[1] <= planTo[1] && toCoordinates[1] >= fromCoordinates[1])
                            {
                                filteredList.Add(plan);
                            }
                        }
                        else
                        {
                            if (fromCoordinates[1] <= planFrom[1] && fromCoordinates[1] >= planTo[1] && toCoordinates[1] <= fromCoordinates[1])
                            {
                                filteredList.Add(plan);
                            }
                        }
                    }
                }
                else
                {
                    if (fromCoordinates[0] <= planFrom[0] && fromCoordinates[0] >= planTo[0] && toCoordinates[0] <= fromCoordinates[0])
                    {
                        if (planFrom[1] >= planTo[1])
                        {
                            if (fromCoordinates[1] >= planFrom[1] && fromCoordinates[1] <= planTo[1] && toCoordinates[1] >= fromCoordinates[1])
                            {
                                filteredList.Add(plan);
                            }
                        }
                        else
                        {
                            if (fromCoordinates[1] <= planFrom[1] && fromCoordinates[1] >= planTo[1] && toCoordinates[1] <= fromCoordinates[1])
                            {
                                filteredList.Add(plan);
                            }
                        }
                    }
                }
            }
            return filteredList;
        }
    }
}
