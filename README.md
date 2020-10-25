## Sample Supermarket Api

This is a sample api containing various supermarket related endpoints.
- Demo: https://wx-api2.azurewebsites.net/swagger/index.html

### Project Structure
- This application is written using the Clean Architecture approach.
- References: 
    - [A quick introduction to clean architecture
](https://www.freecodecamp.org/news/a-quick-introduction-to-clean-architecture-990c014448d2/)
    - [Clean Architecture with ASP.NET Core 2.1](https://youtu.be/_lwCVE_XgqI)
    - [NorthwindTraders - Sample application written using Clean Architecture](https://github.com/jasontaylordev/NorthwindTraders)

### Technologies:
- .Net Core
- MediatR
- AutoMapper
- FluentValidation
- NSwag
- Serilog
- xUnit
- Moq
- FluentAssertions
- Bogus

### Notes:
- **Logging**: All application level exceptions are logged via the Serilog middleware.
- **Error Handling**: All application level exceptions intercepted in [CustomExceptionHandlerMiddleware](https://github.com/gaz91au/wx-api/blob/master/src/WebAPI/Middleware/CustomExceptionHandlerMiddleware.cs) and produces a [ProblemDetails](https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.problemdetails?view=aspnetcore-3.1) response, which is based on the [Problem Details for HTTP APIs Specification](https://tools.ietf.org/html/rfc7807).
