using System;

namespace Store
{
    public class CreditCardPayment : Payment
    {
        public override void Pay(float bill, float payment)
        {
            if (payment == bill)
            {
                Change = 0;
                Status = true;
            }
            else
            {
                Console.WriteLine("O valor do pagamento deve ser igual ao valor total da compra.");
                Console.ReadLine();
                Status = false;
            }
        }

        public static bool processPayment(Store store, Purchase purchase)
        {
            CreditCardPayment paymentMethod = new CreditCardPayment();

            Console.WriteLine("Total: " + purchase.Total);
            Console.WriteLine("Confirmar pagamento: (s/n) ");
            string c = store.NullString(Console.ReadLine());

            bool isPaid = false;
            if (c == "s")
            {
                paymentMethod.Pay(purchase.Total, purchase.Total);
                isPaid = paymentMethod.Status;

                return isPaid;
            }
            else
            {
                return isPaid;
            }
        }
    }
}