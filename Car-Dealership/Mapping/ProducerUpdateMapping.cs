using AutoMapper;
using Project.Entities;
using Project.Models;

namespace Daw_marire.Mapping
{
    public class ProducerUpdateMapping : Profile
    {
        public ProducerUpdateMapping()
        {
            CreateMap<ProducerModel, Producer>();
        }
    }
}
