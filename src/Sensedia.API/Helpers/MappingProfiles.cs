using AutoMapper;
using Sensedia.Core.DTO;
using Sensedia.Core.Entities;

namespace Sensedia.API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductToReturnDTO>()
                .ForMember(p => p.ProductName, o => o.MapFrom(x => x.Name))
                .ForMember(p => p.ProductPrice, o => o.MapFrom(x => x.Price))
                .ForMember(p => p.ProducDescription, o => o.MapFrom(x => x.Description))
                .ForMember(p => p.ProductBrand, o => o.MapFrom(x => x.ProductBrand.Name))
                .ForMember(p => p.ProductType, o => o.MapFrom(x => x.ProductType.Name));
        }

    }
}
