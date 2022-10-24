using Microsoft.AspNetCore.Authorization;

internal class CanEditRequirement : IAuthorizationRequirement
{
  public CanEditRequirement()
  {
  }
}