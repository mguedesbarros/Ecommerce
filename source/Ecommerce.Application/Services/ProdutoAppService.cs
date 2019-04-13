using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Ecommerce.Application.Interfaces;
using Ecommerce.Application.ViewModel;
using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Interfaces.Services;
using Ecommerce.Domain.Validation;
using Ecommerce.Infra.Data.Context.Interfaces;

namespace Ecommerce.Application.Services
{
    public class ProdutoAppService : BaseAppService, IProdutoAppService
    {
        protected readonly IProdutoService _service;
        protected readonly IUnitOfWork _uow;

        public ProdutoAppService(IProdutoService service, IUnitOfWork unitOfWork)
        {
            this._service = service;
            this._uow = unitOfWork;
        }

        public ValidationResult Add(ProdutoViewModel produtoViewModel)
        {
            var produto = Mapper.Map<ProdutoViewModel, Produto>(produtoViewModel);

            _uow.BeginTransaction();

            ValidationResult.Add(_service.Add(produto));

            if (ValidationResult.IsValid) _uow.Commit();
            return ValidationResult;

        }

        public ValidationResult Delete(ProdutoViewModel produtoViewModel)
        {
            var produto = Mapper.Map<ProdutoViewModel, Produto>(produtoViewModel);

            _uow.BeginTransaction();

            ValidationResult.Add(_service.Delete(produto));

            if (ValidationResult.IsValid) _uow.Commit();
            return ValidationResult;
        }

        public IEnumerable<ProdutoViewModel> GetAll()
        {
            return Mapper.Map<IEnumerable<Produto>, IEnumerable<ProdutoViewModel>>(_service.GetAll());
        }

        public ProdutoViewModel GetById(int id)
        {
            return Mapper.Map<Produto, ProdutoViewModel>(_service.GetById(id));
        }

        public ValidationResult Update(ProdutoViewModel produtoViewModel)
        {
            var produto = Mapper.Map<ProdutoViewModel, Produto>(produtoViewModel);

            _uow.BeginTransaction();

            ValidationResult.Add(_service.Update(produto));

            if (ValidationResult.IsValid) _uow.Commit();
            return ValidationResult;
        }
    }
}
