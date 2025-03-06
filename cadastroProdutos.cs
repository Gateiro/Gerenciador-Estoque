using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqLite;

namespace GerenciadorEstoque
{
    public class cadastroProdutos
    {
        public void CadastrarProduto(string nome, string codigo, double preco, int quantidade)
        {
            string connectionString = "Data Source=estoque.db;Version=3;";
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string insertProduct = "INSERT INTO Produtos (Nome, Codigo, Preco, Quantidade) VALUES (@Nome, @Codigo, @Preco, @Quantidade)";
                using (var command = new SQLiteCommand(insertProduct, connection))
                {
                    command.Parameters.AddWithValue("@Nome", nome);
                    command.Parameters.AddWithValue("@Codigo", codigo);
                    command.Parameters.AddWithValue("@Preco", preco);
                    command.Parameters.AddWithValue("@Quantidade", quantidade);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }
    }
}
