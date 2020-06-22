using ExampleSupportTicketSystem.Api.Models;
using ExampleSupportTicketSystem.Application.Concrete;
using ExampleSupportTicketSystem.Application.Interfaces;
using ExampleSupportTicketSystem.Domain.Interface;
using ExampleSupportTicketSystem.Domain.Models;
using Moq;
using System;
using Xunit;

namespace ExampleSupportTicketSystem.Tests.ApplicationTests
{
    public class CreateTicketTest
    {
        private int FuncData(int x, int y)
        {
            return x + y;
        }

        [Fact]
        public void Create_Support_Ticket_Test_Success()
        {

            ///////////////////////////////////////////
            // Arrange
            ///////////////////////////////////////////

            // Create our mock repository
            Mock<ISupportRepository> repo = new Mock<ISupportRepository>();
            repo.Setup(m => m.CreateTicket(It.IsAny<ICreateTicket>())).Returns(new Ticket()
            {
                TicketId = 1,
                Created = DateTime.UtcNow,
                Detail = "This is some test detail, Requestor",
                Requestor = "John Smith",
                Subject = "This is a ticket",
                Status = new TicketStatus()
                {
                    Status_Code = 1,
                    Status_Name = "CREATED",
                    Status_Description = "",
                    TicketStatusId = 2
                }
            });

            // Mock the dependencies
            var serviceProvider = new Mock<IServiceProvider>();
            serviceProvider.Setup(m => m.GetService(typeof(ICreateTicket))).Returns(new CreateTicket());
            serviceProvider.Setup(k => k.GetService(typeof(ITicketStatus))).Returns(new TicketStatus());
            serviceProvider.Setup(t => t.GetService(typeof(ICreateTicketResponseModel))).Returns(new CreateTicketResponseModel());


            // For this test we dont need to pass in the service provider as we are only testing the application class.
            CreateSupportTicket myCreateTicket = new CreateSupportTicket(repo.Object, serviceProvider.Object);

            CreateTicketRequestModel model = new CreateTicketRequestModel()
            {
                Subject = "This is a ticket",
                Requestor = "John Smith",
                Detail = "This is some test detail, Requestor"
            };

            ///////////////////////////////////////////
            // Act
            ///////////////////////////////////////////
            ICreateTicketResponseModel response = myCreateTicket.Create(model);


            ///////////////////////////////////////////
            // Assert
            ///////////////////////////////////////////
            Assert.Equal(1, response.Status.Status_Code);           // Status 1 indicates ticket created successfully.
            Assert.Equal("CREATED", response.Status.Status_Name);   // If successfult then Status name should be created.
        }


        [Fact]
        public void Create_Support_Ticket_Test_No_Data()
        {
            ///////////////////////////////////////////
            // Arrange
            ///////////////////////////////////////////

            // Create our mock repository
            Mock<ISupportRepository> repo = new Mock<ISupportRepository>();
            repo.Setup(m => m.CreateTicket(It.IsAny<ICreateTicket>())).Returns(new Ticket()
            {
                TicketId = 1,
                Created = DateTime.UtcNow,
                Detail = "This is some test detail, Requestor",
                Requestor = "John Smith",
                Subject = "This is a ticket",
                Status = new TicketStatus()
                {
                    Status_Code = 1,
                    Status_Name = "CREATED",
                    Status_Description = "",
                    TicketStatusId = 2
                }
            });

            // Mock the dependencies
            var serviceProvider = new Mock<IServiceProvider>();
            serviceProvider.Setup(m => m.GetService(typeof(ICreateTicket))).Returns(new CreateTicket());
            serviceProvider.Setup(k => k.GetService(typeof(ITicketStatus))).Returns(new TicketStatus());
            serviceProvider.Setup(t => t.GetService(typeof(ICreateTicketResponseModel))).Returns(new CreateTicketResponseModel());


            // For this test we dont need to pass in the service provider as we are only testing the application class.
            CreateSupportTicket myCreateTicket = new CreateSupportTicket(repo.Object, serviceProvider.Object);

            CreateTicketRequestModel model = new CreateTicketRequestModel()
            {
                Subject = "",
                Requestor = "",
                Detail = ""
            };

            ///////////////////////////////////////////
            // Act
            ///////////////////////////////////////////
        
            ICreateTicketResponseModel response = myCreateTicket.Create(model);
 


            ///////////////////////////////////////////
            // Assert
            ///////////////////////////////////////////
            Assert.Equal("ERROR", response.Status.Status_Name);
            Assert.Equal("Unable to create ticket due to incomplete model", response.Status.Status_Description);



        }
    }
}
