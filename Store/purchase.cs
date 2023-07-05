using System;
using ConsoleTables;

namespace Store
{
    public class Purchase : IDataControl
    {
        public int ID;
        public CashRegister Checkout;
        public Employee Cashier;
        public Client Customer;
        public List<Product> Items;
        public float Total;

        public Purchase(int id, CashRegister checkout, Employee cashier, Client customer, List<Product> items, float total)
        {
            ID = id;
            Checkout = checkout;
            Cashier = cashier;
            Customer = customer;
            Items = items;
            Total = total;
        }

        public static void collectData(Store store, Employee activeEmployee, CashRegister activeCashRegister)
        {
            try
            {
                Client activeClient = Client.findByID(store);
                 
                List<Product> purchaseItems = new List<Product>();
                
                bool isBuying = true;
                do
                {
                    Product newItem = Product.findByID(store);
                    purchaseItems.Add(newItem);
                    
                    Console.WriteLine("Continuar adicionando? (s/n) ");    
                    string c = store.NullString(Console.ReadLine());
                    if(c == "n")
                    {
                        isBuying = false;
                    }
                } while(isBuying);

                float purchaseTotal = 0;
                purchaseItems.ForEach(item => {
                    purchaseTotal += item.Price;
                });

                Purchase newPurchase = new Purchase(store.purchases.Count + 1, activeCashRegister, activeEmployee, activeClient, purchaseItems, purchaseTotal);
                

                bool isPaid = false;
                Payment paymentResult;
                do
                {
                    float payment;
                    Console.WriteLine("Valor recebido: ");
                    float.TryParse(Console.ReadLine(), out payment);
                    paymentResult = new Payment(newPurchase.Total, payment);

                    isPaid = paymentResult.status;
                    if(!isPaid)
                    {
                        Console.WriteLine("Desistir? (s/n)");  
                        string c = store.NullString(Console.ReadLine());
                        if(c == "s")
                        {
                            break;
                        }
                    }
                } while(!isPaid);

                if(isPaid)
                {
                    // some code here
                    if(paymentResult.change > 0)
                    {
                        Console.WriteLine("Troco: " + paymentResult.change);
                        Console.ReadKey();
                    }
                    Console.WriteLine("Compra realizada com sucesso!");
                    Console.ReadKey();
                    store.purchases.Add(newPurchase);

                    activeCashRegister.Balance += purchaseTotal;

                    JsonFileUtils.writeToJson(store.cashRegisters, "json/cashRegisters.json");
                    JsonFileUtils.writeToJson(store.purchases, "json/purchases.json");
                }

            }
            catch(Exception e)
            {
                throw new ArgumentException($"[Error] Collect purchase data: {e}");
            }
        }


        public static void listData(Store store)
        {
            Console.WriteLine("== COMPRAS DISPONÍVEIS ==");   
            var table = new ConsoleTable("ID","CAIXA","ATENDENTE","CLIENTE","TOTAL"); 
            store.purchases.ForEach(purchase => {
                table.AddRow(purchase.ID, purchase.Checkout.ID, purchase.Cashier.Name, purchase.Customer.Name, purchase.Total);
            });
            table.Write();
        }

        public static Purchase findByID(Store store)
        {
            Console.Clear();
            Purchase.listData(store);
            Console.WriteLine("Selecione Compra pela ID: ");
            int.TryParse(Console.ReadLine(), out int purchaseID);
            Purchase matchedPurchase = store.purchases.Find(p => p.ID == purchaseID);

            return matchedPurchase; 
        }
    }
}