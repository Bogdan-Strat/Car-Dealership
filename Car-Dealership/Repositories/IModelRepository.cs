using Project.Entities;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Repositories
{
    public interface IModelRepository
    {
        IQueryable<Model> GetModels();
        IQueryable<string> GetModelsIds();
        IQueryable<Model> GetModelsWithJoin();
        Task Create(Model model);
        Task Update(Model model);
        void Delete(Model model);
    }
}
