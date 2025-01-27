using AutoMapper;
using Microsoft.AspNetCore.Components.Forms;
using TestePraticoPloomes.Models;
using TestePraticoPloomes.Resources;

namespace TestePraticoPloomes.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveLivrosResource, Livros>();
        }
    }
}
