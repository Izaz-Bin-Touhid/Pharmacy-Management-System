using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy_Management_System.model
{
    public class Email
    {
        public string customerName;
        public string recipient;
        public string subject;
        public string message;
        public DateTime sentTime;

        public Email() { 
        
        }

        public Email(string customerName, string recipient, string subject, string message, DateTime sentTime)
        {
            this.customerName = customerName;
            this.recipient = recipient;
            this.subject = subject;
            this.message = message;
            this.sentTime = sentTime;
        }

        public string CustomerName { get => customerName; set => customerName = value; }
        public string Recipient { get => recipient; set => recipient = value; }
        public string Subject { get => subject; set => subject = value; }
        public string Message { get => message; set => message = value; }
        public DateTime SentTime { get => sentTime; set => sentTime = value; }




    }
}
