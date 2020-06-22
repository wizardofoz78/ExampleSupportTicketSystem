using ExampleSupportTicketSystem.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExampleSupportTicketSystem.Application.Interfaces
{
   public interface ICreateTicketResponseModel
    {
        public int TicketId { get; set; }
        public ITicketStatus Status { get; set; }
    }
}
