using System;
using System.Linq;

namespace lab15
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Don't worry, job isn't that fast...");
            using (UsersDB db = new UsersDB())
            {
                Console.WriteLine("I am clearing db at the start");
                ClearDB(db);
                AddUserToDB(db, "Aleks", 20);
                AddUserToDB(db, "Elizabeth", 7);
                AddUserToDB(db, "Yury", 34);
                ShowUsers(db);
            }
            Console.Read();
        }

        static void ShowUsers(UsersDB db)
        {
            var users = db.Users.ToList();
            Console.WriteLine("Список объектов:");
            foreach (User u in users)
            {
                Console.WriteLine($"{u.Name} - {u.Age}");
            }
        }

        static void ClearDB(UsersDB db)
        {
            int number = 0;
            while (db.Users.Count() != 0)
            {
                User user = db.Users.First();
                db.Users.Remove(user);
                db.SaveChanges();
                number++;
            }
            if (number != 0)
            {
                Console.WriteLine("{0} users deleted", number);
            }
        }
        
        static void AddUserToDB(UsersDB db, string name, int age)
        {
            User user = new User { Name = name, Age = age };
            db.Users.Add(user);
            db.SaveChanges();
            Console.WriteLine("User added");
        }
    }
}
