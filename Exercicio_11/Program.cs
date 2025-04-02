using System;
using System.IO;

class GerenciadorContatos
{
    static void Main()
    {
        const string NomeArquivo = "contatos.txt";

        while (true)
        {
            Console.WriteLine("\n=== Gerenciador de Contatos ===");
            Console.WriteLine("1 - Adicionar novo contato");
            Console.WriteLine("2 - Listar contatos cadastrados");
            Console.WriteLine("3 - Sair");
            Console.Write("Escolha uma opção: ");

            try
            {
                int opcao = int.Parse(Console.ReadLine());

                if (opcao == 1)
                {
                    AdicionarContato(NomeArquivo);
                }
                else if (opcao == 2)
                {
                    ListarContatos(NomeArquivo);
                }
                else if (opcao == 3)
                {
                    Console.WriteLine("Encerrando programa...");
                    break;
                }
                else
                {
                    Console.WriteLine("Opção inválida. Tente novamente.");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Erro: Você deve digitar um número válido.");
            }
        }
    }

    static void AdicionarContato(string nomeArquivo)
    {
        Console.Write("Nome: ");
        string nome = Console.ReadLine();
        Console.Write("Telefone: ");
        string telefone = Console.ReadLine();
        Console.Write("Email: ");
        string email = Console.ReadLine();

        // Gravar no arquivo
        try
        {
            using (StreamWriter escritor = File.AppendText(nomeArquivo))
            {
                escritor.WriteLine($"{nome},{telefone},{email}");
            }
            Console.WriteLine("Contato cadastrado com sucesso!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao salvar o contato: {ex.Message}");
        }
    }

    static void ListarContatos(string nomeArquivo)
    {
        if (!File.Exists(nomeArquivo))
        {
            Console.WriteLine("Nenhum contato cadastrado.");
            return;
        }

        try
        {
            string[] linhas = File.ReadAllLines(nomeArquivo);

            if (linhas.Length == 0)
            {
                Console.WriteLine("Nenhum contato cadastrado.");
                return;
            }

            Console.WriteLine("\nContatos cadastrados:");
            foreach (string linha in linhas)
            {
                string[] partes = linha.Split(',');
                Console.WriteLine($"Nome: {partes[0]} | Telefone: {partes[1]} | Email: {partes[2]}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao ler os contatos: {ex.Message}");
        }
    }
}