namespace CSharpPractice.DesignPatterns.StructuralPatterns.Bridge
{
    public interface IMessageSender
    {
        void SendMessage(string subject, string body);
    }
    public class EmailSender : IMessageSender
    {
        public void SendMessage(string subject, string body)
        {
            Console.WriteLine($"Email sent. Subject: {subject}, Body: {body}");
        }
    }

    public class SmsSender : IMessageSender
    {
        public void SendMessage(string subject, string body)
        {
            Console.WriteLine($"SMS sent. Subject: {subject}, Body: {body}");
        }
    }

    public abstract class Notification
    {
        protected IMessageSender _messageSender;

        protected Notification(IMessageSender messageSender)
        {
            _messageSender = messageSender;
        }

        public abstract void Notify(string subject, string body);
    }

    public class AlertNotification : Notification
    {
        public AlertNotification(IMessageSender messageSender) : base(messageSender)
        {
        }
        public override void Notify(string subject, string body)
        {
            _messageSender.SendMessage(subject, body);
        }
    }

    public class  ReminderNotification : Notification
    {
        public ReminderNotification(IMessageSender messageSender) : base(messageSender)
        {
        }

        public override void Notify(string subject, string body)
        {
            _messageSender.SendMessage("[REMINDER] " + subject, body);
        }
    }

    public class BridgeClient
    {
        public static void Test()
        {
            Console.WriteLine(":::Bridge Pattern Test:::");
            IMessageSender emailSender = new EmailSender();
            IMessageSender smsSender = new SmsSender();
            
            Notification alertNotification = new AlertNotification(emailSender);
            Notification reminderNotification = new ReminderNotification(smsSender);
            
            alertNotification.Notify("Server Down", "The server is down. Please check immediately.");
            reminderNotification.Notify("Meeting Reminder", "Don't forget about the meeting at 3 PM.");

            Console.WriteLine();
        }
    }   
}
