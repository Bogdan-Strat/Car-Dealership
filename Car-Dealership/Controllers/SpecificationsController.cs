using Microsoft.AspNetCore.Mvc;
using Project.Entities;
using Project.Managers;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecificationsController : Controller
    {
        private ISpecificationsManager manager;

        public SpecificationsController(ISpecificationsManager specificationsManager)
        {
            this.manager = specificationsManager;
        }

        [HttpGet("SpecificationsFilteredOrdered")]
        
        public async Task<IActionResult> GetSpecificationsFilteredOrdered()
        {
            var specifications = manager.GetSpecificationsFilteredOrdered();

            return Ok(specifications);
            

        }


        [HttpPost("withoutObject")]

        public async Task<IActionResult> Create([FromBody]  string engine, int horsepower)
        {


            var sepcifications = new Specifications
            {
                Id = "5",
                Engine = engine,
                HorsePower = horsepower

            };



            manager.Create(sepcifications);

            return Ok();
        }

        [HttpPut("WithObject")]

        public async Task<IActionResult> Update([FromBody] SpecificationsModel specificationsModel)
        {


            await manager.Update(specificationsModel);

            return Ok();
        }


        [HttpDelete("id")]

        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            manager.Delete(id);
            return Ok();
        }

    }
}
