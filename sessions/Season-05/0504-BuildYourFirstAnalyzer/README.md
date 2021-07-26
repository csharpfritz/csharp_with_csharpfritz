# 0504 - Build Your First Analyzer

In this session, we're going to take on an advanced topic that will help you write better code by building a tool that analyzes your code and provides suggestions as well as automatic code fixes.  In .NET, an **analyzer** is a code module that recognizes violations of a coding rule you define. We can write and deliver a **code fix** that fixes the violation.

The GitHub repository maintained by the .NET Team with recommended Roslyn Analyzers that will help you write better code is at https://github.com/dotnet/roslyn-analyzers

These Code Analysis (CA) rules detect and recommend updates for you in Visual Studio Code and Visual Studio.

## First... a brain-teaser

[Top of the Types puzzle](https://github.com/csharpfritz/csharp-workshop/blob/main/puzzles/2_TopOfTheType.ipynb)

## Prerequisites

Visual Studio 2019 is required to build analyzers.  You will also need to install the following features:

- .NET Desktop Development workload
- Visual Studio Extension Development workload
- .NET Compiler Platform SDK

![Visual Studio Installer - Extension Workload selection](https://devblogs.microsoft.com/dotnet/wp-content/uploads/sites/10/2022/03/visual-studio-extension-development.png)

![Visual Studio Installer - .NET Compiler SDK](https://devblogs.microsoft.com/dotnet/wp-content/uploads/sites/10/2022/03/visual-studio-individual-components.png)

## The BraceAnalyzer

Let's start with an example from [Mika on the .NET team](https://devblogs.microsoft.com/dotnet/how-to-write-a-roslyn-analyzer/) that recommends we add braces around block-level statements.

In Visual Studio, start by creating a project of type *"Analyzer with Code Fix (.NET Standard)"*  We'll name the project **BraceAnalyzer** and Visual Studio will generate three projects for us:

- **BraceAnalyzer** - contains the code that will report on violations of the rule we define
- **BraceAnalyzer.CodeFixes** - contains the code fix
- **BraceAnalyzer.Package** - scripts to produce the NuGet package for the Analyzer and CodeFix
- **BraceAnalyzer.Test** - A unit test project to help validate the analyzer
- **BraceAnalyzer.Vsix** - A Visual Studio extension that bundles and delivers the analyzer

## MakeConst Analyzer

Walkthrough at: https://docs.microsoft.com/dotnet/csharp/roslyn-sdk/tutorials/how-to-write-csharp-analyzer-code-fix