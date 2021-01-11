using Swashbuckle.AspNetCore.SwaggerGen;

namespace _3_Version {

public class RemoveVersionFromParameter : IOperationFilter
{
    public void Apply(Operation operation, OperationFilterContext context)
    {
        var versionParameter = operation.Parameters.Single(p => p.Name == "version");
        operation.Parameters.Remove(versionParameter);
    }
}

public class ReplaceVersionWithExactValueInPath : IDocumentFilter
{
    public void Apply(SwaggerDocument swaggerDoc, DocumentFilterContext context)
    {
        swaggerDoc.Paths = swaggerDoc.Paths
            .ToDictionary(
                path => path.Key.Replace("v{version}", swaggerDoc.Info.Version),
                path => path.Value
            );
    }
}


}