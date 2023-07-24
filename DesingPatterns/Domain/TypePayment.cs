namespace BuilderPayment.Domain
{
    public class TypePayment
    {
        public TypePaymentDone Type { get; private set; }
        public decimal Value { get; private set; }
        public decimal TotalValue => Pay(Type, Value);

        public TypePayment(TypePaymentDone type, decimal value)
        {
            Type = type;
            Value = value;
        }

        private decimal Pay(TypePaymentDone type, decimal value)
        {
            if (type == TypePaymentDone.Ted || type == TypePaymentDone.Billet)
            {
                return Value * new decimal(0.5) / 100 - Value;
            }
            else
            {
                return value;
            }
        }
    }

    public enum TypePaymentDone
    {
        Pix, Ted, Billet
    }
}
