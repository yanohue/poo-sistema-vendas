using System;
using Newtonsoft.Json;
using ConsoleTables;

namespace Store
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Store store = new Store();
            store.loadData();

            int option;
            do
            {

                Console.Clear();
                Console.WriteLine("Bem-vindo à Loja");
                Console.WriteLine("Selecione uma opção:");
                Console.WriteLine("1 - Cadastro");
                Console.WriteLine("2 - Consulta");
                Console.WriteLine("3 - Venda");
                Console.WriteLine("4 - Financeiro");
                Console.WriteLine("0 - Sair");

                int.TryParse(Console.ReadLine(), out option);
                
                switch (option)
                {
                    case 1:
                        store.registerToDatase(store);
                        break;

                    case 2:
                        store.queryToDatabase(store);
                        break;

                    case 3:
                        // Continue here
                        break;

                    case 4:
                        
                        break;

                    case 0:
                        Console.WriteLine("Salvando informações...");

                        Employee.saveData(store);
                        Client.saveData(store);
                        Product.saveData(store);
                        CashRegister.saveData(store);

                        Console.WriteLine("Encerrando o sistema...");
                        break;
                        
                    default:
                        Console.WriteLine("Opção inválida! Pressione qualquer tecla para continuar...");
                        Console.ReadKey();
                        break;
                }
            } while(option != 0);
        }
    }
}