# LibraryApi

### Introduction

This project implements a simple book management API using an in-memory database. The available endpoints include CRUD operations as well as simple search functionality that finds books by title or author.

### Clone the Repository

```bash
git clone https://github.com/lu-kup/library-api.git
cd library-api
```

### Running the application

In order to run the application, use the following command while in `library-api` directory:

```bash
dotnet run --project LibraryApi
```

In order to test the endpoints, using Swagger interface at `https://localhost:7212/swagger/index.html`

The API will be available at `https://localhost:7212` by default. 

If the URL does not open due to a missing HTTPS certificate, use the following command to generate a self-signed certificate to enable HTTPS use in local development.

```bash
dotnet dev-certs https --trust
```

### Unit tests

In order to run unit tests, use the following command while in directory `library-api`.
```bash
dotnet test
```
