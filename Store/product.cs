using System;
using Newtonsoft.Json;
using ConsoleTables;

namespace Store
{
    public class Product : IDataControl
    {
        public int ID {get; set;}
        public string Name {get; set;}
        public float Price {get; set;}

        public Product(int id, string name, float price)
        {
            ID = id;
            Name = name;
            Price = price;
        }

        public static void collectData(Store store)
        {   
            try
            {
                Console.Clear();
                Console.WriteLine("Cadastro de Produto:");

                /* Console.Write("ID do produto: ");
                int productID; 
                int.TryParse(Console.ReadLine(), out productID); */

                Console.Write("Nome do produto: ");
                string productName = store.NullString(Console.ReadLine());

                Console.Write("Preço do produto: ");
                float productPrice;
                float.TryParse(Console.ReadLine(), out productPrice);

                Product newProduct = new Product(store.products.Count + 1, productName, productPrice);
                store.products.Add(newProduct);

                JsonFileUtils.writeToJson(store.products, "json/products.json");
            }
            catch(Exception e)
            {
                throw new ArgumentException($"[Error] Collect product data: {e}");
            } 
           
        }

        public static void listData(Store store)
        {
            Console.WriteLine("== PRODUTOS DISPONÍVEIS ==");            
            var table = new ConsoleTable("ID","Nome","Preço"); 
            store.products.ForEach(product => {
                table.AddRow(product.ID, product.Name, product.Price);
            });
            table.Write();
        }

        public static Product findByID(Store store)
        {
            Console.Clear();
            Product.listData(store);
            Console.WriteLine("Selecione produto pela ID: ");
            int.TryParse(Console.ReadLine(), out int productID);
            Product matchedProduct = store.products.Find(p => p.ID == productID);

            return matchedProduct; 
        }
    }
}