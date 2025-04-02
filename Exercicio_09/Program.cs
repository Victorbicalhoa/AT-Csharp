using System;

class GerenciadorEstoque
{
    static void Main()
    {
        const int MaxProdutos = 5;
        string[] nomes = new string[MaxProdutos];
        int[] quantidades = new int[MaxProdutos];
        decimal[] precos = new decimal[MaxProdutos];
        int contador = 0;

        while (true)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Inserir Produto");
            Console.WriteLine("2. Listar Produtos");
            Console.WriteLine("3. Sair");
            Console.Write("Escolha uma opção: ");
            int opcao = int.Parse(Console.ReadLine());

            if (opcao == 1)
            {
                if (contador >= MaxProdutos)
                {
                    Console.WriteLine("Limite de produtos atingido!");
                    continue;
                }

                Console.Write("Nome do produto: ");
                nomes[contador] = Console.ReadLine();
                Console.Write("Quantidade em estoque: ");
                quantidades[contador] = int.Parse(Console.ReadLine());
                Console.Write("Preço unitário: ");
                precos[contador] = decimal.Parse(Console.ReadLine());
                contador++;
            }
            else if (opcao == 2)
            {
                if (contador == 0)
                {
                    Console.WriteLine("Nenhum produto cadastrado.");
                }
                else
                {
                    for (int i = 0; i < contador; i++)
                    {
                        Console.WriteLine($"Produto: {nomes[i]} | Quantidade: {quantidades[i]} | Preço: R$ {precos[i]:F2}");
                    }
                }
            }
            else if (opcao == 3)
            {
                Console.WriteLine("Saindo...");
                break;
            }
            else
            {
                Console.WriteLine("Opção inválida.");
            }
        }
    }
}