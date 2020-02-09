using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace ObservableCollection
{
    class Program
    {
        static void Main(string[] args)
        {
            ObservableCollection<User> users = new ObservableCollection<User>
            {
                new User {Name = "Bill" },
                new User {Name = "Tom"},
                new User {Name = "John"}
            };
            users.CollectionChanged += Users_CollectionChanged;
            users.Add(new User() { Name = "Bob" });
            users.RemoveAt(1);
            users[0] = new User() { Name = "Andrey" };
            foreach(User user in users)
            {
                Console.WriteLine(user.Name);
            }
            Console.ReadKey();
        }

        private static void Users_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch(e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    {
                        User user = e.NewItems[0] as User;
                        Console.WriteLine($"Inserted {user.Name}");
                        break;
                    }
                case NotifyCollectionChangedAction.Remove:
                    {
                        User user = e.OldItems[0] as User;
                        Console.WriteLine($"Remove {user.Name}");
                        break;
                    }
                case NotifyCollectionChangedAction.Replace:
                    {
                        User user = e.OldItems[0] as User;
                        User user1 = e.NewItems[0] as User;
                        Console.WriteLine($"Remove {user.Name}, insert {user1.Name}");
                        break;
                    }
            }
        }
    }
}
