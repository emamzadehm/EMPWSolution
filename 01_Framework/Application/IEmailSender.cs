namespace _01_Framework.Application
{
    public interface IEmailSender
    {
            void SendEmail(string title, string messageBody, string destination);
    }
}
