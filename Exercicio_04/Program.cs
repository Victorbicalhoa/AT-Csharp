using System;

class Program
{
    static void Main(string[] args)
    {
        // Solicita a data de nascimento ao usuário
        Console.WriteLine("Digite sua data de nascimento (formato: dd/mm/aaaa):");
        if (!DateTime.TryParse(Console.ReadLine(), out DateTime dataNascimento))
        {
            Console.WriteLine("Data inválida! Certifique-se de usar o formato correto.");
            return;
        }

        // Obtém a data atual
        DateTime hoje = DateTime.Now;

        // Calcula o próximo aniversário
        DateTime proximoAniversario = new DateTime(hoje.Year, dataNascimento.Month, dataNascimento.Day);

        // Se o próximo aniversário já tiver passado, ajusta para o ano seguinte
        if (proximoAniversario < hoje)
        {
            proximoAniversario = proximoAniversario.AddYears(1);
        }

        // Calcula o intervalo de dias
        int diasFaltando = (proximoAniversario - hoje).Days;

        // Exibe a quantidade de dias faltando
        Console.WriteLine($"Faltam {diasFaltando} dias para seu próximo aniversário!");

        // Mensagem especial se faltar menos de 7 dias
        if (diasFaltando < 7)
        {
            Console.WriteLine("Está chegando! Prepare-se para comemorar!");
        }
    }
}