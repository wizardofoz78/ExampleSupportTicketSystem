using ExampleSupportTicketSystem.Application.Interfaces;
using ExampleSupportTicketSystem.Domain.Interface;
using ExampleSupportTicketSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExampleSupportTicketSystem.Application.Library
{
    public class TickerResponseBuilder : ITicketResponseBuilder
    {

 
        public ICreateTicketResponseModel Build(IServiceProvider serviceProvider, ITicketStatus ticketStatus, int ticketId = -1, Exception e = null) {

            ICreateTicketResponseModel response;

            try
            {

                response = CreateTicketResponse(serviceProvider, ticketStatus, ticketId, e);

            }
            catch (Exception x)
            {
                return CreateTicketResponse(serviceProvider, ticketStatus, ticketId, e);
            }

            return response;

        }


        private ICreateTicketResponseModel CreateTicketResponse(IServiceProvider serviceProvider, ITicketStatus ticketStatus, int ticketId = -1, Exception e = null) {

            ICreateTicketResponseModel response;

            if (ticketStatus == null)
            {
                ticketStatus = (ITicketStatus)serviceProvider.GetService(typeof(ITicketStatus));

                if (e != null)
                {
                    ticketStatus.Status_Description = e.Message;
                }
                else
                {
                    ticketStatus.Status_Description = "An general error has occurred, please see application logs.";
                }


                ticketStatus.Status_Code = -1;
                ticketStatus.Status_Name = "ERROR";
                ticketStatus.TicketStatusId = -1;
            }


            response = (ICreateTicketResponseModel)serviceProvider.GetService(typeof(ICreateTicketResponseModel));

            response.Status = ticketStatus;

            response.TicketId = (int)ticketId;

            return response;
        }

    }
}
