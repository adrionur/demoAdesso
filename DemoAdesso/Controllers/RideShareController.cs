using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoAdesso.DAL;
using DemoAdesso.Extensions;
using DemoAdesso.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoAdesso.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdessoRideShareController : ControllerBase
    {
        private static Repository repository = new Repository();
        //public AdessoRideShareController()
        //{

        //}

        [HttpGet]
        public List<TripPlan> GetAll()
        {
            return (List<TripPlan>)repository.GetAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public TripPlan GetById(int id)
        {
            return (TripPlan)repository.GetById(id);
        }

        [HttpGet("{from}/{to}")]
        public List<TripPlan> GetByParams(string from, string to)
        {
            return null;
        }

        // POST api/values
        [HttpPost]
        [Consumes("application/json")]
        public string AddNewTrip([FromBody] TripPlan model)
        {
            var newTripPlan = (TripPlan)repository.GetById(model.Id);
            if (newTripPlan != null)
                return Constants.ErrorCodeAlreadyAdded;

            repository.Add(model);
            return Constants.SUCCESSINSERT;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        [Consumes("application/json")]
        public string Put([FromBody] TripPlan model)
        {
            var tripPlan = (TripPlan)repository.GetById(model.Id);
            if (tripPlan.HasEmptySpot())
            {
                tripPlan.SeatsTaken++;
                repository.Update(tripPlan);
            }
            return Constants.SUCCESSUPDATE;
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        [Consumes("application/json")]
        public string Delete(int id)
        {
            repository.Remove(id);
            return Constants.SUCCESEREMOVE;
        }
    }
}
