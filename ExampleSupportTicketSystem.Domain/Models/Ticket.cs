using ExampleSupportTicketSystem.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExampleSupportTicketSystem.Domain.Models
{
    public class Ticket : ITicket
    {
        public int TicketId { get; set; }

        public string Subject { get; set; }

        public string Requestor { get; set; }

        public string Detail { get; set; }

        public ITicketStatus  Status { get; set; }

        public DateTime Created { get; set; }

    }
}
