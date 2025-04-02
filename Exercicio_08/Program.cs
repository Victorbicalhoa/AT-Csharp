using System;

class Funcionario
{
    // Propriedades da classe Funcionario
    public string Nome { get; set; }
    public string Cargo { get; set; }
    public decimal SalarioBase { get; set; }

    // informações do funcionário
    public virtual void ExibirSalario()
    {
        Console.WriteLine($"Nome: {Nome}");
        Console.WriteLine($"Cargo: {Cargo}");
        Console.WriteLine($"Salário Base: R$ {SalarioBase:F2}");
    }
}

class Gerente : Funcionario
{
    // método para calcular o salário com bônus
    public override void ExibirSalario()
    {
        decimal salarioComBonus = SalarioBase + (SalarioBase * 0.20m); // 20% 
        Console.WriteLine($"Nome: {Nome}");
        Console.WriteLine($"Cargo: {Cargo} (Gerente)");
        Console.WriteLine($"Salário com Bônus: R$ {salarioComBonus:F2}");
    }
}

class Program
{
    static void Main()
    {
        // objeto Funcionario
        Funcionario funcionario = new Funcionario
        {
            Nome = "Carlos Silva",
            Cargo = "Analista",
            SalarioBase = 4000.00m
        };

        // objeto Gerente
        Gerente gerente = new Gerente
        {
            Nome = "Victor Bicalho",
            Cargo = "Gerente de Projetos",
            SalarioBase = 6000.00m
        };

        // informações do Funcionario
        Console.WriteLine("Informações do Funcionário:");
        funcionario.ExibirSalario();

        Console.WriteLine("\nInformações do Gerente:");
        // informações do Gerente
        gerente.ExibirSalario();
    }
}