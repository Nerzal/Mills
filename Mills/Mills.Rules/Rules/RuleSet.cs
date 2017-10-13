using Mills.Rules.Contract;

namespace Mills.Rules.Rules {
  /// <inheritdoc />
  /// <summary>
  /// Holds all GameRules
  /// </summary>
  public class RuleSet : IRuleSet {
    /// <inheritdoc />
    public IMovementRules MoveValidationRules { get; }
    /// <inheritdoc />
    public IGameOverRules GameOverRules { get; }

    /// <summary>
    /// ctor
    /// </summary>
    /// <param name="moveValidationRules"></param>
    /// <param name="gameOverRules"></param>
    public RuleSet(
        IMovementRules moveValidationRules,
        IGameOverRules gameOverRules) {
      this.MoveValidationRules = moveValidationRules;
      this.GameOverRules = gameOverRules;
    }
  }
}