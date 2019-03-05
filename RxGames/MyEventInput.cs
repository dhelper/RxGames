using System;
using System.Reactive.Subjects;

namespace RxGames
{
    class MyEventInput
    {
        private readonly ISubject<Notification> _notificationSubject = new Subject<Notification>();

        public ISubject<Notification> NotificationSubject => _notificationSubject;

        public void Start()
        {
            var random = new Random((int)DateTime.Now.Ticks);

            for (int i = 0; i < 10; i++)
            {
                int id = random.Next(0, 3);
                _notificationSubject.OnNext(new Notification($"event-{id}", $"notification {i}"));
            }

            _notificationSubject.OnCompleted();
        }
    }
}