using Microsoft.Data.Sqlite;

public void InitializeDatabase()
{
    if (!File.Exists("estoque.db"))
    {
        SQLitePCL.raw.sqlite3_open("estoque.db", out var conn); // Corrigido para usar SQLitePCL.raw.sqlite3_open
        using (var sqliteConn = new SqliteConnection(connectionString))
        {
            sqliteConn.Open();
            // Criação das tabelas
            string sqlProdutos = @"CREATE TABLE Produtos (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Nome TEXT NOT NULL,
                Codigo TEXT UNIQUE NOT NULL,
                Preco REAL NOT NULL,
                Quantidade INTEGER NOT NULL
            );";
            new SqliteCommand(sqlProdutos, sqliteConn).ExecuteNonQuery();

            string sqlUsuarios = @"CREATE TABLE Usuarios (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Nome TEXT NOT NULL,
                Perfil TEXT NOT NULL,
                Senha TEXT NOT NULL
            );";
            new SqliteCommand(sqlUsuarios, sqliteConn).ExecuteNonQuery();

            string sqlPedidos = @"CREATE TABLE Pedidos (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                ClienteCPF TEXT NOT NULL,
                ClienteNome TEXT NOT NULL,
                ProdutoId INTEGER NOT NULL,
                QuantidadeVendida INTEGER NOT NULL,
                Valor REAL NOT NULL,
                FOREIGN KEY(ProdutoId) REFERENCES Produtos(Id)
            );";
            new SqliteCommand(sqlPedidos, sqliteConn).ExecuteNonQuery();

            // Insere usuário admin padrão
            string sqlAdmin = "INSERT INTO Usuarios (Nome, Perfil, Senha) VALUES ('admin', 'Admin', 'admin123')";
            new SqliteCommand(sqlAdmin, sqliteConn).ExecuteNonQuery();
        }
    }
}
