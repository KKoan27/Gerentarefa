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
        static private bool X=true;


        public static void Main(string[] args)
        {

        
            Console.WriteLine("Bem vindo ao gerenciador de tarefas: \n Selecione a opção que gostaria de fazer\n");
            do{
            Console.WriteLine("1--- Criar uma tarefa\n2--- Ver tarefas existentes\n 3--- Modificar Tarefa\n 4--- Apagar Tarefas\n  0--- sair do aplicativo ");
            op = Convert.ToInt32(Console.ReadLine());
            switch (op)
            {

                case 0: 
                Console.WriteLine("Saindo do aplicativo");
                X=false;
                break;
            
                case 1:
                    Arquivos NovoArqTarefa = new Arquivos();
                    Console.WriteLine("Escreva o titulo da tarefa a ser anotado:");
                    NovoArqTarefa.criarArquivo();
                    Console.WriteLine("Agora escreva o conteudo da tarefa criada");
                    
                    break;
                default:
                Console.WriteLine("Insira um valor valido(0 a 4)");
                break;

            }
           } while(X);
            


        }
    }
    public class Arquivos
    {

        Tarefa novaTarefa = new Tarefa();
        private string tituloTarefa;
        private string conteudoTarefa;
        public const string Diretoriobase = @"C:\Users\luanv\Documents\PROJETOS\Gerenciador de tarefas";

        // Criando Arquivo atribuindo o nome do titulo

        public void criarArquivo()
        {

            tituloTarefa = novaTarefa.AdicionarTitulo();
            string CaminhoArquivo = Path.Combine(Diretoriobase, tituloTarefa + ".txt");
            if (!File.Exists(CaminhoArquivo))
            {
                using (StreamWriter Sw= new StreamWriter(CaminhoArquivo))
                {
                     Sw.WriteLine(tituloTarefa + "\n" + novaTarefa.AdicionarConteudo());
                }
            }
            else
            {
                Console.WriteLine("já existe uma tarefa com este nome ");
            }
        }

       

    }
    public class Tarefa
    {

        public string tituloTarefa = "";
        public string conteudo = "";
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

    }

}


