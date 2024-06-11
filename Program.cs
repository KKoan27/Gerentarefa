using System;
using System.Threading;
using System.IO;
using System.Collections.Generic;




namespace Principal{
    
    public class Principal{
                private string Titulo;

        public static void Main(string[] args){
            Console.WriteLine("ola mundo ");
        
        }
    }
    public class Arquivos{

        Tarefa novaTarefa= new Tarefa();
        public string tituloTarefa;
       public  const string Diretoriobase  = @"C:\Users\luanv\Documents\PROJ ETOS\Gerenciador de tarefas";        
       
        public void criarArquivo (){
        tituloTarefa=Console.ReadLine();
        
        string CaminhoArquivo= Path.Combine(Diretoriobase,tituloTarefa + ".txt");
        if(!File.Exists(CaminhoArquivo)){
            File.Create(CaminhoArquivo);
            }
        }

        public void escreverArquivo(){  
         File.AppendText(novaTarefa.AdicionarTitulo());
        
        }

    }
    public class Tarefa{
        
        public string tituloTarefa="";
        public string conteudo="";
        public string AdicionarTitulo(){
            tituloTarefa=Console.ReadLine();
            return tituloTarefa;    
            

        }
        public string AdicionarConteudo(){
            conteudo=Console.ReadLine();
            return conteudo;


        }
        
    }

}


