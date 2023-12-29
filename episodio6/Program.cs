using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
class Program
{   static void Main()
    {
        int P = int.Parse(Console.ReadLine());
        List<Personagem> personagens = new List<Personagem>();
        for (int i = 0; i < P; i++)
        {
            string[] linha = Console.ReadLine().Split(';');
            personagens.Add(new Personagem(linha));
        }
        personagens = personagens.OrderBy(per => per.GetNome()).ToList();
        foreach(Personagem per in personagens){
            Console.WriteLine($"{per.GetNome()}-{per.Getaltura()}-{per.Getpeso()}-{per.GetcorDoCabelo()}-{per.GetcorDaPele()}-{per.GetcorDosOlhos()}-{per.GetanoNascimento()}-{per.Getgenero()}-{per.Gethomeworld()}");
        }
    }
}   
public class Personagem{
    private string nome;
    private string altura;
    private string peso;
    private string corDoCabelo;
    private string corDaPele;
    private string corDosOlhos;
    private string anoNascimento;
    private string genero;
    private string homeworld;
    public Personagem(string[] atributos)
    {
        this.nome =  atributos[0];
        this.altura = atributos[1] == "unknown" ?  "unknown" : atributos[1];
        this.peso = atributos[2] == "unknown" ? "unknown" : atributos[2];
        this.corDoCabelo = atributos[3];
        this.corDaPele = atributos[4];
        this.corDosOlhos = atributos[5];
        this.anoNascimento = atributos[6];
        this.genero = atributos[7];
        this.homeworld = atributos[8];
    }
    public string GetNome(){return nome;}
    public string Getaltura(){return altura;}
    public string Getpeso(){return peso;}
    public string GetcorDoCabelo(){return corDoCabelo;}
    public string GetcorDaPele(){return corDaPele;}
    public string GetcorDosOlhos(){return corDosOlhos;}
    public string GetanoNascimento(){return anoNascimento;}
    public string Getgenero(){return genero;}
    public string Gethomeworld(){return homeworld;}
}