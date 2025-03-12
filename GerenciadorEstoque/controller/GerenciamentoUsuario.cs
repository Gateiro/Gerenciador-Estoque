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
                public List<Venda> GerarRelatorioVendas()
        {
            var vendas = new List<Venda>();
            using (var sqliteConn = new SqliteConnection(connectionString))
            {
                sqliteConn.Open();
                string sql = "SELECT Id, ClienteCPF, ClienteNome, ProdutoId, QuantidadeVendida, Valor FROM Pedidos";
                using (var cmd = new SqliteCommand(sql, sqliteConn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var venda = new Venda
                            {
                                Id = reader.GetInt32(0),
                                ClienteCPF = reader.GetString(1),
                                ClienteNome = reader.GetString(2),
                                ProdutoId = reader.GetInt32(3),
                                QuantidadeVendida = reader.GetInt32(4),
                                Valor = reader.GetDouble(5)
                            };
                            vendas.Add(venda);
                        }
                    }
                }
            }
            return vendas;
        }
    }

    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Perfil { get; set; }
        public string Senha { get; set; }
    }

    public class Venda
    {
        public int Id { get; set; }
        public string ClienteCPF { get; set; }
        public string ClienteNome { get; set; }
        public int ProdutoId { get; set; }
        public int QuantidadeVendida { get; set; }
        public double Valor { get; set; }
    }
}

    }
}

