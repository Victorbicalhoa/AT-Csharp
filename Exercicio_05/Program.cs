using System;

class Program
{
    static void Main()
    {
        // Define a data de formatura no código
        DateTime dataFormatura = new DateTime(2028, 06, 15);

        // Solicita ao usuário a data atual
        Console.Write("Digite a data atual (dd/MM/yyyy): ");
        string entradaDataAtual = Console.ReadLine();

        // Tenta converter a entrada para o formato correto
        if (DateTime.TryParseExact(entradaDataAtual, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime dataAtual))
        {
            // Verifica se a data atual não está no futuro
            if (dataAtual > DateTime.Now)
            {
                Console.WriteLine("Erro: A data informada não pode ser no futuro!");
                return;
            }

            // Calcula a diferença entre as datas
            TimeSpan diferenca = dataFormatura - dataAtual;

            if (diferenca.TotalDays > 0)
            {
                // Calcula anos, meses e dias restantes
                int anos = diferenca.Days / 365;
                int meses = (diferenca.Days % 365) / 30;
                int dias = (diferenca.Days % 365) % 30;

                Console.WriteLine($"Faltam {anos} anos, {meses} meses e {dias} dias para sua formatura!");

                // Mensagem especial para menos de 6 meses
                if (diferenca.TotalDays <= 180)
                {
                    Console.WriteLine("A reta final chegou! Prepare-se para a formatura!");
                }
            }
            else
            {
                Console.WriteLine("Parabéns! Você já deveria estar formado!");
            }
        }
        else
        {
            Console.WriteLine("Data inválida. Certifique-se de usar o formato dd/MM/yyyy.");
        }
    }
}