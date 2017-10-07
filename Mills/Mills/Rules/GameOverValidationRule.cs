using System;

namespace Mills.ConsoleClient.Rules {
  /// <summary>
  /// Single rule for GameOver state
  /// </summary>
    public class GameOverValidationRule : ValidationRule<IBoard> {
        /// <inheritdoc />
        public GameOverValidationRule(Func<IBoard, bool> evaluator) : base(evaluator) {
        }
    }
}