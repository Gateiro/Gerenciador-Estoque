using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorPedidos.controller
{
    public class GerenciamentoUsuario
    {
        private string connectionString = "Data Source=estoque.db";

        public void AdicionarUsuario(string nome, string perfil, string senha)
        {
            using (var sqliteConn = new SqliteConnection(connectionString))
            {
                sqliteConn.Open();
                string sql = "INSERT INTO Usuarios (Nome, Perfil, Senha) VALUES (@Nome, @Perfil, @Senha)";
                using (var cmd = new SqliteCommand(sql, sqliteConn))
                {
                    cmd.Parameters.AddWithValue("@Nome", nome);
                    cmd.Parameters.AddWithValue("@Perfil", perfil);
                    cmd.Parameters.AddWithValue("@Senha", senha);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void RemoverUsuario(int id)
        {
            using (var sqliteConn = new SqliteConnection(connectionString))
            {
                sqliteConn.Open();
                string sql = "DELETE FROM Usuarios WHERE Id = @Id";
                using (var cmd = new SqliteCommand(sql, sqliteConn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
    public class RegistroVendas
    {
        private string connectionString = "Data Source=estoque.db";

        public void RegistrarVenda(string clienteCPF, string clienteNome, int produtoId, int quantidadeVendida, double valor)
        {
            using (var sqliteConn = new SqliteConnection(connectionString))
            {
                sqliteConn.Open();
                string sql = "INSERT INTO Pedidos (ClienteCPF, ClienteNome, ProdutoId, QuantidadeVendida, Valor) VALUES (@ClienteCPF, @ClienteNome, @ProdutoId, @QuantidadeVendida, @Valor)";
                using (var cmd = new SqliteCommand(sql, sqliteConn))
                {
                    cmd.Parameters.AddWithValue("@ClienteCPF", clienteCPF);
                    cmd.Parameters.AddWithValue("@ClienteNome", clienteNome);
                    cmd.Parameters.AddWithValue("@ProdutoId", produtoId);
                    cmd.Parameters.AddWithValue("@QuantidadeVendida", quantidadeVendida);
                    cmd.Parameters.AddWithValue("@Valor", valor);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}

