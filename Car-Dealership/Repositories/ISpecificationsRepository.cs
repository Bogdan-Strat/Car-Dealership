using Project.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Repositories
{
    public interface ISpecificationsRepository
    {
        IQueryable<Specifications> GetSpecifications();
        IQueryable<Specifications> GetSpecificationsWithJoin();
        Task Create(Specifications specifications);
        Task Update(Specifications specifications);
        void Delete(Specifications specifications);
    }
}
