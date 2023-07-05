using System;

//namespace Store
{
    public abstract class Payment
    {
        public bool Status { get; protected set; }
        public float Change { get; protected set; }

        public abstract void Pay(float bill, float payment);
    }

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
    }

    public class CreditCardPayment : Payment
    {
        public override void Pay(float bill, float payment)
        {
            // Lógica específica para pagamento com cartão de crédito
        }
    }

    public class Purchase : IDataControl
    {
        // implementação da classe Purchase...

        public static void collectData(Store store, Employee activeEmployee, CashRegister activeCashRegister)
        {
            // implementação do método collectData...

            Payment paymentMethod = GetPaymentMethod();

            bool isPaid = false;
            do
            {
                float payment;
                Console.WriteLine("Valor recebido: ");
                float.TryParse(Console.ReadLine(), out payment);
                paymentMethod.Pay(newPurchase.Total, payment);

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

            // Resto da implementação do método collectData...
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
    }
}