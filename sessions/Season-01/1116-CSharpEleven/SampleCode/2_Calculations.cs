using System.Numerics;

namespace CSharpEleven;

internal static class Calculations
{

  public static TResult Sum<T, TResult>(IEnumerable<T> values)
      where T : INumber<T>
      where TResult : INumber<TResult>
  {
    TResult result = TResult.Zero;

    foreach (var value in values)
    {
      result += TResult.CreateChecked(value);
    }

    return result;
  }

  public static TResult Average<T, TResult>(IEnumerable<T> values)
      where T : INumber<T>
      where TResult : INumber<TResult>
  {
    TResult sum = Sum<T, TResult>(values);
    return TResult.CreateChecked(sum) / TResult.CreateChecked(values.Count());
  }

}
