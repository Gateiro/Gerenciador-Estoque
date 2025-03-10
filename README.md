# Gerenciador de Estoque  

Projeto desenvolvido para a UC8 do Senac Sorocaba.  

## 📌 Objetivo Geral  
Desenvolver uma aplicação desktop para gerenciamento de estoque com interface gráfica em C#, utilizando conceitos de usabilidade, programação orientada a eventos, conexão com banco de dados SQLite, e técnicas de teste e versionamento.  

## 🚀 Funcionalidades do Sistema  
- **Cadastro de Produtos:** Adição de produtos com os campos: Nome, Código (único), Preço e Quantidade em estoque.  
- **Alteração de Produtos:** Permite modificar o preço e a quantidade dos produtos.  
- **Remoção de Produtos:** Administradores podem excluir produtos do estoque.  
- **Gerenciamento de Usuários:** Administração de perfis (Admin e Vendedor) com controle de acesso baseado no perfil.  
- **Registro de Vendas:** Impacta diretamente o estoque e registra os dados do cliente (CPF e Nome).  

## 🏗️ Estrutura do Projeto  
A estrutura do código segue uma organização modular para facilitar a manutenção e expansão:  

- `CadastroUsuarios.cs` → Formulário para cadastro de novos usuários.  
- `alteracaoProdutos.cs` → Formulário para alteração de preço e quantidade dos produtos.  
- `cadastroProdutos.cs` → Formulário para adicionar novos produtos no estoque.  
- `remocaoProdutos.cs` → Formulário para remoção de produtos existentes no estoque.  
- `classes.cs` → Contém as classes principais utilizadas no projeto, como `Produto` e `Usuario`.  
- `tabelas.cs` → Responsável pela criação e manutenção das tabelas no banco de dados SQLite.  

## 🗃️ Banco de Dados SQLite  
O sistema utiliza um banco de dados SQLite com as seguintes tabelas:  

- **`Produtos`** → `Id`, `Nome`, `Codigo`, `Preco`, `Quantidade`.  
- **`Usuarios`** → `Id`, `Nome`, `Perfil (Admin/Vendedor)`, `Senha`.  
- **`Pedidos`** → `Id`, `ClienteCPF`, `ClienteNome`, `ProdutoId`, `QuantidadeVendida`, `Valor`.  

## 🔄 Lógica de Negócio  
- **Cadastro de Produtos:** Apenas Administradores podem cadastrar novos produtos.  
- **Alteração e Remoção de Produtos:** Restringido a Administradores.  
- **Registro de Vendas:** Acesso disponível para Admins e Vendedores, com atualização automática do estoque.  
- **Controle de Acesso:** Implementado por autenticação de usuários com diferentes níveis de permissão.  

## 🛠️ Tecnologias Utilizadas  
- **Linguagem:** C#  
- **Banco de Dados:** SQLite  
- **IDE:** Visual Studio  
- **Versionamento:** Git/GitHub  
- **Interface Gráfica:** Windows Forms  

## ⚙️ Configuração e Execução  

### 📌 Pré-requisitos:  
- .NET Framework ou .NET Core SDK instalado.  
- SQLite integrado ao projeto.  

### 🏃‍♂️ Passos para Executar o Projeto:  
```bash
# 1. Clone o repositório:
git clone https://github.com/Gateiro/Gerenciador-Estoque.git

# 2. Abra o projeto no Visual Studio.

# 3. Restaure os pacotes NuGet, se necessário.

# 4. Compile e execute o projeto:

# Pressione F5 ou utilize o menu de execução.
# 📊 Gerar relatórios:
# Implementar funcionalidade para visualizar estoque e movimentações.

### Próximos passos: 

# 🔍 Implementar filtros:
# Adicionar buscas de produtos por nome ou categoria.

# 🎨 Melhorar o design da interface gráfica.

# 🧪 Implementar testes automatizados.

### Autores:

# Matheus, Thaiane, Maiara, João, Daniel e Bruno.
