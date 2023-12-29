using System;
class Program
{
    static void Main()
    {
        int P = int.Parse(Console.ReadLine());
        Personagem[] personagens = new Personagem[P];
        for (int i = 0; i < P; i++)
        {
            string[] atributos = Console.ReadLine().Split(';');
            string nome = atributos[0];
            int altura = atributos[1] == "unknown" ? 0 : int.Parse(atributos[1]);
            double peso = atributos[2] == "unknown" ? 0 : double.Parse(atributos[2]);
            string corDoCabelo = atributos[3];
            string corDaPele = atributos[4];
            string corDosOlhos = atributos[5];
            string anoNascimento = atributos[6];
            string genero = atributos[7];
            string homeworld = atributos[8];
            Personagem personagem = new Personagem(nome, altura, peso, corDoCabelo, corDaPele, corDosOlhos, anoNascimento, genero, homeworld);
            personagens[i] = personagem;
        }
        int C = int.Parse(Console.ReadLine());
        for (int i = 0; i < C; i++)
        {
            string[] consulta = Console.ReadLine().Split(' ');
            string atributo = consulta[0];
            string valor = consulta[1];
            string valor2 = atributo == ("altura") ? consulta[2] : " ";
            string valor3 = atributo == ("peso") ? consulta[2] : " ";
            int quantidade = ConsultaAtributo(personagens, atributo, valor,valor2,valor3);
            Console.WriteLine($"{atributo} {quantidade}");
        }
    }
    static int ConsultaAtributo(Personagem[] personagens, string atributo, string valor,string valor2,string valor3)
    {
        int count = 0;
        foreach (var personagem in personagens)
        {
            if (personagem != null && personagem.ConsultaAtributo(atributo, valor,valor2,valor3))
                count++;
        }
        return count;
    }
}

public class Personagem
{
    private string nome;
    private int altura;
    private double peso;
    private string corDoCabelo;
    private string corDaPele;
    private string corDosOlhos;
    private string anoNascimento;
    private string genero;
    private string homeworld;
    public Personagem(string nome, int altura, double peso, string corDoCabelo, string corDaPele, string corDosOlhos, string anoNascimento, string genero, string homeworld)
    {
        this.nome = nome;
        this.altura = altura;
        this.peso = peso;
        this.corDoCabelo = corDoCabelo;
        this.corDaPele = corDaPele;
        this.corDosOlhos = corDosOlhos;
        this.anoNascimento = anoNascimento;
        this.genero = genero;
        this.homeworld = homeworld;
    }
    public bool ConsultaAtributo(string atributo, string valor,string valor2,string valor3)
    {
        switch (atributo)
        {
            case "nome":
                return nome.Equals(valor);
            case "altura":
                int valorInt = int.Parse(valor);
                int valorInt2 = int.Parse(valor2);
                return altura >= valorInt && altura <= valorInt2;
            case "peso":
                double valorDouble = double.Parse(valor);
                double valorDouble2 = double.Parse(valor3);
                return peso >= valorDouble && peso <= valorDouble2;
            case "corDoCabelo":
                return corDoCabelo.Equals(valor);
            case "corDaPele":
                return corDaPele.Equals(valor);
            case "corDosOlhos":
                return corDosOlhos.Equals(valor);
            case "anoNascimento":
                return anoNascimento.Equals(valor);
            case "genero":
                return genero.Equals(valor);
            case "homeworld":
                return homeworld.Equals(valor);
            default:
                return false;
        }
    }
}