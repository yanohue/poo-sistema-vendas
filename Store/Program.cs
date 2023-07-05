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

            string option;
            do
            {
                Console.Clear();
                Console.WriteLine("Bem-vindo à Loja");
                Console.WriteLine("Selecione uma opção:");
                Console.WriteLine("1 - Cadastro");
                Console.WriteLine("2 - Consulta");
                Console.WriteLine("3 - Venda");
                Console.WriteLine("0 - Sair");

                option = store.NullString(Console.ReadLine());

                switch (option)
                {
                    case "1":
                        store.registerToDatase(store);
                        break;

                    case "2":
                        store.queryToDatabase(store);
                        break;

                    case "3":
                        store.shop(store);
                        break;

                    case "0":
                        Console.WriteLine("Encerrando o sistema...");
                        JsonFileUtils.writeToJson(store.employees, "json/employees.json");
                        JsonFileUtils.writeToJson(store.clients, "json/clients.json");
                        JsonFileUtils.writeToJson(store.cashRegisters, "json/cashRegisters.json");
                        JsonFileUtils.writeToJson(store.products, "json/products.json");
                        JsonFileUtils.writeToJson(store.purchases, "json/purchases.json");
                        break;

                    default:
                        Console.WriteLine("Opção inválida! Pressione qualquer tecla para continuar...");
                        Console.ReadKey();
                        break;
                }
            } while(option != "0");
        }
    }
}