using System;

class ContaBancaria
{
    // Propriedade pública para o titular
    public string Titular { get; set; }

    // Campo privado para o saldo
    private decimal saldo;

    // Método para depositar um valor na conta
    public void Depositar(decimal valor)
    {
        if (valor > 0)
        {
            saldo += valor;
            Console.WriteLine($"Depósito de R$ {valor:F2} realizado com sucesso!");
        }
        else
        {
            Console.WriteLine("O valor do depósito deve ser positivo!");
        }
    }

    // Método para sacar um valor da conta
    public void Sacar(decimal valor)
    {
        if (valor <= saldo)
        {
            saldo -= valor;
            Console.WriteLine($"Saque de R$ {valor:F2} realizado com sucesso!");
        }
        else
        {
            Console.WriteLine("Saldo insuficiente para realizar o saque!");
        }
    }

    // Método para exibir o saldo atual
    public void ExibirSaldo()
    {
        Console.WriteLine($"Saldo atual: R$ {saldo:F2}");
    }
}

class Program
{
    static void Main()
    {
        // Criação do objeto ContaBancaria
        ContaBancaria conta = new ContaBancaria
        {
            Titular = "Victor Bicalho"
        };

        Console.WriteLine($"Titular: {conta.Titular}");

        // Simulação de transações
        conta.Depositar(500);
        conta.ExibirSaldo();

        Console.WriteLine("\nTentativa de saque: R$ 700,00");
        conta.Sacar(700);
        conta.ExibirSaldo();

        Console.WriteLine("\nSaque de R$ 200,00:");
        conta.Sacar(200);
        conta.ExibirSaldo();
    }
}