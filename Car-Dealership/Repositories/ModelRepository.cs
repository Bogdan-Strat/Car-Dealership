using Microsoft.EntityFrameworkCore;
using Project.Entities;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Repositories
{
    public class ModelRepository : IModelRepository
    {
        private readonly ModelContext db;

        public ModelRepository(ModelContext db)
        {
            this.db = db;
        }

        public IQueryable<Model> GetModels()
        {
            var models = db.Model;

            return models;
        }

        public IQueryable<string> GetModelsIds()
        {
            var modelsIds = db.Model.Select(x => x.Id);

            return modelsIds;
        }

        public IQueryable<Model> GetModelsWithJoin()
        {
            var modelsJoin = db.Model
                .Include(x => x.Producer);

            return modelsJoin;
        }

        public async Task Create(Model model)
        {
            await db.Model.AddAsync(model);

            await db.SaveChangesAsync();
        }

        public async Task Update(Model model)
        {
            db.Model.Update(model);

            await db.SaveChangesAsync();
        }

        public void Delete(Model model)
        {
            db.Model.Remove(model);

             db.SaveChangesAsync();
        }
    }
}
