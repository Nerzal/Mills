using System.Collections.Generic;

namespace Mills.ConsoleClient.Rules {
  /// <summary>
  /// Set of rules
  /// </summary>
  public interface IRuleSet {
    /// <summary>
    /// Rules for movement
    /// </summary>
    IEnumerable<ValidationRule<Move>> MoveValidationRules { get; }
    /// <summary>
    /// Rules that check gameover state
    /// </summary>
    IEnumerable<ValidationRule<IBoard>> GameOverRules { get; }
  }
}