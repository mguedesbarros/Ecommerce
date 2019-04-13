using System;
namespace Ecommerce.Domain.Entities
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Tipo { get; set; }
        public string Tamanho { get; set; }
        public int Quantidade { get; set; }
        public double Valor { get; set; }
        public string Descricao { get; set; }

        public Produto() { }
    }
}
