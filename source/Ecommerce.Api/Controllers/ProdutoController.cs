using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Application.Interfaces;
using Ecommerce.Application.ViewModel;
using Ecommerce.Domain.Validation;
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
        [ProducesResponseType(typeof(ProdutoViewModel), 201)]
        [ProducesResponseType(typeof(ProdutoViewModel), 400)]
        public ActionResult Adicionar([FromBody] ProdutoViewModel produtoViewModel)
        {
            try
            {
                ValidationResult validation = _service.Add(produtoViewModel);

            }
            catch (Exception)
            {
                return BadRequest("ERRO AO CADASTRAR O PRODUTO!");
            }

            return Ok();
        }

        [HttpPut]
        [Route("Atualizar")]
        [ProducesResponseType(typeof(ProdutoViewModel), 201)]
        [ProducesResponseType(typeof(ProdutoViewModel), 400)]
        public ActionResult Atualizar([FromBody] ProdutoViewModel produtoViewModel)
        {
            try
            {
                ValidationResult validation = _service.Update(produtoViewModel);

            }
            catch (Exception)
            {
                return BadRequest("ERRO AO ATUALIZAR O PRODUTO!");
            }

            return Ok();
        }

        [HttpPost]
        [Route("Deletar")]
        [ProducesResponseType(typeof(ProdutoViewModel), 201)]
        [ProducesResponseType(typeof(ProdutoViewModel), 400)]
        public ActionResult Deletar([FromBody] ProdutoViewModel produtoViewModel)
        {
            try
            {
                ValidationResult validation = _service.Delete(produtoViewModel);

            }
            catch (Exception)
            {
                return BadRequest("ERRO AO CADASTRAR O PRODUTO!");
            }

            return Ok();
        }

        [HttpGet]
        [Route("GetAll")]
        public IEnumerable<ProdutoViewModel> GetAll()
        {
            return _service.GetAll();
        }

        [HttpGet]
        [Route("GetById/{id:int}")]
        public ProdutoViewModel GetById(int id)
        {
            return _service.GetById(id);
        }
    }
}
