namespace BankSystem.Infrastructure.Exceptions
{
    public class BankSystemException : Exception
    {
        public int StatusCode { get; } = 400;

        public BankSystemException(string message) : base(message) { }
    }
}
