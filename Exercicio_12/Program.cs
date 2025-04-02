using System;
using System.Collections.Generic;
using System.IO;

class Contato
{
    public string Nome { get; set; }
    public string Telefone { get; set; }
    public string Email { get; set; }
}

abstract class ContatoFormatter
{
    public abstract void ExibirContatos(List<Contato> contatos);
}

class MarkdownFormatter : ContatoFormatter
{
    public override void ExibirContatos(List<Contato> contatos)
    {
        Console.WriteLine("\n## Lista de Contatos");
        foreach (var contato in contatos)
        {
            Console.WriteLine($"- **Nome:** {contato.Nome}");
            Console.WriteLine($"- 📞 Telefone: {contato.Telefone}");
            Console.WriteLine($"- 📧 Email: {contato.Email}\n");
        }
    }
}

class TabelaFormatter : ContatoFormatter
{
    public override void ExibirContatos(List<Contato> contatos)
    {
        Console.WriteLine("\n----------------------------------------");
        Console.WriteLine("| Nome          | Telefone       | Email           |");
        Console.WriteLine("----------------------------------------");

        foreach (var contato in contatos)
        {
            Console.WriteLine($"| {contato.Nome,-14} | {contato.Telefone,-14} | {contato.Email,-14} |");
        }

        Console.WriteLine("----------------------------------------");
    }
}

class RawTextFormatter : ContatoFormatter
{
    public override void ExibirContatos(List<Contato> contatos)
    {
        Console.WriteLine("\nContatos cadastrados:");
        foreach (var contato in contatos)
        {
            Console.WriteLine($"Nome: {contato.Nome} | Telefone: {contato.Telefone} | Email: {contato.Email}");
        }
    }
}

class GerenciadorContatos
{
    const string NomeArquivo = "contatos.txt";

    static void Main()
    {
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
                    AdicionarContato();
                }
                else if (opcao == 2)
                {
                    List<Contato> contatos = LerContatos();
                    if (contatos.Count == 0)
                    {
                        Console.WriteLine("Nenhum contato cadastrado.");
                        continue;
                    }

                    Console.WriteLine("\nEscolha o formato de exibição:");
                    Console.WriteLine("1 - Markdown");
                    Console.WriteLine("2 - Tabela");
                    Console.WriteLine("3 - Texto Puro");
                    Console.Write("Opção: ");
                    int formato = int.Parse(Console.ReadLine());

                    ContatoFormatter formatter = formato switch
                    {
                        1 => new MarkdownFormatter(),
                        2 => new TabelaFormatter(),
                        3 => new RawTextFormatter(),
                        _ => null
                    };

                    if (formatter != null)
                    {
                        formatter.ExibirContatos(contatos);
                    }
                    else
                    {
                        Console.WriteLine("Formato inválido.");
                    }
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

    static void AdicionarContato()
    {
        Console.Write("Nome: ");
        string nome = Console.ReadLine();
        Console.Write("Telefone: ");
        string telefone = Console.ReadLine();
        Console.Write("Email: ");
        string email = Console.ReadLine();

        try
        {
            using (StreamWriter escritor = File.AppendText(NomeArquivo))
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

    static List<Contato> LerContatos()
    {
        var contatos = new List<Contato>();

        if (!File.Exists(NomeArquivo))
        {
            return contatos;
        }

        try
        {
            string[] linhas = File.ReadAllLines(NomeArquivo);
            foreach (string linha in linhas)
            {
                string[] partes = linha.Split(',');
                if (partes.Length == 3)
                {
                    contatos.Add(new Contato { Nome = partes[0], Telefone = partes[1], Email = partes[2] });
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao ler os contatos: {ex.Message}");
        }

        return contatos;
    }
}