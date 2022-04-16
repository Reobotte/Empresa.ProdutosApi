using AutoMapper;
using Empresa.ProdutosApi.ApplicationServices.ValueObjects;
using Empresa.ProdutosApi.Domains.CQRS.Commands.ProdutoCommands;
using Empresa.ProdutosApi.Domains.Entities.Interfaces;

namespace Empresa.ProdutosApi.ApplicationServices.AutoMapper.Profiles
{
    public class ProdutoProfile : Profile
    {
        public ProdutoProfile()
        {
            CreateMap<ProdutoVo, IncluirProdutoCommand>().ReverseMap();
            CreateMap<ProdutoIdVo, IncluirProdutoCommand>().ReverseMap();
            CreateMap<ProdutoIdVo, AlterarProdutoCommand>().ReverseMap();
            CreateMap<ProdutoIdVo, ExcluirProdutoCommand>().ReverseMap();

            CreateMap<IProduto, ProdutoIdVo>().ReverseMap();
            CreateMap<ProdutoIdVo, ProdutoVo>().ReverseMap();

            CreateMap<ProdutoCategoriaVo, IProduto>().ReverseMap();
            CreateMap<ProdutoCategoriaVo, ProdutoIdVo>().ReverseMap();            
        }
    }
}
