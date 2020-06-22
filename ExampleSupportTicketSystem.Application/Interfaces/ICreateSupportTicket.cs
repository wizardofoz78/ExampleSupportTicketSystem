using System;
using System.Collections.Generic;
using System.Text;

namespace ExampleSupportTicketSystem.Application.Interfaces
{
    public interface ICreateSupportTicket
    {
        public ICreateTicketResponseModel Create(ICreateTicketRequestModel request);
    }
}
