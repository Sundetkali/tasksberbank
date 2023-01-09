using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tasksberbank.Models
{
    public class authorization
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

    }
}
