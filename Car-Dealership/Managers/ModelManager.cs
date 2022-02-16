using Project.Entities;
using Project.Models;
using Project.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Managers
{
    public class ModelManager:IModelManager
    {
        private readonly IModelRepository repo;

        public ModelManager(IModelRepository repository)
        {
            this.repo = repository;
        }

        public async Task Create(Model model)
        {
            await repo.Create(model);
        }

        public void Delete(string id)
        {
            var model = repo.GetModels().FirstOrDefault(x => x.Id == id);
             repo.Delete(model);
        }

        public List<Model> GetModels()
        {
            return repo.GetModels().ToList();

        }

        public List<ModelSelectedFilter> GetModelsFiltered()
        {
            var models = repo.GetModels();

            var modelsFiltered = models.Where(x => x.Producer.Country == "Germany")
                                      .Select(x => new ModelSelectedFilter{ Id = x.Id, Name = x.Name })
                                      .ToList();
            return modelsFiltered;
        }

        public List<ModelSelectedFilter> GetModelsFilteredOrdered()
        {
            var modelsFiltered = GetModelsFiltered();

            var modelsFilteredOrdered = modelsFiltered.OrderBy(x => x.Name).ToList();

            return modelsFilteredOrdered;
        }

        public List<string> GetModelsIds()
        {
            return repo.GetModelsIds().ToList();
        }

        public List<Model> GetModelsWithJoin()
        {
            return repo.GetModelsWithJoin().ToList();
        }

        public async Task Update(ModelModel model)
        {
            var mod = repo.GetModels()
                         .FirstOrDefault(x => x.Id == model.Id);
            mod.Name = model.Name;

            await repo.Update(mod);
        }
    }
}
