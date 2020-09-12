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
                try
                {
                    db.Add((TripPlan)obj);
                    db.SaveChanges();
                }
                catch
                {
                    throw;
                }

            }
        }

        public object GetById(int id)
        {
            object trip = null;
            using (var db = new TripContext())
            {
                trip = db.TripPlans.Where(x => x.Id == id).FirstOrDefault();
            }
            return trip;
        }

        public void Update(object obj)
        {
            using (var db = new TripContext())
            {
                try
                {
                    db.TripPlans.Add((TripPlan)obj);
                    db.SaveChanges();
                }
                catch
                {
                    throw;
                }
            }
        }

        public IEnumerable<object> GetAll()
        {
            IEnumerable<object> trips;
            using (var db = new TripContext())
            {
                try
                {
                    trips = db.TripPlans.ToList();
                }
                catch
                {
                    trips = new List<object>();
                }
            }
            return trips;
        }

        public void Remove(int id)
        {
            var entity = GetById(id);
            using (var db = new TripContext())
            {
                try
                {
                    db.TripPlans.Remove((TripPlan)entity);
                    db.SaveChanges();
                }
                catch
                {
                    throw;
                }
            }
        }
    }
}
