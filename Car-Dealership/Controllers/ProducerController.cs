using Microsoft.AspNetCore.Http;
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
    public class ProducerController : ControllerBase
    {
        private readonly IProducerManager manager;

        public ProducerController(IProducerManager specificationsManager)
        {
            this.manager = specificationsManager;
        }

        [HttpGet("ProducersFilteredOrdered")]

        public async Task<IActionResult> GetSpecificationsFilteredOrdered()
        {
            var producers = manager.GetProducerFilteredOrdered();

            return Ok(producers);


        }

        [HttpPost("witHObj")]
        public async Task<IActionResult> Create([FromBody] string name, string country)
        {


            var producers = new Producer
            {
                Id = "5",
                Name = name,
                Country = country

            };



            manager.Create(producers);

            return Ok();
        }
        
        [HttpPut("WithObject")]

        public async Task<IActionResult> Update([FromBody] ProducerModel producersModel)
        {


            await manager.Update(producersModel);

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
