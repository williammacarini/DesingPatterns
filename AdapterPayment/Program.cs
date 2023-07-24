namespace AdapterPayment
{
    public static class Program
    {
        static void Main()
        {
            var erroCard = new PaymentErroCardAdpater(new());
            erroCard.PixPayment();

            var erroPix = new PaymentErroPixAdapter(new());
            erroPix.PaymentCard();
            erroPix.PaymentNFC();
        }
    }

    public interface ICardPayment
    {
        void PaymentNFC();
        void PaymentCard();
    }

    public class CardPayment : ICardPayment
    {
        public void PaymentCard()
        {
            Console.WriteLine("Payment Successfully");
        }

        public void PaymentNFC()
        {
            Console.WriteLine("Payment NFC Successfully");
        }
    }

    public interface IPixPayment
    {
        void PixPayment();
    }

    public class Pix : IPixPayment
    {
        public void PixPayment() => Console.WriteLine("Payment Pix Successfully");
    }

    public class PaymentErroCardAdpater : IPixPayment
    {
        private readonly CardPayment _cardPayment;

        public PaymentErroCardAdpater(CardPayment cardPayment)
        {
            _cardPayment = cardPayment;
        }

        public void PixPayment()
        {
            _cardPayment.PaymentNFC();
        }
    }

    public class PaymentErroPixAdapter : ICardPayment
    {
        private readonly Pix _pix;

        public PaymentErroPixAdapter(Pix pix)
        {
            _pix = pix;
        }

        public void PaymentCard()
        {
            _pix.PixPayment();
        }

        public void PaymentNFC()
        {
            _pix.PixPayment();
        }
    }
}