using Project.Entities;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Managers
{
    public interface IProducerManager
    {
        List<ProducerModel> GetProducerFilteredOrdered();
        Task Create(Producer producer);
        Task Update(ProducerModel producerModel);
        void Delete(string id);
    }
}
