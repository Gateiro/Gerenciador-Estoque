# Gerenciador de Estoque

## Objetivo Geral
Desenvolver uma aplicação desktop para gerenciamento de estoque com interface gráfica em C#, utilizando conceitos de usabilidade, programação orientada a eventos, conexão com banco de dados SQLite, e técnicas de teste e versionamento.

## Funcionalidades do Sistema
- **Cadastro de Produtos:** Permite o cadastro de produtos com os campos: Nome, Código (único), Preço e Quantidade em estoque.
- **Remoção de Produtos:** Possibilita a exclusão de produtos do estoque pelo administrador.
- **Alteração de Produtos:** Permite a alteração do preço e da quantidade dos produtos.
- **Gerenciamento de Perfis de Usuário:** Administração de perfis de usuário (Admin e Vendedor) com controle de acesso baseado no perfil.
- **Registro de Vendas:** Realiza vendas que impactam diretamente o estoque, registrando o CPF e nome do cliente.

## Estrutura do Projeto
- **CadastroUsuarios.cs:** Formulário para cadastro de novos usuários.
- **alteracaoProdutos.cs:** Formulário para alteração de preço e quantidade dos produtos.
- **cadastroProdutos.cs:** Formulário para cadastro de novos produtos no estoque.
- **remocaoProdutos.cs:** Formulário para remoção de produtos existentes no estoque.
- **classes.cs:** Contém as classes principais utilizadas no projeto, como Produto e Usuario.
- **tabelas.cs:** Responsável pela criação e manutenção das tabelas no banco de dados SQLite.

## Banco de Dados SQLite - Tabelas
- **Produtos:** Campos: Id, Nome, Codigo, Preco, Quantidade.
- **Usuarios:** Campos: Id, Nome, Perfil (Admin/Vendedor), Senha.
- **Pedidos:** Campos: Id, ClienteCPF, ClienteNome, ProdutoId, QuantidadeVendida, Valor.

## Lógica de Negócio
- **Cadastro de Produtos:** Apenas usuários com perfil de Admin podem cadastrar novos produtos.
- **Alteração e Remoção de Produtos:** Restritas ao perfil Admin.
- **Registro de Vendas:** Disponível para ambos os perfis, com atualização automática do estoque e registro dos dados do cliente.
- **Controle de Acesso:** Implementado através de autenticação de usuários com diferentes níveis de permissão.

## Ferramentas e Tecnologias
- **Linguagem:** C#
- **Banco de Dados:** SQLite
- **IDE:** Visual Studio
- **Ferramentas de Versionamento:** Git/GitHub
- **Interface Gráfica:** Windows Forms

## Etapas do Projeto
- **Planejamento e Modelagem:** Definição dos requisitos detalhados do sistema.
- **Desenvolvimento da Interface Gráfica:** Construção dos formulários e integração com eventos.
- **Implementação da Conexão com SQLite:** Criação do banco de dados e implementação das operações CRUD.
- **Funcionalidades de Login e Perfis:** Implementação do controle de acesso para Admin e Vendedor.
- **Registro de Vendas:** Desenvolvimento da lógica de vendas com atualização do estoque.
- **Testes e Melhorias:** Aplicação de testes manuais e automatizados para garantir o funcionamento básico.
- **Versionamento e Documentação:** Uso do Git/GitHub para controle de versão e criação da documentação básica do sistema.

## Configuração e Execução

### Pré-requisitos:
- .NET Framework ou .NET Core SDK instalado.
- SQLite integrado ao projeto.

### Passos para Executar o Projeto:
1. Clone o repositório:
2. Abra o projeto no Visual Studio.
3. Restaure os pacotes NuGet, se necessário.
4. Compile e execute o projeto pressionando F5 ou através do menu de execução.

## Próximos Passos
- Adicionar relatórios para visualizar o estoque atual e movimentações.
- Implementar filtros para buscar produtos por nome ou categoria.
- Melhorar o design da interface gráfica.
- Implementar testes automatizados para as principais funcionalidades.

## Licença
Este projeto é distribuído sob a licença MIT. Consulte o arquivo LICENSE para mais detalhes.

Para mais informações, visite o repositório oficial: [https://github.com/Gateiro/Gerenciador-Estoque](https://github.com/Gateiro/Gerenciador-Estoque)
