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
    public class ProducerManager: IProducerManager
    {
        private readonly IProducerRepository repo;
        private readonly IMapper mapper;

        public ProducerManager(IProducerRepository repo)
        {
            this.repo = repo;
        }

        public async Task Create(Producer producer)
        {
            await repo.Create(producer);
        }

        public void Delete(string id)
        {
            var producer = repo.GetProducers().FirstOrDefault(x => x.Id == id);
            repo.Delete(producer);
        }

        public async Task Update(ProducerModel producerModel)
        {
            //var mod = repo.GetProducers()
            //             .FirstOrDefault(x => x.Id == producerModel.Id);
            //mod.Name = producerModel.Name;

            var mod = mapper.Map<ProducerModel, Producer>(producerModel);
            await repo.Update(mod);
        }

        public List<ProducerModel> GetProducerFilteredOrdered()
        {
            var producers = repo.GetProducers();

            var producerFiltered = producers.Where(x => x.Country == "Black")
                                      //.Select(x => new ProducerModel { Id = x.Id, Name = x.Name })
                                      .Select(x => mapper.Map<Producer, ProducerModel>(x))
                                      .OrderBy(x => x.Id)
                                      .ToList();
            return producerFiltered;
        }
    }
}
