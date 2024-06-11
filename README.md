Aqui será colocado tudo que o Gerentarefa propoe a fazer e como será feito, como a estrutura de classes e como será feito a manipulação
de dados

# Funcionalidades

## Adicionar Tarefa

- A tarefa deve ter um título, uma descrição e uma data de vencimento.
- A tarefa deve ser automaticamente marcada como "não concluída" ao ser criada.

## Listar Tarefas

- Listar todas as tarefas, mostrando o título, a descrição, a data de vencimento e o status (concluída ou não).

## Editar Tarefa

- Permitir que o usuário edite o título, a descrição e a data de vencimento de uma tarefa existente.

## Remover Tarefa

## Marcar como Concluída

# Persistência de Dados

- Salvar a lista de tarefas em um arquivo quando a aplicação for fechada.
- Carregar a lista de tarefas do arquivo quando a aplicação for iniciada.

# Estrutura do Projeto

## Classes

- **Tarefa:** Representa uma tarefa com propriedades para título, descrição, data de vencimento e status.
- **GerenciadorDeTarefas:** Gerencia a lista de tarefas e implementa as funcionalidades para adicionar, editar, remover e listar tarefas.
- **PersistenciaDeDados:** Lida com a leitura e escrita das tarefas em um arquivo.

# Interface do Usuário

- Utilize a console para interagir com o usuário, exibindo um menu com as opções disponíveis e capturando a entrada do usuário.

# Passo a Passo

## Criação do Projeto

- Crie um novo projeto de console em C#.

## Definição da Classe Tarefa

- Defina a classe Tarefa com as propriedades necessárias.

## Implementação do Gerenciador de Tarefas

- Implemente a classe GerenciadorDeTarefas com métodos para adicionar, editar, remover e listar tarefas.

## Persistência de Dados

- Implemente a classe PersistenciaDeDados com métodos para salvar e carregar as tarefas de um arquivo.

## Interface do Usuário

- Implemente a interação com o usuário através do console, permitindo que o usuário navegue pelas opções do menu e execute as ações desejadas.
