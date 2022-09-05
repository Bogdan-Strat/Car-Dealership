using AutoMapper;
using Project.Entities;
using Project.Models;

namespace Daw_marire.Mapping
{
    public class SpecificationModelForFilterMapping : Profile
    {
        public SpecificationModelForFilterMapping()
        {
            CreateMap<Specifications, SpecificationsModel>()
                .ForMember(s => s.HorsePower, o => o.Ignore());
        }
    }
}
