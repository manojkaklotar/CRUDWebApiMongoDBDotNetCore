Prerequisites
.Netcore 2.2

Create Folder
Run below commands from cmd at new folders location
git init
git clone https://github.com/manojkaklotar/CRUDWebApiMongoDBDotNetCore.git
Run Service

Open Postman

POST request with UserModel

Url: https://localhost:5001/api/user
Body:
{
    "FirstName": "Manoj",
    "LastName": "Kaklotkar",
    "DOB": "01-01-1980",
    "Mobile": "987654321"
}
Response
{
    "userID": "1a76ffb509bcb04cc80a5c70aa81666bbfba",
    "firstName": "Manoj1",
    "lastName": "Kaklotkar",
    "dob": "1980-01-01T00:00:00",
    "mobile": 987654321
}

Use UserId for Get/Put/Update request by Id

Check data in mongodb configured as localhost:27017

Tools

Core 2.2 - WebAPI/ Service layer/ Data Model layer
Dependency Injection
Git 2.2
Mongo 4.0
Swagger
