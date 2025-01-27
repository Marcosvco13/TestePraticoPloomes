using AutoMapper;
using Microsoft.AspNetCore.Components.Forms;
using TestePraticoPloomes.Models;
using TestePraticoPloomes.Resources;

namespace TestePraticoPloomes.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Livros, LivrosResource>();
        }
    }
}
