using System.Linq;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace _3_Version {

public class RemoveVersionFromParameter : IOperationFilter
{
    private readonly ILogger _Logger;

    public RemoveVersionFromParameter(ILoggerFactory loggerFactory)
  {
    _Logger = loggerFactory.CreateLogger("Filters");
  }

    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        var versionParameter = operation.Parameters.Single(p => p.Name == "version");
        _Logger.LogWarning($"Version Parameter: {versionParameter.Name}");
        operation.Parameters.Remove(versionParameter);
    }

  }

public class ReplaceVersionWithExactValueInPath : IDocumentFilter
{
    public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
    {
        var paths = new OpenApiPaths();
        foreach (var path in swaggerDoc.Paths)
        {
            paths.Add(path.Key.Replace("v{version}", swaggerDoc.Info.Version), path.Value);
        }
        swaggerDoc.Paths = paths;
        
    }

}


}