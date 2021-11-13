using AutoMapper;
using NerdStore.Catalogo.Application.ViewModels;
using NerdStore.Catalogo.Domain;

namespace NerdStore.Catalogo.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Produto, ProdutoViewModel>()
                .ForMember(destinationMember: x => x.Largura, memberOptions: o => o.MapFrom(mapExpression: s => s.Dimensoes.Largura))
                .ForMember(destinationMember: x => x.Altura, memberOptions: o => o.MapFrom(mapExpression: s => s.Dimensoes.Altura))
                .ForMember(destinationMember: x => x.Profundidade, memberOptions: o => o.MapFrom(mapExpression: s => s.Dimensoes.Profundidade));
            CreateMap<Categoria, CategoriaViewModel>();
        }
    }
}
