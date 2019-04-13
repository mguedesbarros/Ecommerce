using System;
using AutoMapper;
using Ecommerce.Application.ViewModel;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ProdutoViewModel, Produto>();

        }
    }
}
