# ExampleSupportTicketSystem
This project gives an example of; 

1. Design Artefacts
2. Solution / Project structure
3. Dependency Injection using Microsoft DI.
4. Model Binding
5. Domain Model / Repository design.
6. Unit Tests (using the Moq framework)
7. .Net Core 3.1
8. Request Routing


Improvements.
1. Consider decoupling the logging to make it non blocking, i.e send the log to a message queue for later processing into a central log system such as Seq.

2. Code needs refactoring.

3. Perhaps to reduce deployment risk split each action into its own code base.
   Codebase: Everthing that is needed for a Create Ticket.
   Codebase 2: Everything that is neded for an Update Ticket.
   Codebase 3: Everything that is needded for a Get tickets.

4. Add more unit tests, to cover Controller, Application, Domain Layers only where important.

5. Improve the branching structure of this project and use either Feature branch or Git Flow.

6. Add Persistent storage support (i.e database, message queue)

7. Add HTTPS Support

8. Add Cors Support

9. Add OAUTH2 / Authorisation Support.

10. Add Audit , Application, Error and Debug Logging.




