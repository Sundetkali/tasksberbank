using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tasksberbank.Models.Abstract;

namespace tasksberbank.Models
{
    public class Employee: BaseModel
    {
        public string Phone { get; set; }
        public string FIO { get; set; }
        public string  Email { get; set; }
        public string TypeRequest { get; set; }
    }
}
