using System;
using System.Collections.Generic;
using System.Text;

namespace ExampleSupportTicketSystem.Domain.Interface
{
    public interface ITicketStatus
    {

        public int TicketStatusId { get; set; }

        public string Status_Name { get; set; }

        public int Status_Code { get; set; }

        public string Status_Description{ get; set; }

    }
}
