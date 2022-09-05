using AutoMapper;
using Project.Entities;
using Project.Models;

namespace Daw_marire.Mapping
{
    public class ModelUpdateMapping : Profile
    {
        public ModelUpdateMapping()
        {
            CreateMap<ModelModel, Model>()
                .ForMember(m => m.Id, o => o.MapFrom(mo => mo.Id))
                .ForMember(m => m.Colour, o => o.MapFrom(mo => mo.Colour))
                .ForMember(m => m.Name, o => o.MapFrom(mo => mo.Name));
        }
    }
}
