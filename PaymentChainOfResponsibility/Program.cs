namespace PaymentChainOfReponsibility
{
    public static class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting...");

            var cash = new CashPaymentHandler();
            var card = new CardPaymentHandler();
            var pix = new PixPaymentHandler();

            cash.SextNext(card).SextNext(pix);

            Client.CallHandler(cash, PaymentType.Card);

            Console.WriteLine("Finished...");
        }

        public enum PaymentType
        {
            Cash,
            Card,
            Pix
        }

        public interface IHandler
        {
            IHandler SextNext(IHandler handler);
            string Handle(PaymentType paymentType);
        }

        public abstract class Handler : IHandler
        {
            private IHandler _handler;

            public virtual string Handle(PaymentType paymentType)
                => _handler.Handle(paymentType);

            public IHandler SextNext(IHandler handler)
            {
                _handler = handler;
                return handler;
            }
        }

        public class CashPaymentHandler : Handler
        {
            public override string Handle(PaymentType paymentType)
                => paymentType == PaymentType.Cash ? "Payment by cash!" : base.Handle(paymentType);
        }

        public class CardPaymentHandler : Handler
        {
            public override string Handle(PaymentType paymentType)
                => paymentType == PaymentType.Card ? "Payment by card!" : base.Handle(paymentType);
        }

        public class PixPaymentHandler : Handler
        {
            public override string Handle(PaymentType paymentType)
                => paymentType == PaymentType.Pix ? "Payment by pix!" : base.Handle(paymentType);
        }

        public static class Client
        {
            public static void CallHandler(Handler handler, PaymentType paymentType)
            {
                var result = handler.Handle(paymentType);
                Console.WriteLine(result);
            }
        }
    }
}