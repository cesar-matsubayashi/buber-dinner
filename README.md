# BuberDinner

**BuberDinner** is the backend for an application where users can create dinners, invite guests, and manage reservations, menus, and reviews. Built using **Clean Architecture** and **Domain-Driven Design (DDD)** principles in **C# .NET Core**, it supports clear separation of concerns and a scalable architecture.

## Tech Stack

- **.NET Core**
- **C#**
- **SQL Server**
- **Entity Framework Core**
- **MediatR** (CQRS & messaging)
- **Mapster** (object mapping)
- **FluentValidation** (input validation)
- **XUnit** (unit testing)

## Architecture

- **Domain Layer**: Business rules and aggregates using DDD.
- **Application Layer**: CQRS-based commands and queries using MediatR.
- **Infrastructure Layer**: SQL Server + EF Core persistence.
- **API Layer**: ASP.NET Core Web API with controllers and dependency injection.

## 📂 Project Structure

```
BuberDinner/
├── BuberDinner.Api          # Web API
├── BuberDinner.Application  # Application layer (CQRS, business rules)
├── BuberDinner.Domain       # Core domain models and logic
├── BuberDinner.Infrastructure # DB access, external services
├── BuberDinner.Contracts    # DTOs, requests/responses
├── BuberDinner.Tests        # Tests
```

## 📌 API Endpoints

### `auth/`
- `POST /register` — Create new user
- `POST /login` — Log in user

### `hosts/`
- `POST /` — Create host
- `PUT /{id}` — Update host
- `DELETE /{id}` — Delete host
- `GET /{id}` — Get host by ID

### `hosts/{hostId}/menus`
- `POST /` — Create menu
- `PUT /{id}` — Update menu
- `DELETE /{id}` — Delete menu
- `GET /{id}` — Get menu by ID
- `GET /` — List all menus

### `hosts/{hostId}/menus/{menuId}/menureviews`
- `POST /` — Create menu review
- `PUT /{id}` — Update menu review
- `DELETE /{id}` — Delete menu review
- `GET /{id}` — Get menu review by ID
- `GET guests/{guestId}` — List menu reviews by guest
- `GET /` — List menu reviews by menu

### `guests/`
- `POST /` — Create guest
- `PUT /{id}` — Update guest
- `DELETE /{id}` — Delete guest
- `GET /{id}` — Get guest by ID
- `POST /{id}/ratings` — Create guest rating
- `PUT /{id}/ratings/{guestRatingId}` — Update guest rating

### `dinners/`
- `POST /` — Create dinner
- `PUT /{id}` — Update dinner
- `DELETE /{id}` — Delete dinner
- `GET /{id}` — Get dinner by ID
- `GET /` — List dinners
- `POST /{id}/reservations` — Create reservation
- `PUT /{id}/reservations/{reservationId}` — Update reservation

### `bills/`
- `POST /` — Create bill
- `PUT /{id}` — Update bill
- `DELETE /{id}` — Delete bill
- `GET /{id}` — Get bill by ID
- `GET guests/{guestId}` — List bills by guest

## 🔐 Using `dotnet user-secrets`

To store sensitive data like your JWT secret securely during development:

```bash
dotnet user-secrets --project .\BuberDinner.Api\ set "JwtSettings:Secret" "your-super-secret-value"
```

## Getting Started

```bash
# Restore packages
dotnet restore

# Run migrations
dotnet ef database update --project BuberDinner.Infrastructure

# Start the API
dotnet run --project BuberDinner.Api
```

## Future Improvements

- ✅ Add **domain events** to capture side effects
- ✅ Extend **FluentValidation** on commands/requests/queries
- ✅ Add `user-secrets` for database connection security
- ✅ Write more **unit tests**
- ✅ Add **integration** and **end-to-end tests**
- ✅ Add **API**, **domain**, and **infrastructure** layer tests