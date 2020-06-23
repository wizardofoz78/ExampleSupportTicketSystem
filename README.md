# ExampleSupportTicketSystem
This project gives an example of; 

1. Design Artefacts
2. Solution structure
3. Dependency Injection.
4. Model Binding
5. Domain Model / Repository design.
6. Unit Tests (using the Moq framework)


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


