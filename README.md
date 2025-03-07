<h1>Gerenciador de Estoque</h1>

<div>
  <h2>Objetivo Geral</h2>
  <p>
    Desenvolver uma aplicação desktop de gerenciamento de estoque com interface gráfica em C#, utilizando conceitos de usabilidade, programação orientada a eventos, conexão com banco de dados SQLite, e técnicas de teste e versionamento.
  </p>
</div>

<div>
  <h2>💼 Regra de negócios</h2>
  <p>
    Até o momento o sistema é composto por quatro telas principais: Login, Cadastro de Usuários, Cadastro de Produtos e Registro de Vendas. <br>A tela de Cadastro de Usuários é exibida automaticamente caso não haja usuários salvos no banco de dados, permitindo a criação de um usuário inicial. A autenticação é feita por perfil (Admin ou Vendedor), com acesso restrito às funcionalidades de acordo com o nível de permissão. <br>Os perfis de usuário são implementados utilizando o conceito de herança, onde a classe base Usuario define atributos e métodos comuns, enquanto as classes derivadas Admin e Vendedor especializam comportamentos específicos. <br>O banco de dados SQLite armazena as tabelas de Produtos, Usuários e Pedidos, utilizando operações CRUD para gerenciar os dados. O código foi desenvolvido em C# com Windows Forms, seguindo boas práticas de programação, como tratamento de erros, validações e uso de transações para garantir a consistência dos dados. O controle de versão foi realizado via Git/GitHub.
  </p>
</div>

<div>
  <h2>Fluxo de Integração Completa</h2>
  <div>
    <h3>🪟 View:</h3>
    <p>
      O usuário interage com a interface (por exemplo, cadastra um produto).
    </p>
  </div>
  <div>
    <h3>🕹️ Controller:</h3>
    <p>
      Recebe a ação do usuário e chama o método correspondente no Service.
    </p>
  </div>
  <div>
    <h3>🧑🏽‍💻 Service:</h3>
    <p>
      Executa a lógica de negócio e chama o Repository para persistir os dados.
    </p>
  </div>
  <div>
    <h3>📀 Repository:</h3>
    <p>
      Acessa o banco de dados e salva ou recupera os dados.
    </p>
  </div>
  <div>
    <h3>📋 Instruções de uso:</h3>
    <p>
      - Baixe o repositório e localmente acesse o caminho <i>Gerenciador-Estoque/GerenciadorPedidos.sln</i> <br>- Execute o Visual Studio<br>- Abra o <i>Gerenciador de pacotes</i> procure por <i>Nuget</i> instale a extensão
    </p>
    <br><h3>💻 Inicialização:</h3>
    <p>
      - O programa irá iniciar pela criação do usuario  <br>- Os usuarios serão divididos entre <i>Admin/Vendedor</i><br>- Os dados são armazenados no banco de dados local <i>Nuget</i>
    </p>
  </div>
</div>
</div>
