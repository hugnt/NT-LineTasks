# User Management System

## Overview

A full-stack user management application built with modern technologies and best practices. The project consists of two main components:

- **Backend**: .NET 10 Web API implementing Clean Architecture
- **Frontend**: React + TypeScript + Vite with modern UI components

## Backend Architecture - Clean Architecture

The backend follows Clean Architecture principles, ensuring separation of concerns, testability, and maintainability through well-defined layers:

### **API Layer** (`UserManagement.API`)
- Entry point for HTTP requests
- Minimal API endpoints
- Global exception handling middleware
- CORS and Swagger configuration
- Dependency injection setup

### **Application Layer** (`UserManagement.Application`)
- Business logic and use cases
- Service interfaces and implementations
- DTOs (Data Transfer Objects) for requests/responses
- Input validation using FluentValidation
- Application-specific models and mappings

### **Domain Layer** (`UserManagement.Domain`)
- Core business entities
- Domain primitives and value objects
- Business rules and domain logic
- Enums and domain abstractions
- Independent of external concerns

### **Infrastructure Layer** (`UserManagement.Infrastructure`)
- Data persistence with Entity Framework Core
- Database context and configurations
- Repository implementations
- External service integrations

### **Architecture Tests** (`UserManagement.ArchitectureTests`)
- Enforces architectural boundaries
- Validates dependency rules
- Ensures layer isolation

## Frontend Architecture

The frontend is structured following feature-based organization with clear separation of concerns:

### **Core** (`src/core`)
- Application configuration
- Global providers (auth, theme, etc.)
- Routing setup

### **Modules** (`src/modules`)
- Feature-based organization
- User management module with components and logic

### **Shared** (`src/shared`)
- Reusable UI components
- Custom React hooks
- API services and HTTP clients
- TypeScript type definitions
- Application constants

## Getting Started

### Prerequisites

- .NET 8 SDK
- Node.js 18+ and npm
- SQL Server or PostgreSQL (configurable)
- Docker (optional)

### Backend Setup

1. Navigate to the backend directory:
   ```bash
   cd be
   ```

2. Restore dependencies:
   ```bash
   dotnet restore
   ```

3. Update connection string in `src/UserManagement.API/appsettings.Development.json`:
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "your-connection-string-here"
     }
   }
   ```

4. Apply database migrations (if available):
   ```bash
   dotnet ef database update --project src/UserManagement.Infrastructure --startup-project src/UserManagement.API
   ```

5. Run the API:
   ```bash
   dotnet run --project src/UserManagement.API
   ```

The API will be available at `https://localhost:7xxx` (check console output for exact port).

### Frontend Setup

1. Navigate to the frontend directory:
   ```bash
   cd fe
   ```

2. Install dependencies:
   ```bash
   npm install
   ```

3. Configure API endpoint in environment file if needed:
   ```bash
   # Create .env file and add:
   VITE_API_URL=https://localhost:7xxx/api
   ```

4. Start development server:
   ```bash
   npm run dev
   ```

The application will be available at `http://localhost:5173`.

## Docker Deployment

### Using Docker Compose (Recommended)

Run the entire stack with a single command:

```bash
docker-compose up -d
```

This will start:
- Backend API service
- Frontend with Nginx
- Database (if configured in docker-compose.yml)

### Individual Docker Builds

**Backend:**
```bash
cd be
docker build -t user-management-api .
docker run -p 8080:8080 user-management-api
```

**Frontend:**
```bash
cd fe
docker build -t user-management-ui .
docker run -p 80:80 user-management-ui
```

## Development Notes

- Backend uses minimal APIs for lightweight and performant endpoints
- FluentValidation for request validation
- Global exception handler for consistent error responses
- Frontend uses shadcn/ui components with Tailwind CSS
- TypeScript for type safety across the frontend application

## Contributing

Please ensure code follows the established patterns and passes all architectural tests before submitting pull requests.
