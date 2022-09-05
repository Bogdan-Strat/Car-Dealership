using AutoMapper;
using Project.Entities;
using Project.Models;

namespace Daw_marire.Mapping
{
    public class ProducerModelMapping : Profile
    {
        public ProducerModelMapping()
        {
            CreateMap<Producer, ProducerModel>()
                .ForMember(p => p.Country, o => o.Ignore());
        }
    }
}
