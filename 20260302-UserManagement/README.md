# User Management System

## Overview

A full-stack user management application built with modern technologies and best practices. The project consists of two main components:

- **Backend**: .NET 10 Web API implementing Clean Architecture
- **Frontend**: React + TypeScript + Vite with modern UI components

## Key Features

### User Management
- ✅ Create, read, update, and delete users
- ✅ User active/inactive status management
- ✅ Advanced filtering and pagination
- ✅ Data validation on both client and server sides
- ✅ Real-time updates with optimistic UI

### Technical Features
- ✅ RESTful API with OpenAPI/Swagger documentation
- ✅ Clean Architecture with clear layer separation
- ✅ Repository and Unit of Work patterns
- ✅ Global exception handling with RFC 7807 Problem Details
- ✅ In-Memory database for easy development and testing
- ✅ Responsive UI with modern component library
- ✅ Type-safe development with TypeScript
- ✅ Form validation with React Hook Form and Zod
- ✅ Efficient data fetching and caching with React Query

## Backend Architecture - Clean Architecture

The backend follows Clean Architecture principles, ensuring separation of concerns, testability, and maintainability through well-defined layers:

### **API Layer** (`UserManagement.API`)
- Entry point for HTTP requests using .NET Minimal APIs
- Endpoint grouping with base classes for consistent routing
- Global exception handling middleware with Problem Details
- CORS policy configuration
- Swagger/OpenAPI documentation
- Dependency injection container setup

### **Application Layer** (`UserManagement.Application`)
- Business logic and use cases
- Service interfaces and implementations (`IUserService`, `UserService`)
- Request/Response DTOs with validation
- FluentValidation for input validation
- Application-specific models (Result pattern, Filter, Pagination)
- String helpers and common utilities

### **Domain Layer** (`UserManagement.Domain`)
- Core business entities (User)
- Domain primitives and value objects
- Business rules and domain logic
- Repository abstractions and interfaces
- Enums and domain constants
- Independent of external dependencies

### **Infrastructure Layer** (`UserManagement.Infrastructure`)
- Entity Framework Core with In-Memory Database
- DbContext configuration and interceptors
- Auditable entity interceptor for tracking created/modified timestamps
- Repository pattern implementation
- Unit of Work pattern
- Database seeding functionality

### **Architecture Tests** (`UserManagement.ArchitectureTests`)
- Enforces architectural boundaries
- Validates dependency rules between layers
- Ensures layer isolation and Clean Architecture compliance

## Frontend Architecture

The frontend is built with React 19 and follows a feature-based modular architecture with clear separation of concerns:

### **Core** (`src/core`)
- **Config**: Application-wide configuration settings
- **Providers**: Context providers (QueryClientProvider for data management)
- **Router**: React Router 7 setup and route definitions

### **Modules** (`src/modules`)
- Feature-based organization
- **Users Module**: Complete user management feature with CRUD operations

### **Shared** (`src/shared`)
- **Components**: 
  - `ui/` - Shadcn/ui components built on Radix UI primitives
  - `forms/` - Form components and inputs
  - `layouts/` - Layout components
  - `data-display/` - Tables, cards, and data visualization components
  - `loading-spinner` - Loading states
- **Hooks**: Custom React hooks for reusable logic
- **Services**: HTTP services using Axios for API communication
- **Types**: TypeScript type definitions and interfaces
- **Constants**: Application constants and configuration
- **Lib**: Utility functions and helpers

### **Tech Stack**
- **React 19.2** - UI framework
- **TypeScript 5.9** - Type safety
- **Vite 7** - Build tool and dev server
- **React Router 7** - Client-side routing
- **TanStack React Query 5** - Server state management and data fetching
- **React Hook Form 7** - Form state management
- **Zod 4** - Schema validation
- **Tailwind CSS 4** - Utility-first styling
- **Shadcn/ui + Radix UI** - Accessible component library
- **Axios** - HTTP client
- **Lucide React** - Icon library
- **React Toastify + Sonner** - Toast notifications

## Getting Started

### Prerequisites

- **.NET 10 SDK** - For backend API
- **Node.js 20+** and **npm** - For frontend development
- **Docker** (optional) - For containerized deployment

### Backend Setup

1. Navigate to the backend directory:
   ```bash
   cd be
   ```

2. Restore dependencies:
   ```bash
   dotnet restore
   ```

3. Run the API:
   ```bash
   dotnet run --project src/UserManagement.API
   ```

The API will be available at `https://localhost:7xxx` (check console output for exact port).

**Swagger Documentation**: Navigate to `https://localhost:7xxx/swagger` to explore the API endpoints interactively.

**Available Endpoints**:
- `GET /api/users` - Get all users with filtering and pagination
- `GET /api/users/{id}` - Get user details
- `POST /api/users` - Create new user
- `PUT /api/users/{id}` - Update user
- `PATCH /api/users/{id}/active-status` - Update user active status
- `DELETE /api/users/{id}` - Delete user

### Frontend Setup

1. Navigate to the frontend directory:
   ```bash
   cd fe
   ```

2. Install dependencies:
   ```bash
   npm install
   ```

3. Configure API endpoint (optional):
   
   Create a `.env` file in the `fe` directory if you need to override the default API URL:
   ```bash
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

### Backend
- Uses .NET Minimal APIs with endpoint grouping for clean and organized routing
- Result pattern for consistent API responses
- Global exception handler with Problem Details (RFC 7807) for standardized error responses
- In-Memory Database for development (easy to switch to SQL Server/PostgreSQL)
- Repository and Unit of Work patterns for data access abstraction
- Auditable entities with automatic tracking of created/modified timestamps
- Database seeding on application startup
- FluentValidation for request validation
- CORS configured for cross-origin requests

### Frontend
- TypeScript for type safety across the entire application
- TanStack React Query for efficient server state management and caching
- React Hook Form + Zod for type-safe form validation
- Shadcn/ui components built on Radix UI primitives for accessibility
- Tailwind CSS 4 for modern, responsive styling
- Axios interceptors for centralized API communication
- Toast notifications for user feedback
- React Router 7 for declarative routing

### Architecture Benefits
- **Clean Architecture**: Clear separation between business logic and infrastructure
- **Testability**: Each layer can be tested independently
- **Maintainability**: Well-organized code structure following SOLID principles
- **Scalability**: Easy to add new features without affecting existing code

## Contributing

Please ensure code follows the established patterns and passes all architectural tests before submitting pull requests.
