using AutoMapper;
using Project.Entities;
using Project.Models;
using Project.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Managers
{
    public class SpecificationsManager : ISpecificationsManager
    {
        private readonly ISpecificationsRepository repo;
        private readonly IMapper Mapper;

        public SpecificationsManager(ISpecificationsRepository repo)
        {
            this.repo = repo;
        }

        public async Task Create(Specifications model)
        {
            await repo.Create(model);
        }

        public void Delete(string id)
        {
            var specifications = repo.GetSpecifications().FirstOrDefault(x => x.Id == id);
            repo.Delete(specifications);
        }

        public List<SpecificationsModel> GetSpecificationsFilteredOrdered()
        {
            var specifications = repo.GetSpecifications();

            var specificationFiltered = specifications.Where(x => x.Model.Colour == "Black")
                                      //.Select(x => new SpecificationsModel { Id = x.Id, Engine = x.Engine })
                                      .Select(x => Mapper.Map<Specifications, SpecificationsModel>(x))
                                      .OrderBy(x => x.Id)
                                      .ToList();
            return specificationFiltered;
        }

        public async Task Update(SpecificationsModel model)
        {
            //var mod = repo.GetSpecifications()
            //             .FirstOrDefault(x => x.Id == model.Id);
            var mod = Mapper.Map<SpecificationsModel, Specifications>(model);
            //mod.Engine = model.Engine;

            await repo.Update(mod);
        }
    }
}
