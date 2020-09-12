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

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok((List<TripPlan>)repository.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok((TripPlan)repository.GetById(id));
        }

        [HttpGet("{from}/{to}")]
        public IActionResult GetByParams(string from, string to)
        {
            var list = (List<TripPlan>)repository.GetAll();
            var newList = PathFinder.FilterList(from, to, list);
            return Ok(newList);
        }

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
