using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tasksberbank
{
    public partial class Customer
    {
        public string CustomerId { get; set; }
        public string FIO { get; set; }
        public string Phone { get; set; }
        public string PhotoUrl { get; set; }

    }
}
