# Post API with NUnit Tests

This project demonstrates how to create a RESTful API using ASP.NET Core and .NET 9, complete with CRUD operations for posts and comments, and write comprehensive unit tests using NUnit, Moq, and FluentAssertions.

---

## Features

- **CRUD Operations** for `Post` and `Comment`.
- Integration of `HttpClientFactory` to consume external APIs.
- **Unit Tests** using:
  - [NUnit](https://nunit.org/)
  - [Moq](https://github.com/moq/moq4)
  - [FluentAssertions](https://fluentassertions.com/)

---

## Endpoints

| HTTP Method | Endpoint              | Description                    |
|-------------|-----------------------|--------------------------------|
| `GET`       | `/api/post`           | Retrieve all posts.            |
| `GET`       | `/api/post/{id}`      | Retrieve a specific post by ID.|
| `GET`       | `/api/post/{id}/comments` | Retrieve comments for a post. |
| `POST`      | `/api/post`           | Create a new post.             |
| `PUT`       | `/api/post/{id}`      | Update an existing post.       |
| `PATCH`     | `/api/post/{id}`      | Partially update a post.       |
| `DELETE`    | `/api/post/{id}`      | Delete a post.                 |

---

## Prerequisites

- .NET 9 SDK
- Visual Studio 2022 or VS Code
- Postman (for API testing)

---

## Getting Started

### 1. Clone the Repository

```bash
git clone https://github.com/Prashant-Odhavani/nUnitDemo.git

