using System;

namespace Mills.Utils {
  /// <summary>
  /// Wrapper for the .NET Random-Class
  /// </summary>
  public class RandomProvider : IRandomProvider {
    private readonly Random _random;
    /// <summary>
    /// ctor
    /// </summary>
    public RandomProvider() {
      this._random = new Random();
    }

   /// <inheritdoc cref="IRandomProvider.Next(int)"/>
    public int Next(int maxValue) {
      return this._random.Next(maxValue);
    }
    /// <inheritdoc cref="IRandomProvider.Next(int, int)"/>
    public int Next(int minValue, int maxValue) {
      return this._random.Next(minValue, maxValue);
    }
  }
}