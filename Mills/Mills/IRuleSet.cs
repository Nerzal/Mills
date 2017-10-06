using System.Collections.Generic;

namespace Mills {
  public interface IRuleSet {
    IEnumerable<ValidationRule<Move>> MoveValidationRules { get; }
    IEnumerable<ValidationRule<IBoard>> GameOverRules { get; }
  }
}