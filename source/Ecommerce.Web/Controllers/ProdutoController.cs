using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ecommerce.Web.Controllers
{
    public class ProdutoController : Controller
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public ProdutoController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        // GET: /<controller>/
        public IActionResult Produto()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Adicionar([FromBody] Produto produto)
        {
            try
            {

                var client = _httpClientFactory.CreateClient("ECOMMERCE_API");

                string json = JsonConvert.SerializeObject(produto);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = client.PostAsync(client.BaseAddress + "produto/adicionar", content).Result;

                if (response.IsSuccessStatusCode)
                    return Json("Sucesso");
                else
                {
                    ModelState.AddModelError(string.Empty, "Erro ao atualizar produto");
                    return Json("Error");
                }
            }
            catch (Exception ex)
            {
                return Json("Error");
            }


        }

        [HttpPut]
        public JsonResult Atualizar([FromBody] Produto produto)
        {
            try
            {

                var client = _httpClientFactory.CreateClient("ECOMMERCE_API");

                string json = JsonConvert.SerializeObject(produto);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = client.PutAsync(client.BaseAddress + "produto/atualizar", content).Result;

                if (response.IsSuccessStatusCode)
                    return Json("Sucesso");
                else
                {
                    ModelState.AddModelError(string.Empty, "Erro ao atualizar produto");
                    return Json("Error");
                }
            }
            catch (Exception ex)
            {
                return Json("Error");
            }


        }

        [HttpDelete]
        public JsonResult Deletar([FromBody] Produto produto)
        {
            try
            {

                var client = _httpClientFactory.CreateClient("ECOMMERCE_API");

                string json = JsonConvert.SerializeObject(produto);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = client.PostAsync(client.BaseAddress + "produto/deletar", content).Result;

                if (response.IsSuccessStatusCode)
                    return Json("Sucesso");
                else
                {
                    ModelState.AddModelError(string.Empty, "Erro ao atualizar produto");
                    return Json("Error");
                }
            }
            catch (Exception ex)
            {
                return Json("Error");
            }


        }

        public async Task<JsonResult> GetAll()
        {
            List<Produto> produtos = new List<Produto>();

            try
            {

                var client = _httpClientFactory.CreateClient("ECOMMERCE_API");

                var response = await client.GetAsync(client.BaseAddress + "produto/getall");
                if(response.IsSuccessStatusCode)
                    produtos = await response.Content.ReadAsAsync<List<Produto>>();
                else
                    ModelState.AddModelError(string.Empty, "Erro ao consultar produtos");

            }
            catch(Exception ex)
            {

            }

            return Json(produtos);
        }

        public async Task<JsonResult> GetById(int id)
        {
            Produto produto = new Produto();

            try
            {

                var client = _httpClientFactory.CreateClient("ECOMMERCE_API");

                var response = await client.GetAsync(client.BaseAddress + "produto/getbyid/" + id);
                if (response.IsSuccessStatusCode)
                    produto = await response.Content.ReadAsAsync<Produto>();
                else
                    ModelState.AddModelError(string.Empty, "Erro ao consultar produto");

            }
            catch (Exception ex)
            {

            }

            return Json(produto);
        }
    }
}
