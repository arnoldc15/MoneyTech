# MoneyTech

Run the application:

1. Use MonetechTest.Api as a start up project
2. The startup URI is http://localhost:XXXX/fibonacci/3/NextNumber with response of {"nextNumber":5}
  2.1 The resource is "fibonacci" and uri of "/fibonacci"
  2.2 The unique idenitfier is a basenumber as represented by http://localhost:XXXX/fibonacci/{baseNumber}/NextNumber
  2.3 The field we are only after is nextNumber but encapsulated it in an object as avoid native return type in API for maintainability concern.
