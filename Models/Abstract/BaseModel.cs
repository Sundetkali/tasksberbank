using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tasksberbank.DbContexts;

namespace tasksberbank.Models.Abstract
{
    public abstract class BaseModel
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
    }


}


