using ExampleSupportTicketSystem.Application.Interfaces;
using ExampleSupportTicketSystem.Domain.Interface;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExampleSupportTicketSystem.Application.Concrete
{
    public class CreateSupportTicket : ICreateSupportTicket
    {
        public ISupportRepository ticketRepository;
        public IServiceProvider serviceProvider;

        public CreateSupportTicket(ISupportRepository _ticketRepository, IServiceProvider _serviceProvider)
        {
            ticketRepository = _ticketRepository;
            serviceProvider = _serviceProvider;
        }


        public ICreateTicketResponseModel Create(ICreateTicketRequestModel request)
        {

            ICreateTicketResponseModel ticketResponseTransform;


            try
            {

                ICreateTicket transformModel = (ICreateTicket)serviceProvider.GetService(typeof(ICreateTicket));
                ITicketStatus ticketStatus = (ITicketStatus)serviceProvider.GetService(typeof(ITicketStatus));

                // Simulate a failure / Shouldnt get to this point anyways as the Model would be invalid
                // due to the property requiring a value. Will prevent whitespace though.
                if (string.IsNullOrWhiteSpace(request.Detail) || string.IsNullOrWhiteSpace(request.Subject))
                {
                    // Persist to storage / TODO:
                    // Do this as a specific type of exception. (custom)
                    // TODO: Debug Logging
                    ticketResponseTransform  = (ICreateTicketResponseModel)serviceProvider.GetService(typeof(ICreateTicketResponseModel));

                    // TODO: Debug Logging
                    ticketStatus.Status_Code = 0;
                    ticketStatus.Status_Description = "Unable to create ticket due to incomplete model";
                    ticketStatus.Status_Name = "ERROR";
                    ticketStatus.TicketStatusId = 1;

                    ticketResponseTransform.Status = ticketStatus;

                    return ticketResponseTransform;

                }



                // Transform the ICreateTicketRequestModel into an ICreateTicket
                // Add some additional value. to the model
                // Could use AutoMapper or another tool, but will do it manually for now.
                // Would refactor this later on into its own method.

                // TODO: Debug Logging
                ticketStatus.Status_Code = 0;
                ticketStatus.Status_Description = "CREATE";
                ticketStatus.Status_Name = "CREATE";
                ticketStatus.TicketStatusId = 1;


                transformModel.Subject = request.Subject;
                transformModel.Status = ticketStatus;
                transformModel.Requestor = request.Requestor;
                transformModel.Detail = request.Detail;
                transformModel.Created = DateTime.UtcNow;


                var createComplete = ticketRepository.CreateTicket(transformModel);
                // TODO: Debug Logging


                // Create the response model (subset of properties, based on the ITicket)
                ticketResponseTransform = (ICreateTicketResponseModel)serviceProvider.GetService(typeof(ICreateTicketResponseModel));
                ticketResponseTransform.TicketId = createComplete.TicketId;
                ticketResponseTransform.Status = createComplete.Status;

            }
            catch (Exception ex)
            {
                // TODO: exception Logging
                throw ex;
            }

            return ticketResponseTransform;
        }
    }
}
