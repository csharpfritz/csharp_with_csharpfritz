using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CodeActions;
using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Rename;
using Microsoft.CodeAnalysis.Text;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Composition;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BraceAnalyzer
{
	[ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(BraceAnalyzerCodeFixProvider)), Shared]
	public class BraceAnalyzerCodeFixProvider : CodeFixProvider
	{

		private const string title = "Fritz says Add Braces!";

		public sealed override ImmutableArray<string> FixableDiagnosticIds
		{
			get { return ImmutableArray.Create(BraceAnalyzerAnalyzer.DiagnosticId); }
		}

		public sealed override FixAllProvider GetFixAllProvider()
		{
			// See https://github.com/dotnet/roslyn/blob/main/docs/analyzers/FixAllProvider.md for more information on Fix All Providers
			return WellKnownFixAllProviders.BatchFixer;
		}

		public sealed override async Task RegisterCodeFixesAsync(CodeFixContext context)
		{
			var root = await context.Document.GetSyntaxRootAsync(context.CancellationToken).ConfigureAwait(false);

			// TODO: Replace the following code with your own analysis, generating a CodeAction for each fix to suggest
			var diagnostic = context.Diagnostics.First();
			var diagnosticSpan = diagnostic.Location.SourceSpan;

			// Register a code action that will invoke the fix.
			context.RegisterCodeFix(
							CodeAction.Create(
									title: title,
									createChangedDocument: c => AddBracesAsync(context.Document, diagnostic, root),
									equivalenceKey: title),
							diagnostic);
		}

		Task<Document> AddBracesAsync(Document document, Diagnostic diagnostic, SyntaxNode root)
		{
			var statement = root.FindNode(diagnostic.Location.SourceSpan).FirstAncestorOrSelf<StatementSyntax>();
			var newRoot = root.ReplaceNode(statement, SyntaxFactory.Block(statement));
			return Task.FromResult(document.WithSyntaxRoot(newRoot));
		}

	}
}
