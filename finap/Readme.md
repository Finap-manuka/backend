# ASP.NET Backend Setup Guide

## Prerequisites
- .NET 8.0 SDK
- SQL Server or SQL Server Express
- Git

## Setup Commands

### 1. Clone Repository
```bash
git clone <repository-url>
cd <project-folder>
```

### 2. Install EF Tools
```bash
dotnet tool install --global dotnet-ef
```

### 3. Configure Database
Update `appsettings.json`:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=YourDatabaseName;Trusted_Connection=true"
  }
}
```

### 4. Database Migration
```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

### 5. Build and Run
```bash
dotnet restore
dotnet build
dotnet run
```

## Verification
- API: `https://localhost:5001`
- Swagger: `https://localhost:5001/swagger`

## Troubleshooting Commands

### Reset Database
```bash
dotnet ef database drop
dotnet ef migrations add InitialCreate
dotnet ef database update
```

### Clear Cache
```bash
dotnet nuget locals all --clear
dotnet restore
```

### Kill Port Process
```bash
netstat -ano | findstr :5001
taskkill /PID <process-id> /F
```

## API Endpoints
- `GET /api/users` - Get all users
- `POST /new-user` - Create new user

## Default Ports
- HTTP: `http://localhost:5000`
- HTTPS: `https://localhost:5001`