# Product API

ASP.NET Core Web API integrated with Oracle database using PL/SQL packages.

## Tech Stack
- .NET 8 Web API
- Oracle XE
- PL/SQL Packages
- Swagger / Postman

## Setup
1. Update connection string in `appsettings.json`
2. Open project in Visual Studio
3. Run the API
4. Test via Swagger or Postman

## API Endpoints
- POST /api/products
- GET /api/products/list
- GET /api/products/{id}

## Notes
- All validations handled in Oracle
- API is thin orchestration layer
