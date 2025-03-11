using System;
using Microsoft.Data.Sqlite;

namespace GerenciadorEstoque
{
    internal class alteracaoProduto
    {
        public void AlterarProduto(int id, double novoPreco, int novaQuantidade)
        {
            string connectionString = "Data Source=estoque.db;Version=3;";
            using (var connection = new SqLiteConnection(connectionString))
            {
                connection.Open();
                string updateProduct = "UPDATE Produtos SET Preco = @Preco, Quantidade = @Quantidade WHERE Id = @Id";
                using (var command = new SqLiteCommand(updateProduct, connection))
                {
                    command.Parameters.AddWithValue("@Preco", novoPreco);
                    command.Parameters.AddWithValue("@Quantidade", novaQuantidade);
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }
    }
}
