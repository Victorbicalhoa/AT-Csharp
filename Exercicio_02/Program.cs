using System;

class Program
{
    static void Main(string[] args)
    {
        // Solicita o nome completo ao usuário
        Console.WriteLine("Digite seu nome completo:");
        string nome = Console.ReadLine();

        // Remove espaços e transforma em letras maiúsculas para simplificar o processamento
        nome = nome.Replace(" ", "").ToUpper();

        // Cria um array para armazenar o resultado
        char[] resultado = new char[nome.Length];

        // Desloca cada letra do nome
        for (int i = 0; i < nome.Length; i++)
        {
            char letra = nome[i];

            // Verifica se o caractere é uma letra
            if (char.IsLetter(letra))
            {
                // Desloca duas posições à frente no alfabeto
                char novaLetra = (char)(letra + 2);

                // Se ultrapassar 'Z', volta ao início do alfabeto
                if (novaLetra > 'Z')
                {
                    novaLetra = (char)(novaLetra - 26);
                }

                resultado[i] = novaLetra;
            }
        }

        // Converte o array em uma string e exibe o resultado
        Console.WriteLine("Nome codificado:");
        Console.WriteLine(new string(resultado));
    }
}