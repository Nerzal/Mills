using System;

namespace Mills {
  internal abstract class ValidationRule<T> {
    private readonly Func<T, bool> _evaluator;

    protected ValidationRule(Func<T, bool> evaluator) {
      this._evaluator = evaluator;
    }

    public bool Evaluate(T element) {
      return this._evaluator(element);
    }
  }
}