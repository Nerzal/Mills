using System;

namespace Mills.ConsoleClient {
  public class MoveValidationRule : ValidationRule<Move> {
    public MoveValidationRule(Func<Move, bool> evaluator) : base(evaluator) { }
  }
}