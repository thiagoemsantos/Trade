using Trade.Notification.Interfaces;

namespace Trade.Notification
{
    public abstract class BaseService
    {
        private readonly INotifier _notifier;

        protected BaseService(INotifier notifier)
        {
            _notifier = notifier;
        }

        protected void Notifier(string mensagem)
        {
            _notifier.Handle(new Notifications.Notification(mensagem));
        }
    }
}
