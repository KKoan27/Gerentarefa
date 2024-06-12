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


            Console.WriteLine("Bem vindo ao gerenciador de tarefas: \n Selecione a opção que gostaria de fazer\n");
            do
            {
                Console.WriteLine("1--- Criar uma tarefa\n2--- Ver tarefas existentes\n 3--- Modificar Tarefa\n 4--- Apagar Tarefas\n  0--- sair do aplicativo ");
                op = Convert.ToInt32(Console.ReadLine());
                switch (op)
                {

                    case 0:
                        Console.WriteLine("Saindo do aplicativo");
                        X = false;
                        break;

                    case 1:
                        Arquivos NovoArqTarefa = new Arquivos();
                        Console.WriteLine("Escreva o titulo da tarefa a ser anotado:");
                        NovoArqTarefa.criarArquivo();
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
        public const string Diretoriobase = @"E:\Tarefas-gerentarefas";

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
            do{
                
            tituloTarefa = AdicionarTitulo();
            string CaminhoArquivo = Path.Combine(Diretoriobase, tituloTarefa + ".txt");
                if (File.Exists(tituloTarefa))
                {
                   
                    File.Delete(CaminhoArquivo);
                    break;
                }
                else
                {
                    Console.WriteLine(" o arquivo não existe");
                    Console.WriteLine(CaminhoArquivo);

                }
            } while(true);


        }

    }

}


