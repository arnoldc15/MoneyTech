# MoneyTech

# Requirement:
  1.	1 API endpoint to calculate next Fibonacci number from a base number.
    a.	Request will contain a long or a type bigger than long (ulong) as base number.
    b.	Response will contain a long or a type bigger than long (ulong) as next fibonacci number

# Running the application and understanding the result:
  1.	Use MonetechTest.Api as a start up project
  2.	 The startup URI is http://localhost:XXXX/fibonacci/3/NextNumber with response of {"nextNumber":5}
    a.	The resource is "fibonacci" and uri of "/fibonacci"
    b.	The unique idenitfier is a basenumber as represented by http://localhost:XXXX/fibonacci/{baseNumber}/NextNumber
    c.	The field we are only after is nextNumber but encapsulated it in an object as avoid native return type in API for maintainability concern.

# Architecture
  1.	I applied pragmatic but very expandable architecture. Currently it is 2 tier but can evolve to CQRS/Microservices and/or onion architecture.
  2.	Application contain all the logic and WebAPI is dumb and can be switchable in any type of presentation (SOAP, WCF, Azure Function, WebAPP)
  3.	Domain and Persistence layers are purposely not added as it is not needed but can be easily be integrated
  4.	Integration tests and Web API tests are purposely not added due to minimal value it will add, however once we added more integration and transactional code, we will need to add these types of tests eventually
  5.	I usually add docker file so user can easily spin up an Azure app server via containarization to host the api but user  need to do a setup locally just to test the solution, I prefered not to include it so reviewer can immediately run the application

# Unit Tests
  1.	I added 2 theory tests with 10 different random valid numbers
  2.	I added two edge cases both min and max ulong value
  3.	Input validator as WEBAPI handles the serialization and convertion to ulong already. Meaning if you pass an invalid baseNumber api will throw HTTP 400.
