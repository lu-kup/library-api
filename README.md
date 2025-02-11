# LibraryApi

### Introduction

This project implements a simple book management API using an in-memory database. The available endpoints include CRUD operations as well as simple search functionality that finds books by title or author.

### Original problem statement

Build a Simple Book Management API.

Create a RESTful API using .NET Core that allows users to manage a collection of books. The
API should include the following features:
1. Book model with properties:
- Id (int)
- Title (string)
- Author (string)
- ISBN (string)
- PublicationYear (int)
2. Implement CRUD operations:
- GET /api/books: Retrieve all books
- GET /api/books/{id}: Retrieve a specific book by ID
- POST /api/books: Add a new book
- PUT /api/books/{id}: Update an existing book
- DELETE /api/books/{id}: Delete a book
3. Data persistence:
- Use Entity Framework Core with an in-memory database for simplicity
4. Implement basic input validation:
- Ensure required fields are not empty
- Validate ISBN format
- Ensure PublicationYear is not in the future
5. Add a simple search functionality:
- GET /api/books/search?query={searchTerm}: Search books by title or author
6. Implement proper error handling and return appropriate HTTP status codes
7. Write unit tests for at least two endpoints
8. Use dependency injection for better testability and maintainability

### Clone the repository

```bash
git clone https://github.com/lu-kup/library-api.git
cd library-api
```

### Running the application

In order to run the application, use the following command while in `library-api` directory:

```bash
dotnet run --project LibraryApi
```

In order to test the endpoints, use Swagger interface at `https://localhost:7212/swagger/index.html`

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
