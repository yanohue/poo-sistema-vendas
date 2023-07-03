using System;
using Newtonsoft.Json;
using ConsoleTables;

namespace Store
{
    public class CashRegister : saveInterface
    {
        public int ID {get; set;}
        public float balance {get; set;}

        public static void collectData(Store store)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Cadastro de Caixa:");

                Console.Write("ID do caixa: ");
                int cashRegisterID; 
                int.TryParse(Console.ReadLine(), out cashRegisterID);

                Console.Write("Saldo: ");
                float balanceCR;
                float.TryParse(Console.ReadLine(), out balanceCR);

                CashRegister newCashRegister = new CashRegister {ID = cashRegisterID, balance = balanceCR};
                store.cashRegisters.Add(newCashRegister);

                CashRegister.saveData(store);
            } 
            catch(Exception e)
            {
                throw new ArgumentException($"[Error] Collect cash register data: {e}");
            } 
        }

        public static void saveData(Store store)
        {
            File.WriteAllText("json/cashRegisters.json", JsonConvert.SerializeObject(store.cashRegisters));
        }

        public static void listData(Store store)
        {
            var table = new ConsoleTable("ID","Saldo"); 
            Console.Clear();
            store.cashRegisters.ForEach(cashRegister => {
                table.AddRow(cashRegister.ID, cashRegister.balance);
            });
            table.Write();
            Console.ReadLine();
        }
    }
}