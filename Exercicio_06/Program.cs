using System;

class Aluno
{
    // Propriedades da classe
    public string Nome { get; set; }
    public string Matricula { get; set; }
    public string Curso { get; set; }
    public double MediaNotas { get; set; }

    // Método para exibir os dados do aluno
    public void ExibirDados()
    {
        Console.WriteLine("Dados do Aluno:");
        Console.WriteLine($"Nome: {Nome}");
        Console.WriteLine($"Matrícula: {Matricula}");
        Console.WriteLine($"Curso: {Curso}");
        Console.WriteLine($"Média das Notas: {MediaNotas:F2}");
    }

    // Método para verificar aprovação
    public string VerificarAprovacao()
    {
        return MediaNotas >= 7 ? "Aprovado" : "Reprovado";
    }
}

class Program
{
    static void Main()
    {
        // Criação do objeto com seus próprios dados
        Aluno aluno = new Aluno
        {
            Nome = "Victor Bicalho",
            Matricula = "12345",
            Curso = "Engenharia de Software",
            MediaNotas = 8.5
        };

        // Exibição dos dados do aluno
        aluno.ExibirDados();

        // Verificação de aprovação
        Console.WriteLine($"Status: {aluno.VerificarAprovacao()}");
    }
}