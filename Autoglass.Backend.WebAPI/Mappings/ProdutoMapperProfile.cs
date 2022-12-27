using Autoglass.Backend.Application.Produtos.Dto;
using Autoglass.Backend.Core.Entities;
using Autoglass.Backend.WebAPI.Models;
using AutoMapper;

namespace Autoglass.Backend.WebAPI.Mappings
{
    public class ProdutoMapperProfile : Profile
    {
        public ProdutoMapperProfile()
        {
            CreateMap<ProdutoInput, Produto>();
            CreateMap<ProdutoInput, ProdutoInputDto>();
        }
    }
}
