using ExampleSupportTicketSystem.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExampleSupportTicketSystem.Application.Interfaces
{
    public interface ITicketResponseBuilder
    {
        ICreateTicketResponseModel Build(IServiceProvider serviceProvider, ITicketStatus ticketStatus, int TicketId = -1, Exception e = null);
    }
}
