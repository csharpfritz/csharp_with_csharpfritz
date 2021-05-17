# 0403 - Continuous Integration

Continuous Integration describes a process by which every source code check-in, every integration and interaction with source code is automatically checked for compliance within project standards.  This is typically accomplished through a 'build' process and optional test processes that may run concurrently or regularly against the project.

A similar companion process is **Continuous Deployment** that describes the successful outcome of Continuous Integration that is delivered to webservers, application servers, app stores, and download sites for users to immediately begin using new versions of software.

Donovan Brown defines DevOps as the union of people, process, and products to enable continuous delivery of value to our end users.

Continuous Integration is just one piece of the DevOps practice, and the focus of this module for C# developers.

## Tools for Continuous Integration

- .NET SDK
- A [continuous integration service](https://github.com/ligurio/awesome-ci) -- may run online or locally
  - GitHub Actions
  - [Azure DevOps](https://docs.microsoft.com/azure/devops/pipelines/get-started/what-is-azure-pipelines?view=azure-devops)
  - Jetbrains TeamCity
  - Jenkins
  - Travis CI
  - AWS CodeBuild
  - CruiseControl / CruiseControl.NET

## Main Steps of Continuous Integration

- Restore dependencies
- Check source code - C# compile
- Run unit tests
- Other tests, source code inspections
- Publish Artifacts (outputs)
- Record Status

## GitHub WebHooks

### GitHub Actions

### Azure DevOps

### TeamCity

### Introducing Tests to the process

### Continuous Build and Deployment -- Azure Static Website Sample