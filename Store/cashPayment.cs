using System;

namespace Store
{
    public class CashPayment : Payment
    {
        public override void Pay(float bill, float payment)
        {

            if (payment >= bill)
            {
                Change = payment - bill;
                Status = true;
            }
            else
            {
                Console.WriteLine("Pagamento insuficiente. O pagamento não pode ser concluído.");
                Console.ReadLine();
                Status = false;
            }
        }

        public static bool processPayment(Store store, Purchase purchase)
        {
            CashPayment paymentMethod = new CashPayment();

            bool isPaid = false;
            do
            {
                float payment;
                Console.WriteLine("Valor recebido: ");
                float.TryParse(Console.ReadLine(), out payment);
                paymentMethod.Pay(purchase.Total, payment);

                isPaid = paymentMethod.Status;
                if (!isPaid)
                {
                    Console.WriteLine("Desistir? (s/n)");
                    string c = store.NullString(Console.ReadLine());
                    if (c == "s")
                    {
                        break;
                    }
                }
            } while (!isPaid);

            if (isPaid)
            {
                if (paymentMethod.Change > 0)
                {
                    Console.WriteLine("Troco: " + paymentMethod.Change);
                    Console.ReadKey();
                }
                Console.WriteLine("Compra realizada com sucesso!");
                Console.ReadKey();
            }
            return isPaid;
        }
    }
}