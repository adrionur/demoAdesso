using DemoAdesso.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DemoAdesso.DAL
{
    public class Repository : IRepository
    {
        public void Add(object obj)
        {
            using (var db = new TripContext())
            {
                db.Add((TripPlan)obj);
                db.SaveChanges();
            }
        }

        public object GetById(int id)
        {
            object trip = null;
            using (var db = new TripContext())
            {
                trip = db.TripPlans.OrderBy(x => x.Id == id).First();
            }
            return trip;
        }

        public void Update(object obj)
        {
            using (var db = new TripContext())
            {
                db.TripPlans.Add((TripPlan)obj);
                db.SaveChanges();
            }
        }

        public IEnumerable<object> GetAll()
        {
            IEnumerable<object> trips;
            using (var db = new TripContext())
            {
                trips = db.TripPlans.ToList();
            }
            return trips;
        }

        public void Remove(object obj)
        {
            using (var db = new TripContext())
            {
                db.TripPlans.Remove((TripPlan)obj);
                db.SaveChanges();
            }
        }
    }
}
