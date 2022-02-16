using Project.Entities;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Managers
{
    public interface IModelManager
    {
        List<Model> GetModels();
        List<string> GetModelsIds();
        List<Model> GetModelsWithJoin();
        List<ModelSelectedFilter> GetModelsFiltered();
        List<ModelSelectedFilter> GetModelsFilteredOrdered();
        Task Create(Model model);
        Task Update(ModelModel model);
        void Delete(string id);
    }
}
