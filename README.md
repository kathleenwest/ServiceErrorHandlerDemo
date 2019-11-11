# ServiceErrorHandlerDemo
  
 Project Article: https://portfolio.katiegirl.net/2019/11/11/simple-service-error-handler-a-demo-of-a-wcf-self-hosted-service-client-tester-windows-form-application-exchanging-error-messages/
 
 
Simple Service Error Handler – A Demo of a WCF Self-Hosted Service & Client "Tester" Windows Form Application Exchanging Error Messages

 
About


This project presents a simple Math Service and Client Application demonstration that implements error handling on the service and communications of its errors to the client. The Math Service is a self-hosted (service host) WCF application launched and managed with a simple console interface. The client “tester” has a simplified GUI user interface to quickly demo and test the service (Windows Form Application). The GUI has features to add, subtract, multiply, and divide two numbers (integers). The GUI does basic data validation then sends a request to the math service. After it receives the results from the math service, it displays the calculation result or any received error messages (faults) to the user. The objective of this project was not to demo a calculator application but the handling of errors on a service.  

 
Architecture 
 
 
The demo project consists of these component topics:


•	Shared Class Library Project “SharedLibrary”

o	IMathService (Interface for Service)
o	DivideByZeroFault (Class describing a WCF Exception as a Fault)
o	GenericFault (Class describing a WCF Exception as a Fault)


•	Service Class Library Project “ServiceLibrary”

o	MathService (Code that Implements the Service Interface)
o	ServiceErrorHandler (Code that Implements Service Error Handling)
o	App.config (Configuration Reference for Service Host)
o	Reference to the Shared Class Library


•	WCF Service (Host) Application Project “ServiceHost”

o	Program (Starts, Manages, Stops the Service)
o	App.config (Configuration for Service Host)
o	Reference to the ServiceLibrary


•	Client “Tester to Service” Windows Form Application Project “Client”

o	Reference to the Shared Class Library
o	Main Form GUI User Interface
o	Form Code – Processes GUI User Interface



The service interface is defined not in the service application but in a Shared Library. This library defines the interface contracts for the math services (ex: Add) and is referenced by both the client and service host projects.  Since exceptions (errors) are really faults in WCF services, two custom error (fault) class models are defined in the shared library so that the client can understand and process the faults (errors). 

The ServiceLibrary implements the math service and contracts as defined in the SharedLibrary. The ServiceHost is a simple console application that is responsible for starting the math service, hosting, and managing the service (self-hosted). The service is also implemented as “PerCall” where each service call spins up a separate instance to respond to the client requests. 

A client “tester” windows form application tests the service and provides output to the user in a simple GUI. Errors are transmitted by the service to the client and because of the SharedLibrary model, it can understand the objects and alert the errors to the user with dialog windows.  

