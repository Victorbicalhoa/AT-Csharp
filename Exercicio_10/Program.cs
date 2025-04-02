using System;

class JogoAdivinhaNumero
{
    static void Main()
    {
        // Gerar número aleatório entre 1 e 50
        Random random = new Random();
        int numeroSecreto = random.Next(1, 51);
        int tentativasRestantes = 5;

        Console.WriteLine("Bem-vindo ao jogo de adivinhar o número!");
        Console.WriteLine("Você precisa adivinhar um número de 1 a 50.");
        Console.WriteLine($"Você tem {tentativasRestantes} tentativas. Boa sorte!");

        while (tentativasRestantes > 0)
        {
            try
            {
                Console.Write("\nDigite seu palpite: ");
                int palpite = int.Parse(Console.ReadLine());

                // Validar intervalo do número
                if (palpite < 1 || palpite > 50)
                {
                    Console.WriteLine("Erro: O número deve estar entre 1 e 50. Tente novamente.");
                    continue;
                }

                // Verificar se o palpite está correto
                if (palpite == numeroSecreto)
                {
                    Console.WriteLine($"Parabéns! Você acertou o número secreto ({numeroSecreto})!");
                    break;
                }
                else if (palpite < numeroSecreto)
                {
                    Console.WriteLine("O número secreto é maior.");
                }
                else
                {
                    Console.WriteLine("O número secreto é menor.");
                }

                tentativasRestantes--;

                if (tentativasRestantes > 0)
                {
                    Console.WriteLine($"Você ainda tem {tentativasRestantes} tentativa(s).");
                }
                else
                {
                    Console.WriteLine($"Fim de jogo! O número secreto era {numeroSecreto}.");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Erro: Você deve digitar um número inteiro válido. Tente novamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro inesperado: {ex.Message}. Tente novamente.");
            }
        }
    }
}