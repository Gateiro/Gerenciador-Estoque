using System;
using Microsoft.Data.SqLite;

class tabelas
{
    static void Main()
    {
        string connectionString = "Data Source=estoque.db;Version=3;";
        using (var connection = new sqLiteConnection(connectionString))
        {
            connection.Open();

            string criarTabelaProdutos = @"
                CREATE TABLE IF NOT EXISTS Produtos (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Nome TEXT NOT NULL,
                    Codigo TEXT UNIQUE NOT NULL,
                    Preco REAL NOT NULL,
                    Quantidade INTEGER NOT NULL
                );";

            string criarTabelaUsuarios = @"
                CREATE TABLE IF NOT EXISTS Usuarios (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Nome TEXT NOT NULL,
                    Perfil TEXT NOT NULL,
                    Senha TEXT NOT NULL
                );";

            string criarTabelaPedidos = @"
                CREATE TABLE IF NOT EXISTS Pedidos (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    ClienteCPF TEXT NOT NULL,
                    ClienteNome TEXT NOT NULL,
                    ProdutoId INTEGER NOT NULL,
                    QuantidadeVendida INTEGER NOT NULL,
                    Valor REAL NOT NULL,
                    FOREIGN KEY (ProdutoId) REFERENCES Produtos(Id)
                );";

            using (var command = new SqLiteCommand(criarTabelaProdutos, connection))
            {
                command.ExecuteNonQuery();
            }
            using (var command = new SqLiteCommand(criarTabelaUsuarios, connection))
            {
                command.ExecuteNonQuery();
            }
            using (var command = new SqLiteCommand(criarTabelaPedidos, connection))
            {
                command.ExecuteNonQuery();
            }

            connection.Close();
        }
    }
}