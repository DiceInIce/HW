namespace Decorator
{
    public interface INotifier
    {
        public void send(string message);

    }

    public class EmailNotifier : INotifier
    {
        public void send(string message)
        {
            Console.WriteLine($"Email: {message}");
        }
    }

    public class NullWrapee : INotifier 
    {
        public void send(string message){}

    }

    public class SMSNotifier : INotifier
    {
        private INotifier _wrapee;

        public SMSNotifier(INotifier wrapee)
        {
            _wrapee = wrapee;
        }

        public void send(string message)
        {
            _wrapee.send(message);
            Console.WriteLine($"SMSNotifier: {message}");

        }
    }

    public class SlackNotifier : INotifier
    {
        private INotifier _wrapee;

        public SlackNotifier(INotifier wrapee)
        {
            _wrapee = wrapee;
        }

        public void send(string message)
        {
            _wrapee.send(message);
            Console.WriteLine($"SlackNotifier: {message}");

        }
    }

    public class EncryptedNotifier : INotifier
    {
        private INotifier _wrapee;

        public EncryptedNotifier(INotifier wrapee)
        {
            _wrapee = wrapee;
        }


        public void send(string message)
        {
            char[] buffer = message.ToCharArray();
            Array.Reverse(buffer);
            string reversed = new string(buffer);

            _wrapee.send(message);
            Console.WriteLine($"EncryptedNotifier: {reversed}");
        }
    }

    public class LoggedNotifier : INotifier
    {
        private INotifier _wrapee;

        public LoggedNotifier(INotifier wrapee)
        {
            _wrapee = wrapee;
        }


        public void send(string message)
        {
            Console.WriteLine($"LoggedNotifier: {message}");
            _wrapee.send(message);
        }
    }

    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Email + Шифрование + Логирование:\n");
            INotifier notifier1 = new LoggedNotifier(new EncryptedNotifier(new EmailNotifier()));
            notifier1.send("Первая группа декораторов");

            Console.WriteLine("\nSMS + Slack:\n");
            INotifier notifier2 = new SlackNotifier(new SMSNotifier(new EmailNotifier()));
            notifier2.send("Вторая группа декораторов");

            Console.WriteLine("\nEmail + Логирование + Slack + Шифрование:\n");
            INotifier notifier3 = new EncryptedNotifier(new SlackNotifier(new LoggedNotifier(new EmailNotifier())));
            notifier3.send("Третья группа декораторов");
        }
    }

}