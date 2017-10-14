namespace Mills.Utils {
  /// <summary>
  /// Provides random values
  /// </summary>
  public interface IRandomProvider {
    /// <summary>
    /// Provides a random number below the given max range
    /// </summary>
    /// <param name="maxValue"></param>
    /// <returns></returns>
    int Next(int maxValue);
    /// <summary>
    /// Returns a random number inside the given range
    /// </summary>
    /// <param name="minValue"></param>
    /// <param name="maxValue"></param>
    /// <returns></returns>
    int Next(int minValue, int maxValue);
  }
}