namespace BuilderPayment.Domain
{
    public class SendUser
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string PhoneNumber { get; private set; }
        public decimal SendValue { get; private set; }

        public SendUser(string name, string email, string phoneNumber, decimal sendValue)
        {
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
            SendValue = sendValue;
        }
    }
}
