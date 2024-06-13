using System;
using System.Threading;
using System.IO;
using System.Collections.Generic;


namespace Principal
{

    public class Principal
    {
        private string Titulo;
        static private int op { get; set; }
        static private bool X = true;


        public static void Main(string[] args)
        {
            Arquivos NovoArqTarefa = new Arquivos();

            NovoArqTarefa.criarPasta();


            Console.WriteLine("Bem vindo ao gerenciador de tarefas: \n Selecione a opção que gostaria de fazer\n");
            do
            {
                Console.Clear();
                Console.WriteLine("1--- Criar uma tarefa\n2--- Ver tarefas existentes\n3--- Modificar Tarefa\n4--- Apagar Tarefas\n0--- sair do aplicativo ");
                op = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                switch (op)
                {

                    case 0:
                        Console.WriteLine("Saindo do aplicativo");
                        X = false;
                        break;

                    case 1:

                        Console.WriteLine("Escreva o titulo da tarefa a ser anotado:");
                        NovoArqTarefa.criarArquivo();
                        break;

                    case 2:

                        Arquivos Listar = new Arquivos();
                        Listar.ListarTarefas();
                        break;
                    case 4:
                        Arquivos Deletar = new Arquivos();
                        Deletar.deleteTarefa();

                        break;

                    default:
                        Console.WriteLine("Insira um valor valido(0 a 4)");
                        break;


                }
            } while (X);



        }
    }
    public class Arquivos
    {
        private string tituloTarefa;
        private string conteudo;
        public const string Diretoriobase = @"C:\Tarefas-gerentarefas";

        // Metodo que cria a pasta
        public void criarPasta()
        {
            try
            {
                if (!Directory.Exists(Diretoriobase))
                {
                    Directory.CreateDirectory(Diretoriobase);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("ocorreu um erro ao criar a pasta:" + e.Message);
            }
        }
        // Metoodo para criar o Arquivo atribuindo o nome do titulo
        public void criarArquivo()
        {
        refazerTarefa:
            tituloTarefa = AdicionarTitulo();
            string CaminhoArquivo = Path.Combine(Diretoriobase, tituloTarefa + ".txt");


            if (!File.Exists(CaminhoArquivo))
            {
                using (StreamWriter Sw = new StreamWriter(CaminhoArquivo))
                {
                    Console.WriteLine("Agora escreva o conteudo da tarefa criada");
                    Sw.WriteLine(tituloTarefa + "\n" + AdicionarConteudo());
                    Console.WriteLine("conteudo salvo");

                }
            }
            else
            {
                Console.WriteLine("já existe uma tarefa com este nome ");
                goto refazerTarefa;
            }
        }
        public string AdicionarTitulo()
        {
            Console.WriteLine("Insira o titulo para operação");
            tituloTarefa = Console.ReadLine();
            return tituloTarefa;


        }
        public string AdicionarConteudo()
        {
            conteudo = Console.ReadLine();
            return conteudo;


        }

        public void deleteTarefa()
        {
            do
            {
                tituloTarefa = AdicionarTitulo();
                string CaminhoArquivo = Path.Combine(Diretoriobase, tituloTarefa + ".txt");
                if (File.Exists(CaminhoArquivo))
                {
                    File.Delete(CaminhoArquivo);
                    Console.WriteLine("Tarefa apagada, pressione qualquer botão para ser redirecionado a tela inicial");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                }
                else
                {
                    string X;
                    Console.WriteLine("o arquivo não existe, quer tentar buscar novamente ou retornar?(0 ou 1)");
                    X = Console.ReadLine();
                    if (X == "n")
                    {
                        break;

                    }



                }
            } while (true);


        }

        public void ListarTarefas()
        {

            if (Directory.Exists(Diretoriobase))
            {
                string[] arquivos = Directory.GetFiles(Diretoriobase, "*.txt");
                if (arquivos.Length > 0)
                {
                    Console.WriteLine("Tarefas salvas:");

                    foreach (string arquivo in arquivos)
                    {
                        string titulo = Path.GetFileNameWithoutExtension(arquivo);
                        string conteudo = File.ReadAllText(arquivo);
                        Console.WriteLine("\n----------------------------");
                        Console.WriteLine($"Título: {titulo}");
                        Console.WriteLine($"Conteúdo: {conteudo}");
                        Console.WriteLine("----------------------------\n");
                    }

                    Buscar:
                    Console.WriteLine("Quer fazer alguma busca ou sair da lista?");
                    string buscar= Console.ReadLine();
                    Console.Clear();
                    if (buscar == "S")
                    {
                        string tituloB = AdicionarTitulo();
                        foreach (string arquivo in arquivos)
                        {
                            string ArquivoNome=Path.GetFileNameWithoutExtension(arquivo);
                            if(tituloB == ArquivoNome){
                        string conteudo = File.ReadAllText(arquivo);
                        Console.WriteLine("\n----------------------------");
                        Console.WriteLine($"Título: {ArquivoNome}");
                        Console.WriteLine($"Conteúdo: {conteudo}");
                        Console.WriteLine("----------------------------\n");

                            }
                            
                           
                            

                        }
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.WriteLine("não há arquivos salvos   ");
                }
            }
        }



    }

}


