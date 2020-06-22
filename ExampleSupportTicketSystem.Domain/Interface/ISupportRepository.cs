using ExampleSupportTicketSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExampleSupportTicketSystem.Domain.Interface
{
    public interface ISupportRepository
    {

        ITicket CreateTicket(ICreateTicket ticket);


    }
}
