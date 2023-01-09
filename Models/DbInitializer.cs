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

            if (context.Requests.Any())
            {
                return;
            }

            var requests = new Request[]
            {
                     
            };
            foreach (Request s in requests)
            {
                context.Requests.Add(s);
            }
            context.SaveChanges();
        }
    }
}
