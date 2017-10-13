using System;

namespace Mills.Ai.Simple {
  class RandomProvider : IRandomProvider {
    private readonly Random _random;

    public RandomProvider() {
      this._random = new Random();
    }

    public int Next(int maxValue) {
      return this._random.Next(maxValue);
    }

    public int Next(int minValue, int maxValue) {
      return this._random.Next(minValue, maxValue);
    }
  }
}