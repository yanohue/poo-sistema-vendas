using System;

namespace Store
{
    public class Payment
    {
        public bool status {get; private set; }
        public float change {get; private set; }

        public Payment(float bill, float payment)
        {
            pay(bill, payment);
        }

        private void pay(float bill,float payment)
        {
            if(payment >= bill)
            {
                change = payment - bill;
                status = true;
            }
            else
            {
                Console.WriteLine("Pagamento insuficiente. O pagamento não pode ser concluído.");
                Console.ReadLine();
                status = false;
            }
        }
    }
}