using Microsoft.EntityFrameworkCore;
using Project.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Repositories
{
    public class ProducerRepository: IProducerRepository
    {
        private readonly ModelContext db;

        public  ProducerRepository(ModelContext db)
        {
            this.db = db;
        }

        public async Task Create(Producer producers)
        {
            await db.Producer.AddAsync(producers);

            await db.SaveChangesAsync();
        }

        public void Delete(Producer producers)
        {
            db.Producer.Remove(producers);

            db.SaveChangesAsync();
        }

        public async Task Update(Producer producers)
        {
            db.Producer.Update(producers);

            await db.SaveChangesAsync();
        }


        public IQueryable<Producer> GetProducers()
        {
            var producer = db.Producer;

            return producer;
        }

        public IQueryable<Producer> GetProducersWithJoin()
        {
            var producerJoin = db.Producer
                .Include(x => x.Model);

            return producerJoin;
        }

    }
}
