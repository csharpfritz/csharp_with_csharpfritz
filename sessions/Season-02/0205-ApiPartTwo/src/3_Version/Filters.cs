using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3_Version
{
  public class RemoveVersionFromParameter : IOperationFilter
  {
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
      var versionParameter = operation.Parameters.Single(p => p.Name == "version");
      operation.Parameters.Remove(versionParameter);
    }
  }

  public class ReplaceVersionWithExactValueInPath : IDocumentFilter
  {
    public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
    {
      if (swaggerDoc == null)
      {
        throw new ArgumentNullException(nameof(swaggerDoc));
      }

      var replacements = new OpenApiPaths();

      foreach (var (key, value) in swaggerDoc.Paths)
      {
        replacements.Add(key.Replace("{version}", swaggerDoc.Info.Version,
                StringComparison.InvariantCulture), value);
      }

      swaggerDoc.Paths = replacements;
    }
  }
}
