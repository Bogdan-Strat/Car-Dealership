using Microsoft.EntityFrameworkCore;
using Project.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Repositories
{
    public class SpecificationsRepository : ISpecificationsRepository
    {
        private readonly ModelContext db;

        public SpecificationsRepository(ModelContext db)
        {
            this.db = db;
        }

        public async Task Create(Specifications specifications)
        {
            await db.Specifications.AddAsync(specifications);

            await db.SaveChangesAsync();
        }

        public void Delete(Specifications specifications)
        {
            db.Specifications.Remove(specifications);

            db.SaveChangesAsync();
        }

        public IQueryable<Specifications> GetSpecifications()
        {
            var specifications = db.Specifications;

            return specifications;
        }

        public IQueryable<Specifications> GetSpecificationsWithJoin()
        {
            var modelsJoin = db.Specifications
                .Include(x => x.Model);

            return modelsJoin;
        }

        public async Task Update(Specifications specifications)
        {
            db.Specifications.Update(specifications);

            await db.SaveChangesAsync();
        }
    }
}
