using BuilderPayment.Domain;

namespace BuilderPayment.Builder
{
    public class BuilderPayment
    {
        private Payment _payment;

        public Payment Build() => _payment;

        public BuilderPayment(Payment payment)
        {
            _payment = payment;
        }

        public void Clear()
        {
            _payment = new Payment();
        }

        public BuilderPayment AddUsersToPay()
        {
            _payment.SendUser = new SendUser("Will", "Will", "47", 100);
            _payment.ReceiveUser = new ReceiveUser("Vida", "Vida", "47", 100);
            return this;
        }

        public BuilderPayment AddDataToPay()
        {
            _payment.AccountDescription = "Payment";
            _payment.TypePayment = new TypePayment(TypePaymentDone.Pix, 100);

            return this;
        }
    }
}
