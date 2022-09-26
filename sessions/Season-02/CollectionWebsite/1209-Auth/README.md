# Session 1209: Authentication and Authorization

The website is interesting, but it's not very useful if you can't log in.  We'll introduce a login mechanism using Identity and then introduce authorization using Identity and the `Authorize` attribute.

## Agenda

1. Let's add the [Identity components](https://learn.microsoft.com/aspnet/core/security/authentication/scaffold-identity) to our project.  

1. We'll update our Entity Framework context to also be the context for our authentication database.	This will allow us to use the same database for both our application and our authentication.

1. The `dotnet` command line tool will create a new migration for the identity provider.  We'll apply that migration to our database.

1. Users will need to be able to login to our website.  Let's add the _LoginPartial to our navigation and update our routing to include a call to MapRazorPages.

1. Let's require a user to be logged in to access the _Create_ and _Edit_ pages.  We'll use the `Authorize` attribute to do this.

1. We'll add a check if a user is authorized to edit an item.  If they are not, we'll hide the _Edit_ and _Delete_ links.  This uses the [IAuthorizationService](https://learn.microsoft.com/aspnet/core/security/authorization/views?view=aspnetcore-6.0) in our views