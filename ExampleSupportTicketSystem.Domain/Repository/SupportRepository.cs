using ExampleSupportTicketSystem.Domain.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Transactions;

namespace ExampleSupportTicketSystem.Domain.Repository
{
    public class SupportRepository : ISupportRepository
    {

        private IServiceProvider serviceProvider;

        public SupportRepository(IServiceProvider _serviceProvider) {
            serviceProvider = _serviceProvider;
        }

        public ITicket CreateTicket(ICreateTicket ticket)
        {
            ITicket result = (ITicket)serviceProvider.GetService(typeof(ITicket));
            ITicketStatus ticketStatus = (ITicketStatus)serviceProvider.GetService(typeof(ITicketStatus));

            ////////////////////////////////////////////////////////////////
            // Add Persistence here either using ADO.net or Entity Framework.
            // TODO: DATABASE
            ////////////////////////////////////////////////////////////////
            ///


            // Presume data persisted succesfully, create return model.
            // Refactor this.
            ticketStatus.Status_Code = 1;
            ticketStatus.Status_Description = "CREATED";
            ticketStatus.Status_Name = "CREATED";
            ticketStatus.TicketStatusId = 2;


            // Persist to storage / TODO:
            result.Created = ticket.Created;
            result.Detail = ticket.Detail;
            result.Requestor = ticket.Requestor;
            result.Status = ticketStatus;
            result.Subject = ticket.Subject;
            result.TicketId = 1;


            return result;
        }
    }
}
