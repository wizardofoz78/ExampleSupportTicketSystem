using ExampleSupportTicketSystem.Domain.Interface;
using System;


namespace ExampleSupportTicketSystem.Application.Interfaces
{
    public interface ICreateTicketRequestModel
    {
        public string Subject { get; set; }

        public string Requestor { get; set; }

        public string Detail { get; set; }

    }
}
