using System;
using Newtonsoft.Json;
using ConsoleTables;

namespace Store
{
    public class Client : Person
    {
        public string Phone {get; set;}

        public Client(string name, string cpf, string phone) :base(name,cpf)
        {
            Phone = phone;
        }

        public static void collectData(Store store)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Cadastro de Cliente:");

                Console.Write("Nome: ");
                string clientName = store.NullString(Console.ReadLine());

                Console.Write("CPF: ");
                string clientCPF = store.NullString(Console.ReadLine());

                Console.Write("Telefone: ");
                string clientPhone = store.NullString(Console.ReadLine());

                Client newClient = new Client(clientName, clientCPF, clientPhone);
                store.clients.Add(newClient);

                Client.saveData(store); 
            } 
            catch(Exception e)
            {
                throw new ArgumentException($"[Error] Collect client data: {e}");
            }         
        }

        public static new void saveData(Store store)
        {
            File.WriteAllText("json/clients.json", JsonConvert.SerializeObject(store.clients));
        }

        public static void listData(Store store)
        {
            var table = new ConsoleTable("Nome","CPF","Telefone"); 
            Console.Clear();
            store.clients.ForEach(client => {
                table.AddRow(client.Name, client.CPF, client.Phone);
            });
            table.Write();
            Console.ReadLine();
        }
    }
}