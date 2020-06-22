using ExampleSupportTicketSystem.Application.Interfaces;
using ExampleSupportTicketSystem.Domain.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExampleSupportTicketSystem.Api.Models
{
    public class CreateTicketRequestModel : ICreateTicketRequestModel
    {
 
        [Required]
        public string Subject { get; set; }

        [Required]
        public string Requestor { get; set; }


        [Required]
        public string Detail { get; set; }
    }
}
