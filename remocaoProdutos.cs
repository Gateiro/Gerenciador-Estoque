using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqLite;

namespace GerenciadorEstoque
{
    public class remocaoProdutos
    {
        public void RemoverProduto(int id)
        {
            string connectionString = "Data Source=estoque.db;Version=3;";
            using (var connection = new SqLiteConnection(connectionString))
            {
                connection.Open();
                string deleteProduct = "DELETE FROM Produtos WHERE Id = @Id";
                using (var command = new SQLiteCommand(deleteProduct, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }
    }
}
