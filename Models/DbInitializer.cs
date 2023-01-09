using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tasksberbank.DbContexts;

namespace tasksberbank.Models
{

    public static class DbInitializer
    {
        public static void Initialize(ApplicationContext context)
        {
            context.Database.EnsureCreated();

            if (context.Employees.Any())
            {
                return;
            }

            var Employees = new Employee[]
            {
                     
            };
            foreach (Employee s in Employees)
            {
                context.Employees.Add(s);
            }
            context.SaveChanges();
        }
    }
}
