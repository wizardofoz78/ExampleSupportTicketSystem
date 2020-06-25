using System;
using ExampleSupportTicketSystem.Api.Filters;
using ExampleSupportTicketSystem.Api.Models;
using ExampleSupportTicketSystem.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExampleSupportTicketSystem.Api.Controllers
{

    public class SupportController : ControllerBase
    {
        private ICreateSupportTicket createTicket;
        private IServiceProvider serviceProvider;

        public SupportController(ICreateSupportTicket _createTicket, IServiceProvider _serviceProvider) {
            createTicket = _createTicket;
            serviceProvider = _serviceProvider;
        }

        /// <summary>
        /// Creates a new Support Ticket
        /// </summary>
        /// <param name="createModel">The Input Model to create a new Ticket</param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        [CustomAuthorizeScope(AllowedScope = "DEV_SCOPE_READER")]
        [Route("api/[controller]/ticket/create")]
        public IActionResult CreateTicket([FromBody] CreateTicketRequestModel createModel)
        {
            ICreateTicketResponseModel response = null;
  
            try
            {
                if (!ModelState.IsValid)
                    throw new Exception("Model is invalid");

                response = createTicket.Create(createModel);
            }
            catch (Exception e)
            {

                var ticketStatus = (ITicketResponseBuilder)serviceProvider.GetService(typeof(ITicketResponseBuilder));

                return BadRequest(ticketStatus.Build(serviceProvider, null, -1, e));
            }
;
            return CreatedAtAction("CreateTicket", response);
        }

        /// <summary>
        /// Returns all Support tickets
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        [Route("api/[controller]/ticket/get")]
        public IActionResult GetAllTicket()
        {
            // TODO:
            return Ok();
        }

        /// <summary>
        /// Returns a Support ticket by its Id.
        /// </summary>
        /// <param name="id">The Ticket to be returned, its identifier</param>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        [Route("api/[controller]/ticket/get/{id}")]
        public IActionResult GetTicketById(int id)
        {
            // TODO:
            return Ok();
        }

        /// <summary>
        /// Updates a Support ticket
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [Authorize]
        [Route("api/[controller]/ticket/update")]
        public IActionResult UpdateTicket()
        {
            // TODO:
            return Ok();
        }


    }

}
