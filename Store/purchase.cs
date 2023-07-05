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

                Payment paymentMethod = GetPaymentMethod();
    
                if (paymentMethod is CashPayment cashPayment)
                {
                    bool isPaid = CashPayment.processPayment(store, newPurchase);

                    if (isPaid)
                    {
                        store.purchases.Add(newPurchase);
                        activeCashRegister.Balance += purchaseTotal;
                        JsonFileUtils.writeToJson(store.cashRegisters, "json/cashRegisters.json");
                        JsonFileUtils.writeToJson(store.purchases, "json/purchases.json");
                    }
                }
                else if (paymentMethod is CreditCardPayment creditCardPayment)
                {
                    bool isPaid = CreditCardPayment.processPayment(store, newPurchase);

                    if (isPaid)
                    {
                        store.purchases.Add(newPurchase);
                        activeCashRegister.Balance += purchaseTotal;
                        JsonFileUtils.writeToJson(store.cashRegisters, "json/cashRegisters.json");
                        JsonFileUtils.writeToJson(store.purchases, "json/purchases.json");
                    }
                }
                else
                {
                    throw new ArgumentException("Método de pagamento inválido.");
                }
            }
            catch(Exception e)
            {
                throw new ArgumentException($"[Error] Collect purchase data: {e}");
            }
        }

        private static Payment GetPaymentMethod()
        {
            Console.WriteLine("Selecione o método de pagamento:");
            Console.WriteLine("1. Dinheiro");
            Console.WriteLine("2. Cartão de crédito");
            int option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    return new CashPayment();
                case 2:
                    return new CreditCardPayment();
                default:
                    throw new ArgumentException("Opção de pagamento inválida.");
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