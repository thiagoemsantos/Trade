using System.Collections.Generic;
using System.Linq;
using Trade.Notification.Interfaces;

namespace Trade.Notification.Notifications
{
    public class Notifier : INotifier
    {
        private List<Notification> _notifications;

        public Notifier()
        {
            _notifications = new List<Notification>();
        }

        public List<Notification> Get()
        {
            return _notifications;
        }

        public void Handle(Notification notificacao)
        {
            _notifications.Add(notificacao);
        }

        public bool HasNotification()
        {
            return _notifications.Any();
        }
    }
}
