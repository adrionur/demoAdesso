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
    [Route("rest/[controller]")]
    [ApiController]
    public class AdessoRideShare : ControllerBase
    {
        private Repository repository;
        public AdessoRideShare(Repository repository)
        {
            this.repository = repository;
        }

        [HttpGet()]
        public List<TripPlan> GetAll()
        {
            return (List<TripPlan>)repository.GetAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public TripPlan Get(int id)
        {
            return (TripPlan)repository.GetById(id);
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
        public string Put([FromBody] TripPlan model)
        {
            var tripPlan = (TripPlan)repository.GetById(model.Id);
            if(tripPlan.HasEmptySpot())
            {
                tripPlan.SeatsTaken++;
                repository.Update(model);
            }
            return Constants.SUCCESSUPDATE;
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            repository.Remove(id);
            return Constants.SUCCESEREMOVE;
        }
    }
}
