# Nihongo API

## Project Setup

Follow these steps to set up the Nihongo API project locally.

### Prerequisites
- [.NET SDK 7.0 or later](https://dotnet.microsoft.com/download)
- [PostgreSQL](https://www.postgresql.org/download/)

### Folder Structure
The project follows this structure:
```
nihongo_api/
├── Api/
│   ├── Routes/         # Routes and endpoints mapping
│   ├── Services/       # Core logic, structured using CQS
│   ├── Models/         # Entities models
│   ├── DTOs/           # Requests and responses DTOs
│   └── Data/           # Infrastructure setup and mappings
├── tests/
│   └── Api.Tests/      # xUnit tests
```

### Steps to Set Up Locally

1. **Clone the Repository**
   ```bash
   git clone https://github.com/Mdotta/nihongo_api
   cd nihongo_api
   ```

2. **Restore Dependencies**
   Navigate to the `src/Api` directory and restore NuGet packages:
   ```bash
   cd src/Api
   dotnet restore
   ```

3. **Set Up the Database**
   - Update the connection string in `appsettings.json` or `appsettings.Development.json` to point to your PostgreSQL instance.
   - Example connection string:
     ```json
     "ConnectionStrings": {
         "DefaultConnection": "Host=localhost;Database=nihongo_api;Username=postgres;Password=yourpassword"
     }
     ```
   - Apply migrations:
     ```bash
     dotnet ef database update
     ```

4. **Set the JWT Key**
   - Use the .NET User Secrets feature to securely store the JWT key during development:
     ```bash
     dotnet user-secrets init
     dotnet user-secrets set "Jwt:Key" "YourSuperSecretKeyHere"
     ```

5. **Run the Application**
   - Start the API:
     ```bash
     dotnet run
     ```
   - The API will be available at `https://localhost:5001` (or `http://localhost:5000` for non-HTTPS).

6. **Test the API**
   - Use tools like [Postman](https://www.postman.com/) or [curl](https://curl.se/) to test the endpoints.

### Testing

1. **Run Tests**
   - Navigate to the `tests/Api.Tests` directory:
     ```bash
     cd tests/Api.Tests
     dotnet test
     ```

### Notes
- Ensure sensitive data like the JWT key is not hardcoded in `appsettings.json` for production environments.
- Use environment variables or a secrets manager for production configurations.

Let me know if you encounter any issues!