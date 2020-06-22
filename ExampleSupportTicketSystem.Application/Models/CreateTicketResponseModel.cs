using ExampleSupportTicketSystem.Application.Interfaces;
using ExampleSupportTicketSystem.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExampleSupportTicketSystem.Api.Models
{
    public class CreateTicketResponseModel : ICreateTicketResponseModel
    {
        public int TicketId { get ; set; }
        public ITicketStatus Status { get ; set; }
    }
}
