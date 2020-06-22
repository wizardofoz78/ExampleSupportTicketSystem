using System;
using ExampleSupportTicketSystem.Domain.Interface;

namespace ExampleSupportTicketSystem.Domain.Models
{
    public class TicketStatus : ITicketStatus
    {
        public int TicketStatusId { get; set; }
        public string Status_Name { get; set; }
        public int Status_Code { get; set; }
        public string Status_Description { get ; set; }
    }
}
