using System;

namespace tasksberbank.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
    public class User
    {
        public int phone { get; set; }
        public string Email { get; set; }
        public string FIO { get; set; }


    }
}
