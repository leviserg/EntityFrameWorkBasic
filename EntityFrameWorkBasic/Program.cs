using System;
using System.Linq;

namespace EntityFrameWorkBasic
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             *   Install NuGet packages:  
                1. Microsoft.EntityFrameworkCore {for proper .NET version}
                2. Microsoft.EntityFrameworkCore.Tools
                2. Install  - NuGet package Microsoft.EntityFrameworkCore.SqlServer
                            - NuGet package Pomelo.EntityFrameworkCore.MySql - if plan to use MySql Database
                3. Create class e.g. User.cs {as a model core} with proper properties {as a columns set}
                4. Create class e.g. UserContext.cs from base class DbContext { using Microsoft.EntityFrameworkCore; }
                5. using (YourDbContext ydbcontext = new YourDbContext){
                    .....
                    }
                    will create automatic connection and close it after execution
             */
            using (UserContext db = new UserContext())
            {
                try
                {
                    
                    User user1 = new User { Name = "Thomas", Age = 44 };
                    User user2 = new User { Name = "Alice", Age = 26 };

                    // add objects to Database
                    db.Users.Add(user1);
                    db.Users.Add(user2);
                    db.SaveChanges();
                    Console.WriteLine("Your objects has been saved");
                    
                    // get objects from Database 
                    var users = db.Users.ToList(); // using System.Linq;
                    foreach (User u in users)
                    {
                        Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            Console.ReadKey();
        }
    }
}
