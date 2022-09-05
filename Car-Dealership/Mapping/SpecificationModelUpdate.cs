using AutoMapper;
using Project.Entities;
using Project.Models;

namespace Daw_marire.Mapping
{
    public class SpecificationModelUpdate : Profile
    {
        public SpecificationModelUpdate()
        {
            CreateMap<SpecificationsModel, Specifications>()
                .ForMember(s => s.Engine, o => o.MapFrom(m => m.Engine));
        }
    }
}
