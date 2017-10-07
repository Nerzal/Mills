using System;

namespace Mills.ConsoleClient {
  public abstract class ValidationRule<TValidateable>  {
    private readonly Func<TValidateable, bool> _evaluator;

    protected ValidationRule(Func<TValidateable, bool> evaluator) {
      this._evaluator = evaluator;
    }

    public bool Evaluate(TValidateable element) {
      return this._evaluator(element);
    }
  }
}