﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExampleSupportTicketSystem.Api.Models;
using ExampleSupportTicketSystem.Application.Interfaces;
using ExampleSupportTicketSystem.Domain.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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

        [HttpPost]
        //[Authorize]// Enable for OAUTH2 Implementation!
        [Route("api/[controller]/ticket/create")]
        public IActionResult CreateTicket([FromBody] CreateTicketRequestModel createModel)
        {

            ICreateTicketResponseModel response = null;
  
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception("Model is invalid");
                }

                response = createTicket.Create(createModel);
            }
            catch (Exception e)
            {

                var ticketStatus = (ITicketResponseBuilder)serviceProvider.GetService(typeof(ITicketResponseBuilder));

                return BadRequest(ticketStatus.Build(serviceProvider, null, -1, e));
            }

            return Ok(response);

        }

        [HttpGet]
        [Authorize]
        [Route("api/[controller]/ticket/get")]
        public IActionResult GetAllTicket()
        {
            // TODO:
            return Ok();
        }


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
