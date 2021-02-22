# Session 0205 - APIs Part 2: OpenAPI and gRPC

## Agenda

* Review API template
* Discuss annotations to deliver more value using OpenAPI
* API Clients
* API versioning with OpenAPI
* Introduce gRPC and gRPC template
* gRPC client

## OpenAPI

The OpenAPI specification is a standard interface definition for RESTful services.According to [RapidAPI.com](https://rapidapi.com/blog/api-glossary/openapi/) the OpenAPI Specification is an open-source format and initiative for designing and creating machine-readable interface files that are utilized in producing, describing, consuming, and visualizing RESTful APIs and web services. The OpenAPI definition file defines an API with the following information

* Present endpoints and each endpoint’s operations
* The input and output operation parameters
* Authentication techniques
* Contact information, terms of use, license, and more

OpenAPI and Swagger are sometimes used interchangeably.  Swagger was the name of the original specification and a company that implements tools for working with the public specification.  Swagger is now owned by SmartBear.

For ASP.NET Core projects, the OpenAPI definition file is generated for you and made available at `/swagger/v1/swagger.json`

### Customize OpenAPI

Documentation is available with details to update [the Swagger UI provided with ASP.NET Core](https://docs.microsoft.com/aspnet/core/tutorials/getting-started-with-swashbuckle?view=aspnetcore-5.0)

### .NET OpenAPI tool for client

There is an [OpenAPI command-line tool available](https://docs.microsoft.com/aspnet/core/web-api/Microsoft.dotnet-openapi?view=aspnetcore-5.0) to help you generate client-code that you can install with:

```
dotnet tool install --global Microsoft.dotnet-openapi --version 5.0.1
```

Add a service reference from the web to your client project with:

```
dotnet openapi add url https://localhost:5001/swagger/v1/swagger.json -p client.csproj
```

There are additional command-line options to add from local files, refresh your references, and remove the references.

## HTTP-Repl

You can use the [http-repl tool](https://docs.microsoft.com/aspnet/core/web-api/http-repl/?view=aspnetcore-5.0) to interact with your APIs on the command-line and using scripts.

Install the http-repl using:

```dotnetcli
dotnet tool install -g Microsoft.dotnet-httprepl
```

You can then navigate around your API as though you were traversing folders and interacting with files on disk

## gRPC Server

- Add gRPC tools references

`<PackageReference Include="Grpc.AspNetCore" Version="2.32.0" />`

- Define a protobuf file and reference

`<Protobuf Include="Protos\greet.proto" GrpcServices="Server" />`

- ASP.NET Core generates services and message classes
- Implement the service similar to a Controller

## gRPC Client

- Add gRPC package references: `Grpc.Net.ClientFactory`, `Grpc.Tools`
- Import a protobuf file

`<Protobuf Include="..\4_gRPC\Protos\greet.proto" GrpcServices="Client">`

- Connect to the client

```
using var channel = GrpcChannel.ForAddress("https://localhost:5001");
var client = new Greeter.GreeterClient(channel);
```

### Versioning gRPC

tldr; Add a version number to the package definition `greeter.v1`

Microsoft docs:  https://docs.microsoft.com/aspnet/core/grpc/versioning?view=aspnetcore-5.0