# Session 1210: Deployment

Let's deploy our application with Linux to Microsoft Azure App Service.

## Notes

- Install and run .NET with scripts from [dot.net](https://dot.net)
- Configure Omnisharp for vim, emacs, and your favorite editors [here](https://omnisharp.net)
- Configure [SQL Server for local development using Docker](https://learn.microsoft.com/sql/linux/quickstart-install-connect-docker)
- [Deploy to Azure App Service with Azure Portal, Azure CLI, or Visual Studio](https://learn.microsoft.com/azure/app-service/quickstart-dotnetcore)

## Follow-up

This application uses a SQLite database that resides outside of the `wwwroot` folder.  To get this file copied to the output folder and carried to the production space on Azure, the following entry was needed in the MyCollectionWebsite.csproj file to direct the `dotnet` tool to include the database file in the publish step:

```xml
    <None Include="MyCollectionSite.db" CopyToPublishDirectory="Always" />
```
