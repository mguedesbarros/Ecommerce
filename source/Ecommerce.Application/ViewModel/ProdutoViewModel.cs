using System;
namespace Ecommerce.Application.ViewModel
{
    public class ProdutoViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Tipo { get; set; }
        public string Tamanho { get; set; }
        public int Quantidade { get; set; }
        public double Valor { get; set; }
        public string Descricao { get; set; }

    }
}
