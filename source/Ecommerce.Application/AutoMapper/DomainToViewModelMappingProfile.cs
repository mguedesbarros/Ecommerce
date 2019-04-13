using System;
using AutoMapper;
using Ecommerce.Application.ViewModel;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Produto, ProdutoViewModel>();

        }
    }
}
