using System.Collections.Generic;

namespace Trade.Notification.Interfaces
{
    public interface INotifier
    {
        bool HasNotification();
        List<Notifications.Notification> Get();
        void Handle(Notifications.Notification notificacao);
    }
}
