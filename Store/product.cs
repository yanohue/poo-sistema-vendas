using System;
using Newtonsoft.Json;
using ConsoleTables;

namespace Store
{
    public class Product : saveInterface
    {
        public int ID {get; set;}
        public string Name {get; set;}
        public float Price {get; set;}

        public Product(int id, string name, float price)
        {
            ID = ID;
            Name = name;
            Price = price;
        }

        public static void collectData(Store store)
        {   
            try
            {
                Console.Clear();
                Console.WriteLine("Cadastro de Produto:");

                Console.Write("ID do produto: ");
                int productID; 
                int.TryParse(Console.ReadLine(), out productID);

                Console.Write("Nome do produto: ");
                string productName = store.NullString(Console.ReadLine());

                Console.Write("Preço do produto: ");
                float productPrice;
                float.TryParse(Console.ReadLine(), out productPrice);

                Product newProduct = new Product(productID, productName, productPrice);
                store.products.Add(newProduct);

                Product.saveData(store);
            }
            catch(Exception e)
            {
                throw new ArgumentException($"[Error] Collect product data: {e}");
            } 
           
        }

        public static void saveData(Store store)
        {
            File.WriteAllText("json/products.json", JsonConvert.SerializeObject(store.products));
        }

        public static void listData(Store store)
        {
            var table = new ConsoleTable("ID","Nome","Preço"); 
            Console.Clear();
            store.products.ForEach(product => {
                table.AddRow(product.ID, product.Name, product.Price);
            });
            table.Write();
            Console.ReadLine();
        }
    }
}