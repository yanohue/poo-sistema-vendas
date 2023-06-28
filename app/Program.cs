using System;


namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            Caixa caixa = new Caixa();

            int opcao; 
            do
            {
                Console.Clear();
                Console.WriteLine("Selecione uma opção:");
                Console.WriteLine("1 - Funcionários");
                Console.WriteLine("2 - Clientes");
                Console.WriteLine("3 - Produtos");
                Console.WriteLine("4 - Abrir Caixa");
                Console.WriteLine("0 - Sair");

                int.TryParse(Console.ReadLine(), out opcao);

                switch(opcao)
                {
                    case 1:

                        break;

                    case 2:

                        break;

                    case 3:

                        break;

                    case 4:
                        
                        break;
                    case 0:
                        Console.WriteLine("Encerrando o sistema...");
                        caixa.salvarDados();
                        break;
                    default:
                        Console.WriteLine("Opção inválida! Pressione qualquer tecla para continuar...");
                        Console.ReadKey();
                        break;
                }

            } while(opcao != 0);

        }
    }
}