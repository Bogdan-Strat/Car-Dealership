using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Entities;
using Project.Managers;
using Project.Models;
using Project.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelController : ControllerBase
    {

        private IModelManager manager;

        public ModelController(IModelManager modelManager)
        {
            this.manager = modelManager;
        }

        [HttpGet]
        [Authorize(Policy="BasicUser")]
        public async Task<IActionResult> GetModels()
        {
            var models = manager.GetModels();

            return Ok(models);
            //select * from Model

        }
        
        [HttpGet("select")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> GetModelsIds()
        {
            var modelsIds = manager.GetModelsIds();

            return Ok(modelsIds);
            //select id from Model

        }

        [HttpGet("eager-join")]

        public async Task<IActionResult> EagerJoin()
        {
            
            var producers = manager.GetModelsWithJoin();

            foreach (var x in producers)
            {
                var y = x.Producer;
            }
            return Ok(producers);
            //select * from Model

        }

        [HttpGet("filter")]

        public async Task<IActionResult> Filter()
        { 

        /* var producers = db.Model
             .Include(x => x.Producer)
             .Where(x => x.Producer.Country == "Germany")
             .Select(x => new { Id = x.Id, Name = x.Name })
             .ToList();*/
        var producers = manager.GetModelsFiltered();


            return Ok(producers);
            //select * from Model

        }

        [HttpGet("order by")]

        public async Task<IActionResult> OrderBy()
        {
            /*

            var producers = db.Model
                .Include(x => x.Producer)
                .Where(x => x.Producer.Country == "Germany")
                .Select(x => new { Id = x.Id, Name = x.Name })
                .ToList()
                .OrderBy(x => x.Name);   //OrderByDescending --pt ordonare descrescatoare*/
            var producers = manager.GetModelsFilteredOrdered();


            return Ok(producers);
            //select * from Model

        }

        [HttpPost("withoutObject")]

        public async Task<IActionResult> Create([FromBody] string name, string colour, string release)
        {
            

             var newModel = new Model
             {
                 Id = "5",
                 Name = name,
                 Colour = colour,
                 Release = release

             };


            
            manager.Create(newModel);

            return Ok();
        }


        [HttpPost("WithObject")]

        public async Task<IActionResult> Create([FromBody] ModelModel modelModel)
        {
            

            var newModel = new Model
            {
                Id = modelModel.Id,
                Name = modelModel.Name,
                Colour = modelModel.Colour,
                Release = modelModel.Release


            };

            manager.Create(newModel);

            return Ok();
        }

        [HttpPut("WithObject")]

        public async Task<IActionResult> Update([FromBody] ModelModel modelModel)
        {


            /*var model = db.Model.FirstOrDefault(x => x.Id == modelModel.Id);

            model.Name = modelModel.Name;

            db.Model.Update(model);

            await db.SaveChangesAsync();*/

            await manager.Update(modelModel);

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
