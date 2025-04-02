using System;

class Program
{
    static void Main(string[] args)
    {
        // Solicita os dois números ao usuário e valida a entrada
        Console.WriteLine("Digite o primeiro número:");
        if (!double.TryParse(Console.ReadLine(), out double numero1))
        {
            Console.WriteLine("Digite um número válido.");
            return;
        }

        Console.WriteLine("Digite o segundo número:");
        if (!double.TryParse(Console.ReadLine(), out double numero2))
        {
            Console.WriteLine("Digite um número válido.");
            return;
        }

        // Apresenta as opções de operação ao usuário
        Console.WriteLine("Escolha uma operação matemática:");
        Console.WriteLine("1 - Soma");
        Console.WriteLine("2 - Subtração");
        Console.WriteLine("3 - Multiplicação");
        Console.WriteLine("4 - Divisão");

        if (!int.TryParse(Console.ReadLine(), out int escolha) || escolha < 1 || escolha > 4)
        {
            Console.WriteLine("Digite 1, 2, 3 ou 4.");
            return;
        }

        // Realiza a operação escolhida e exibe o resultado
        double resultado;

        switch (escolha)
        {
            case 1:
                resultado = numero1 + numero2;
                Console.WriteLine($"Resultado da soma: {resultado}");
                break;
            case 2:
                resultado = numero1 - numero2;
                Console.WriteLine($"Resultado da subtração: {resultado}");
                break;
            case 3:
                resultado = numero1 * numero2;
                Console.WriteLine($"Resultado da multiplicação: {resultado}");
                break;
            case 4:
                if (numero2 == 0)
                {
                    Console.WriteLine("Divisão por zero não é permitida!");
                }
                else
                {
                    resultado = numero1 / numero2;
                    Console.WriteLine($"Resultado da divisão: {resultado}");
                }
                break;
        }
    }
}