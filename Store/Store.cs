using System;
using Newtonsoft.Json;

namespace Store
{
    public class Store
    {
        public List<Client> clients {get; set; }
        public List<Employee> employees {get; set; }
        public List<CashRegister> cashRegisters {get; set; }
		public List<Product> products {get; set; }
        public List<Purchase> purchases {get; set; }

        public Store()
        {
            clients = new List<Client>();
            employees = new List<Employee>();
            cashRegisters = new List<CashRegister>();
            products = new List<Product>();
            purchases = new List<Purchase>();
        }

        public void shop(Store store)
        {
            Employee activeEmployee = Employee.findByID(store);
            CashRegister activeCashRegister = CashRegister.findByID(store);

            string option;
            do
            {                
                Console.Clear();
                Console.WriteLine("Compras: ");
                Console.WriteLine("Selecione uma opção:");
                Console.WriteLine("1 - Iniciar compra");
                Console.WriteLine("2 - Consulta");
                Console.WriteLine("0 - Sair");

                option = NullString(Console.ReadLine());
                switch (option)
                {
                    case "1":
                        Purchase.collectData(store, activeEmployee, activeCashRegister);
                        break;
                    case "2":
                        Console.Clear();
                        Purchase.listData(store);
                        Console.ReadLine();
                        break;
                    case "0":
                        Console.WriteLine("Fechando caixa...");
                        break;
                    default:
                        Console.WriteLine("Opção inválida! Pressione qualquer tecla para continuar...");
                        Console.ReadKey();
                        break;
                }
            } while(option != "0");

        }

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

                if (File.Exists("json/cashRegisters.json"))
                {
                    cashRegisters = JsonConvert.DeserializeObject<List<CashRegister>>(File.ReadAllText("json/cashRegisters.json"));				
                }

                if (File.Exists("json/products.json"))
                {
                    products = JsonConvert.DeserializeObject<List<Product>>(File.ReadAllText("json/products.json"));				
                }

                if(File.Exists("json/purchases.json"))
                {
                    purchases = JsonConvert.DeserializeObject<List<Purchase>>(File.ReadAllText("json/purchases.json"));
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
                        Console.Clear();
                        Employee.listData(store);
                        Console.ReadLine();
                        break;

                    case "2":
                        Console.Clear();
                        Client.listData(store);
                        Console.ReadLine();
                        break;

                    case "3":
                        Console.Clear();
                        CashRegister.listData(store);
                        Console.ReadLine();
                        break;

                    case "4":
                        Console.Clear();
                        Product.listData(store);
                        Console.ReadLine();
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