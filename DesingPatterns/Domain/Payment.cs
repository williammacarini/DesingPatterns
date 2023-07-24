namespace BuilderPayment.Domain
{
    public class Payment
    {
        public string AccountDescription { get; set; }
        public SendUser SendUser { get; set; }
        public ReceiveUser ReceiveUser { get; set; }
        public TypePayment TypePayment { get; set; }
        public DateTime DatePayment => DateTime.UtcNow;

        public Payment(string accountDescription, SendUser sendUser, ReceiveUser receiveUser, TypePayment typePayment)
        {
            AccountDescription = accountDescription;
            SendUser = sendUser;
            ReceiveUser = receiveUser;
            TypePayment = typePayment;
        }

        public Payment()
        {

        }

        public override string ToString()
        {
            return $"Enviado com sucesso de {SendUser.Name} para {ReceiveUser.Name} o valor {TypePayment.TotalValue} por {TypePayment.Type}";
        }
    }
}
