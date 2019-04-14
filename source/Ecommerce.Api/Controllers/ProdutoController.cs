using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Ecommerce.Application.Interfaces;
using Ecommerce.Application.ViewModel;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ecommerce.Api.Controllers
{
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase
    {

        protected readonly IProdutoAppService _service;

        public ProdutoController(IProdutoAppService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("Adicionar")]
        [ProducesResponseType(typeof(ProdutoViewModel), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Adicionar([FromBody] ProdutoViewModel produtoViewModel)
        {
            try
            {
                ValidationResult validation = _service.Add(produtoViewModel);

                if (validation.IsValid)
                    Ok();
                else
                {
                    IList<ValidationFailure> failures = validation.Errors;

                    return BadRequest(failures);
                }

            }
            catch (Exception)
            {
                return BadRequest("ERRO AO CADASTRAR O PRODUTO!");
            }

            return Ok();
        }

        [HttpPut]
        [Route("Atualizar")]
        [ProducesResponseType(typeof(ProdutoViewModel), StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Atualizar([FromBody] ProdutoViewModel produtoViewModel)
        {
            try
            {
                ValidationResult validation = _service.Update(produtoViewModel);

                if (validation.IsValid)
                    Ok();
                else
                {
                    IList<ValidationFailure> failures = validation.Errors;

                    return BadRequest(failures);
                }

            }
            catch (Exception)
            {
                return BadRequest("ERRO AO ATUALIZAR O PRODUTO!");
            }

            return Ok();
        }

        [HttpPost]
        [Route("Deletar")]
        [ProducesResponseType(typeof(ProdutoViewModel), StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Deletar([FromBody] ProdutoViewModel produtoViewModel)
        {
            try
            {
                ValidationResult validation = _service.Delete(produtoViewModel);

                if (validation.IsValid)
                    Ok();
                else
                {
                    IList<ValidationFailure> failures = validation.Errors;

                    return BadRequest(failures);
                }

            }
            catch (Exception)
            {
                return BadRequest("ERRO AO DELETAR O PRODUTO!");
            }

            return Ok();
        }

        [HttpGet]
        [Route("GetAll")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<ProdutoViewModel>> GetAll()
        {
             var produtos = _service.GetAll();

            if(!produtos.Any())
                return NotFound();

            return Ok(produtos);
        }

        [HttpGet]
        [Route("GetById/{id:int}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ProdutoViewModel> GetById(int id)
        {
            ProdutoViewModel produto = _service.GetById(id);

            if(produto is null)
                return NotFound();

            return produto;

        }
    }
}
