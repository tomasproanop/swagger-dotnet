# Fridge Shopping API Documentation

## Introduction

The FridgeShopping API is a RESTful web application built using .NET Core. The idea behind this small project is that there are two collections (FoodInTheFridge and FoodToBuy), that can be managed, depending on what food items are available at home and which need to be bought.

Each collection supports CRUD operations. This project integrates MongoDB as the database and Swagger as a temporary UI and for manual interaction with the databade.

---

## Prerequisites
1. **.NET SDK**: Ensure you have the latest .NET SDK installed.
   - [Download .NET SDK](https://dotnet.microsoft.com/download)
2. **MongoDB**: You need access to the project's MongoDB database. You can also access the database with Mongo DB Compass using the provided credentials in appsetings.json. If you cannot access the database, double check that your VPN connection is active if you're off-campus.

---

## How we created the project and connected the MongoDB database

### 0. Create a new WebAPI template for the project

We used these commands:
```bash
dotnet new webapi -n FridgeShoppingApi
dotnet add package MongoDB.Driver
```

The MongoDB.Driver ist needed to interact with MongoDB.

### 1. Set up MongoDB
1. We created a MongoDB database called `swagger_project_vsys` and 2 collections in this database:
   - `FoodInFridge`
   - `FoodToBuy`
2. We added a user to the database (we did it in Ocean).

### 3. Configure the connection string
We updated the `appsettings.json` file with the MongoDB connection string:
```json
{
  "MongoDB": {
    "ConnectionString": "mongodb://user:pass@..." //(copy it from Ocean)
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```

### 4. Build the project
```bash
# restore dependencies and build
dotnet restore
dotnet build
```

### 5. Run the app
```bash
dotnet run
```
The application can be accessed at `http://localhost:5127/`

### 6. Access Swagger
Swagger is available at `http://localhost:5127/swagger/index.html`

As seen in the video, the Swagger UI can be used to interact with and test the API endpoints with the "Try it out" button.
