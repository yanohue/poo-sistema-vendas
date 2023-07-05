using System;
using Newtonsoft.Json;
using ConsoleTables;

namespace Store
{
    public class CashRegister : IDataControl
    {
        public int ID {get; set;}
        public float Balance {get; set;}

        public CashRegister(int id, float balance)
        {
            ID = id;
            Balance = balance;
        }
        

        public static void collectData(Store store)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Cadastro de Caixa:");

                /* Console.Write("ID do caixa: ");
                int cashRegisterID; 
                int.TryParse(Console.ReadLine(), out cashRegisterID); */

                Console.Write("Saldo: ");
                float balanceCR;
                if(!float.TryParse(Console.ReadLine(), out balanceCR))
                {
                    Console.WriteLine("Not a valid float");
                }
                CashRegister newCashRegister = new CashRegister(store.cashRegisters.Count + 1, balanceCR);
                store.cashRegisters.Add(newCashRegister);

                JsonFileUtils.writeToJson(store.cashRegisters, "json/cashRegisters.json");
            } 
            catch(Exception e)
            {
                throw new ArgumentException($"[Error] Collect cash register data: {e}");
            } 
        }

        public static void listData(Store store)
        {
            Console.WriteLine("== CAIXAS DISPONÍVEIS ==");
            var table = new ConsoleTable("ID","Saldo"); 
            store.cashRegisters.ForEach(cashRegister => {
                table.AddRow(cashRegister.ID, cashRegister.Balance);
            });
            table.Write();
        }
 
        public static CashRegister findByID(Store store)
        {
            Console.Clear();
            CashRegister.listData(store);
            Console.WriteLine("Selecione caixa pela ID: ");
            int.TryParse(Console.ReadLine(), out int cashRegisterID);
            CashRegister matchedCashRegister = store.cashRegisters.Find(cr => cr.ID == cashRegisterID);

            return matchedCashRegister;
        }
    }
}