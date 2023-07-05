using System;
using ConsoleTables;

namespace Store
{
    public class Client : Person,IDataControl
    {
        public int ID {get; set;}
        public string Phone {get; set;}

        public Client(int id, string name, string cpf, string phone) :base(name,cpf)
        {
            ID = id;
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

                Client newClient = new Client(store.clients.Count + 1, clientName, clientCPF, clientPhone);
                store.clients.Add(newClient);

                JsonFileUtils.writeToJson(store.clients, "json/clients.json");
            } 
            catch(Exception e)
            {
                throw new ArgumentException($"[Error] Collect client data: {e}");
            }         
        }

        public static void listData(Store store)
        {
            Console.WriteLine("== Clientes DISPONÍVEIS ==");
            var table = new ConsoleTable("ID","Nome","CPF","Telefone"); 
            store.clients.ForEach(client => {
                table.AddRow(client.ID, client.Name, client.CPF, client.Phone);
            });
            table.Write();
        }
    
        public static Client findByID(Store store)
        {
            Console.Clear();
            Client.listData(store);
            Console.WriteLine("Selecione cliente pela ID: ");
            int.TryParse(Console.ReadLine(), out int clientID);
            Client matchedClient = store.clients.Find(c => c.ID == clientID);
            return matchedClient;         
        }
    }
}