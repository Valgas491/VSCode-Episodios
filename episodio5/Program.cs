using System;
using System.Collections.Generic;
class Program
{   static void Main()
    {
        int P = int.Parse(Console.ReadLine());
        List<Personagem> personagens = new List<Personagem>();
        Stack<Personagem> personagempilha = new Stack<Personagem>();
        Queue<Personagem> personagemfila = new Queue<Personagem>();
        for (int i = 0; i < P; i++)
        {
            string[] atributos = Console.ReadLine().Split(';');
            string nome = atributos[0];
            string homeworld = atributos[8];
            Personagem personagem = new Personagem(nome,homeworld);
            personagens.Add(personagem);
        }
        int C = int.Parse(Console.ReadLine());
        for (int i = 0; i < C; i++)
        {
            string[] consulta = Console.ReadLine().Split(';');
            if(consulta[0] == "Push"){
                string valor = consulta[1];
                foreach(Personagem per in personagens)
                    if(per.Gethomeworld() == valor){personagempilha.Push(per);}
            }else if(consulta[0] == "Enqueue"){
                string valor = consulta[1];
                foreach(Personagem per in personagens)
                    if(per.Gethomeworld() == valor){personagemfila.Enqueue(per);}
            }else if(consulta[0] == "Pop"){
                string valor = (consulta[1]);
                int valor2 = valor == "all" ? personagempilha.Count : int.Parse(consulta[1]);
                for(int j = 0;j < valor2;j++){
                    Console.WriteLine(personagempilha.Pop().GetNome());
                }
            }else if(consulta[0] == "Dequeue"){
                string valor = consulta[1];
                int valor2 = valor == "all" ? personagemfila.Count : int.Parse(consulta[1]);
                for(int j = 0;j < valor2;j++){
                    Console.WriteLine(personagemfila.Dequeue().GetNome());
                }
            }else if(consulta[0] == "PesqBin"){
                string valor = consulta[1];
                string resposta = PesquisaBinaria(personagens,valor) == true ? "Ok" : "Nada";
                Console.WriteLine($"{valor} {resposta}");
            }
        }
    }
    static bool PesquisaBinaria(List<Personagem> lista, string nome){
        int esquerda = 0;
        int direita = lista.Count - 1;
        while (esquerda <= direita){
            int meio = (esquerda + direita) / 2;
            string nomeDoMeio = lista[meio].GetNome();
            int comparacao = string.Compare(nomeDoMeio, nome);
            if (comparacao == 0)
                return true; 
            else if (comparacao < 0)
                esquerda = meio + 1;
            else
                direita = meio - 1;
        }
        return false;
    }
}
public class Personagem{
    private string nome;
    private string homeworld;
    public Personagem(string nome,string homeworld)
    {
        this.nome = nome;
        this.homeworld = homeworld;
    }
    public string GetNome(){return nome;}
    public string Gethomeworld(){return homeworld;}
}