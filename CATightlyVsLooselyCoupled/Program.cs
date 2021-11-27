using System;

namespace CATightlyVsLooselyCoupled
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var serviceMode = NotificationModeFactory.Create(NotificationMode.WEIRD);
            NotificationService notificationService = new NotificationService(serviceMode);
            notificationService.Notify();
            Console.ReadKey();
        }
    }  

    class NotificationModeFactory
    {
        public static INotificationMode Create(NotificationMode mode)
        {
            switch (mode)
            {
                case NotificationMode.EMAIL:
                    return new EmailService(); 

                case NotificationMode.SMS:
                    return new SmsService();

                case NotificationMode.WEIRD:
                    return new WeirdService();

                default :
                    return new EmailService();
            }
        }
    }

    enum NotificationMode
    {
        EMAIL,
        SMS,
        WEIRD
    }

    interface INotificationMode
    {
        void Send();
    }

    
    class EmailService: INotificationMode
    {
        public void Send()
        {
            Console.WriteLine("email sent");
        }
    }

    class SmsService : INotificationMode
    {
        public void Send()
        {
            Console.WriteLine("sms sent");
        }
    }

    class WeirdService : INotificationMode
    {
        public void Send()
        {
            Console.WriteLine("blabla sent");
        }
    }

    class NotificationService
    {
        private readonly INotificationMode _notificationMode;

        public NotificationService(INotificationMode notificationMode)
        {
            _notificationMode = notificationMode;
        }

        public void Notify()
        {
            _notificationMode.Send();
        }
    }
}
