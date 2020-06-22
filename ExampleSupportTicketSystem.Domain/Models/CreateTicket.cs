using System;
using ExampleSupportTicketSystem.Domain.Interface;


namespace ExampleSupportTicketSystem.Domain.Models
{
    public class CreateTicket : ICreateTicket
    {
     public string Subject { get; set; }

        public string Requestor { get; set; }

        public string Detail { get; set; }

        public ITicketStatus Status { get; set; }

        public DateTime Created { get; set; }
    }
}
