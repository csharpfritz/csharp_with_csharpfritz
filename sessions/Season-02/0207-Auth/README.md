# Session 7 - Authentication and Authorization

Official get started tutorial:  https://docs.microsoft.com/aspnet/core/security/authentication/identity?view=aspnetcore-5.0

Scaffold Identity https://docs.microsoft.com/aspnet/core/security/authentication/scaffold-identity?view=aspnetcore-5.0

Add Custom User fields

Update UI

Generate migrations, update database

https://github.com/aspnet-contrib/AspNet.Security.OAuth.Providers


## Authorization

Add Roles

https://docs.microsoft.com/en-us/aspnet/core/security/authorization/razor-pages-authorization?view=aspnetcore-5.0

AllowAnonymous attribute

Authorize attribute

[Authorize(Roles = "Administrator")]

On Razor Pages:
services.AddRazorPages(options =>
{
    options.Conventions.AuthorizePage("/Contact");
    options.Conventions.AuthorizeFolder("/Private");
    options.Conventions.AllowAnonymousToPage("/Private/PublicPage");
    options.Conventions.AllowAnonymousToFolder("/Private/PublicPages");
});


Policies with roles
services.AddAuthorization(options =>
    {
        options.AddPolicy("RequireAdministratorRole",
             policy => policy.RequireRole("Administrator"));
    });





@foreach (var claim in User.Claims)
{
		<p><b>@claim.Type</b> @claim.Value</p>
}


### View based Auth

https://docs.microsoft.com/aspnet/core/security/authorization/views?view=aspnetcore-5.0

@using Microsoft.AspNetCore.Authorization
@inject IAuthorizationService AuthorizationService

@if ((await AuthorizationService.AuthorizeAsync(User, "PolicyName")).Succeeded)
{
    <p>This paragraph is displayed because you fulfilled PolicyName.</p>
}