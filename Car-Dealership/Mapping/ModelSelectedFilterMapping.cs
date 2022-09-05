using AutoMapper;
using Project.Entities;
using Project.Models;

namespace Daw_marire.Mapping
{
    public class ModelSelectedFilterMapping : Profile
    {
        public ModelSelectedFilterMapping()
        {
            CreateMap<Model, ModelSelectedFilter>();
        }
    }
}
