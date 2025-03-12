using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorPedidos.controller
{
    public class GerenciamentoProduto
    {
        private string connectionString = "Data Source=estoque.db";

        private bool VerificarSeAdmin(string nomeUsuario)
        {
            using (var sqliteConn = new SqliteConnection(connectionString))
            {
                sqliteConn.Open();
                string sql = "SELECT Perfil FROM Usuarios WHERE Nome = @Nome";
                using (var cmd = new SqliteCommand(sql, sqliteConn))
                {
                    cmd.Parameters.AddWithValue("@Nome", nomeUsuario);
                    var perfil = cmd.ExecuteScalar()?.ToString();
                    return perfil == "Administrador";
                }
            }
        }

        public void AdicionarProduto(string nomeUsuario, string nomeProduto, double preco, int quantidade)
        {
            if (!VerificarSeAdmin(nomeUsuario))
            {
                Console.WriteLine("Permissão negada. Apenas administradores podem adicionar produtos.");
                return;
            }

            using (var sqliteConn = new SqliteConnection(connectionString))
            {
                sqliteConn.Open();
                string sql = "INSERT INTO Produtos (Nome, Preco, Quantidade) VALUES (@Nome, @Preco, @Quantidade)";
                using (var cmd = new SqliteCommand(sql, sqliteConn))
                {
                    cmd.Parameters.AddWithValue("@Nome", nomeProduto);
                    cmd.Parameters.AddWithValue("@Preco", preco);
                    cmd.Parameters.AddWithValue("@Quantidade", quantidade);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void AlterarProduto(string nomeUsuario, int produtoId, string novoNome, double novoPreco, int novaQuantidade)
        {
            if (!VerificarSeAdmin(nomeUsuario))
            {
                Console.WriteLine("Permissão negada. Apenas administradores podem alterar produtos.");
                return;
            }

            using (var sqliteConn = new SqliteConnection(connectionString))
            {
                sqliteConn.Open();
                string sql = "UPDATE Produtos SET Nome = @Nome, Preco = @Preco, Quantidade = @Quantidade WHERE Id = @Id";
                using (var cmd = new SqliteCommand(sql, sqliteConn))
                {
                    cmd.Parameters.AddWithValue("@Nome", novoNome);
                    cmd.Parameters.AddWithValue("@Preco", novoPreco);
                    cmd.Parameters.AddWithValue("@Quantidade", novaQuantidade);
                    cmd.Parameters.AddWithValue("@Id", produtoId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void RemoverProduto(string nomeUsuario, int produtoId)
        {
            if (!VerificarSeAdmin(nomeUsuario))
            {
                Console.WriteLine("Permissão negada. Apenas administradores podem remover produtos.");
                return;
            }

            using (var sqliteConn = new SqliteConnection(connectionString))
            {
                sqliteConn.Open();
                string sql = "DELETE FROM Produtos WHERE Id = @Id";
                using (var cmd = new SqliteCommand(sql, sqliteConn))
                {
                    cmd.Parameters.AddWithValue("@Id", produtoId);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}