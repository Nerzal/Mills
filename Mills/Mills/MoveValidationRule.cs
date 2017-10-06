using System;

namespace Mills {
  public class MoveValidationRule : ValidationRule<Move> {
    public MoveValidationRule(Func<Move, bool> evaluator) : base(evaluator) { }
  }
}