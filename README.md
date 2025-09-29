ll# Perla Metro Main API

The **Perla Metro Main API** is the central entry point for interacting with the Perla Metro microservices ecosystem.
It acts as a **gateway**, forwarding requests to the appropriate microservices:

* [**Stations Service**](https://github.com/godchisa254/perla-metro-stations-service)(manages metro stations)
* [**Routes Service**]() (manages metro routes)
* [**Users Service**](https://github.com/bxnjadev/perla-metro-users-service) (manages users and authentication)
* [**Tickets Service**](https://github.com/NicolasD2/perla-metro-tickets) (manages support tickets)

---

## 🚀 Features

* Centralized API gateway for multiple microservices.
* Transparent proxying of requests to microservices.
* Consistent DTOs and response wrappers across services.
* Extensible architecture to add more services.

---

## Arquitectura
La arquitectura del sistema se diseñó bajo el paradigma de Arquitectura Orientada a Servicios (SOA), 
la cual se caracteriza por exponer las funcionalidades principales de la aplicación como servicios independientes,
interoperables y reutilizables.

## Patrones de Diseño
En la implementación del proyecto se aplicaron diferentes *patrones de diseño* para garantizar la separación de responsabilidades, la reutilización de componentes y la mantenibilidad del sistema.

### DAO (Data Access Object)
El patrón *DAO* permite abstraer y encapsular el acceso a la base de datos, evitando que la lógica de negocio interactúe directamente con las consultas SQL o con la tecnología de persistencia.

### DTO (Data Transfer Object)
El patrón *DTO* se emplea para transportar datos entre las capas de la aplicación sin exponer directamente las entidades del dominio.

### Repository
El patrón *Repository* actúa como un intermediario entre la lógica de negocio y la capa de persistencia, simulando una colección en memoria que abstrae las operaciones sobre la base de datos.

## 🏗️ Project Structure

* **Controllers/**

  * `StationController.cs` → Forwards to Stations Service.
  * `RouteController.cs` → Forwards to Routes Service.
  * `UserController.cs` → Forwards to Users Service.
  * `TicketController.cs` → Forwards to Tickets Service.
* **Service/** → Interfaces and implementations for microservice calls.
* **Util/** → Routes configuration, wrappers, builders.

---

## ⚙️ Setup

### Prerequisites

* [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
* Running instances of the services (if locally):

  * **Stations Service** → `http://localhost:9090` (ASP.NET with MySQL)
  * **Routes Service** → `http://localhost:4000` (NestJS with Neo4j)
  * **Users Service** → `http://localhost:2020` (ASP.NET with PostgreSQL)
  * **Tickets Service** → `http://localhost:3000` (NestJS with MongoDB)

* Running instances of the services (if used remote):

  * **Stations Service** → `https://perla-metro-stations-service.onrender.com/api/stations` (ASP.NET with MySQL)
  * **Routes Service** → `TBD` (NestJS with Neo4j)
  * **Users Service** → `https://perla-metro-users-service.onrender.com:8080/api/users` (ASP.NET with PostgreSQL)
  * **Tickets Service** → `https://perla-metro-tickets.onrender.com/api/tickets` (NestJS with MongoDB)

### Running the Main API

```bash
dotnet build
dotnet run
```

By default, the Main API will start on `http://localhost:5093`.

---

## 📡 Endpoints

### 1. Routes

Base URL: `/api/routes`

* **POST** `/api/routes/create` → Create a new route
* **GET** `/api/routes/find/{id}` → Find a route by ID
* **PUT** `/api/routes/edit/{uuid}` → Edit a route
* **GET** `/api/routes/all` → Get all routes
* **DELETE** `/api/routes/delete/{id}` → Delete a route

---

### 2. Stations

Base URL: `/api/station`

* **GET** `/api/station` → Get all stations (supports pagination & sorting)
* **GET** `/api/station/{id}` → Get a station by ID
* **POST** `/api/station` → Create a station
* **PUT** `/api/station/{id}` → Update a station
* **DELETE** `/api/station/{id}` → Delete a station

---

### 3. Users

Base URL: `/api/users`

* **POST** `/api/users/create` → Create a new user
* **GET** `/api/users/find/{uuid}` → Find a user by ID
* **PUT** `/api/users/edit/{uuid}` → Edit a user
* **DELETE** `/api/users/delete/{uuid}` → Delete a user
* **GET** `/api/users/search?name=...&email=...&searchByIsActive=...` → Search for users

---

### 4. Tickets 🎫

Base URL: `/api/tickets`

* **GET** `/api/tickets?admin=true|false` → List tickets
* **POST** `/api/tickets/crear` → Create a new ticket
* **GET** `/api/tickets/buscar/{id}` → Find a ticket by ID
* **PATCH** `/api/tickets/actualizar/{id}` → Update a ticket
* **DELETE** `/api/tickets/eliminar/{id}?admin=true|false` → Soft-delete a ticket

Additionally, the Tickets Service exposes a **health check**:

* **GET** `/health` → Shows service status, uptime, and MongoDB connection state

---

## 🔒 Authentication

* Some endpoints (like **station deletion** or **ticket deletion as admin**) require role-based authorization.

---

## 📖 Notes

* The Main API does not persist data itself; it proxies calls to the microservices.
* All responses use `HttpResponseWrapper<T>` for consistent handling.

---

## License

This project is proprietary software. All rights reserved.

---