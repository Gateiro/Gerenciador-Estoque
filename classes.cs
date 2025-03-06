using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqLite;

namespace GerenciadorEstoque
{
    internal class classes
    {
        public class Produto
        {
            public int Id { get; set; }
            public string Nome { get; set; }
            public string Codigo { get; set; }
            public decimal Preco { get; set; }
            public int Quantidade { get; set; }
        }

        public class Usuario
        {
            public int Id { get; set; }
            public string Nome { get; set; }
            public string Perfil { get; set; }
            public string Senha { get; set; }
        }

        public class Pedido
        {
            public int Id { get; set; }
            public string ClienteCPF { get; set; }
            public string ClienteNome { get; set; }
            public int ProdutoId { get; set; }
            public int QuantidadeVendida { get; set; }
            public decimal Valor { get; set; }
        }
    }
}
