using System;

namespace Store
{
    public abstract class Payment
    {
        public bool Status { get; protected set; }
        public float Change { get; protected set; }

        public abstract void Pay(float bill, float payment);
    }
}