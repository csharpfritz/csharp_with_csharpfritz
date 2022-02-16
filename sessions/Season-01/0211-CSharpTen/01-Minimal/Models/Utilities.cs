using System.Runtime.CompilerServices;

namespace _01_Minimal.Models;

public class Utilities 
{

	public static void ValidateArgument( 
		string parameterName, 
		bool condition, 
		[CallerArgumentExpression("condition")] string? message=null)
		{
			if (!condition)
			{
				throw new ArgumentException(message, parameterName);
			}
		}

}