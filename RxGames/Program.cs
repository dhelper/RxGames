using System;
using System.Reactive.Linq;

namespace RxGames
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = new MyEventInput();
            input.NotificationSubject
                .Subscribe(notification => Console.WriteLine($"Notification({notification.GroupId})"));
            
            input.NotificationSubject
                .GroupBy(notification => notification.GroupId)
                .SelectMany(group => group.Count()
                    .Select(count => new Counter<string>{Id = group.Key, Count = count}))
                .Subscribe(counter =>
                {
                    Console.WriteLine($"{counter.Id} Final count: {counter.Count}");
                });

            input.NotificationSubject.GroupBy(notification => notification.GroupId)
                .SelectMany(group => group.Scan(new Counter<string> { Id = group.Key, Count = 0 },
                    (previous, current) => new Counter<string> { Id = previous.Id, Count = previous.Count + 1 }))
                .Subscribe(counter =>
                {
                    Console.WriteLine($"{counter.Id} count: {counter.Count}");
                });

            input.Start();
        }
    }
}
