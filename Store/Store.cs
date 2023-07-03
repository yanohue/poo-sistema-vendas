using System;
using Newtonsoft.Json;

namespace Store
{
    public class Store
    {
        public List<Client> clients = new List<Client>();
        public List<Employee> employees = new List<Employee>();
        public List<CashRegister> cashRegisters = new List<CashRegister>();
		public List<Product> products = new List<Product>();

		public void loadData()
		{   
            try
            {   
                if (File.Exists("json/clients.json"))
                {
                    clients = JsonConvert.DeserializeObject<List<Client>>(File.ReadAllText("json/clients.json"));				
                }

                if (File.Exists("json/employees.json"))
                {

                    employees = JsonConvert.DeserializeObject<List<Employee>>(File.ReadAllText("json/employees.json"));				
                }

                if (File.Exists("json/cashRegiters.json"))
                {
                    cashRegisters = JsonConvert.DeserializeObject<List<CashRegister>>(File.ReadAllText("json/cashRegisters.json"));				
                }

                if (File.Exists("json/products.json"))
                {
                    products = JsonConvert.DeserializeObject<List<Product>>(File.ReadAllText("json/products.json"));				
                }
            }
            catch(Exception e)
            {
                throw new ArgumentException($"[Error] Load store data: {e}");
            }
		}

		public void registerToDatase(Store store)
        {
            string option;
            do
            {
                Console.Clear();
                Console.WriteLine("O que deseja cadastrar?");
                Console.WriteLine("1 - Funcionário");
                Console.WriteLine("2 - Cliente");
                Console.WriteLine("3 - Caixa");
                Console.WriteLine("4 - Produto");
                Console.WriteLine("0 - Sair");

                option = NullString(Console.ReadLine());
                switch (option)
                {
                    case "1":
                        Employee.collectData(store);
                        break;

                    case "2":
                        Client.collectData(store);
                        break;

                    case "3":
                        CashRegister.collectData(store);
                        break;

                    case "4":
                        Product.collectData(store);
                        break;

                    case "0":
                        Console.WriteLine("Voltando a tela anterior...");
                        break;

                    default:
                        Console.WriteLine("Opção inválida! Pressione qualquer tecla para continuar...");
                        Console.ReadKey();
                        break;
                }
            } while(option != "0"); 
        }

		public void queryToDatabase(Store store)
        {
            string option;
            do
            {
                Console.Clear();
                Console.WriteLine("O que deseja listar?");
                Console.WriteLine("1 - Funcionário");
                Console.WriteLine("2 - Cliente");
                Console.WriteLine("3 - Caixa");
                Console.WriteLine("4 - Produto");
                Console.WriteLine("0 - Sair");

                option = NullString(Console.ReadLine());
                switch (option)
                {
                    case "1":
                        Employee.listData(store);
                        break;

                    case "2":
                        Client.listData(store);
                        break;

                    case "3":
                        CashRegister.listData(store);
                        break;

                    case "4":
                        Product.listData(store);
                        break;

                    case "0":
                        Console.WriteLine("Voltando a pagina anterior...");
                        break;

                    default:
                        Console.WriteLine("Opção inválida! Pressione qualquer tecla para continuar...");
                        Console.ReadKey();
                        break;
                }
            } while(option != "0"); 
        }
        
        public string NullString(string? s){
        	if(s == null){
            	throw new ArgumentNullException(paramName: nameof(s), message: "[Error] This field can't be null");
            }else if(s == ""){
            	throw new ArgumentNullException(paramName: nameof(s), message: "[Error] This field can't be null");
            }
            else{
            	return s;
            }
		}

    }
}