using Project.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Repositories
{
    public interface IProducerRepository
    {
        IQueryable<Producer> GetProducers();
        IQueryable<Producer> GetProducersWithJoin();
        Task Create(Producer producers);
        Task Update(Producer producers);
        void Delete(Producer producers);
    }
}
