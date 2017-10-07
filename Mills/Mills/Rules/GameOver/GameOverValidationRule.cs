using System;
using Mills.ConsoleClient.Board;

namespace Mills.ConsoleClient.Rules.GameOver {
    /// <summary>
    /// Single rule for GameOver state
    /// </summary>
    public class GameOverValidationRule : ValidationRule<IBoard> {
        /// <inheritdoc />
        public GameOverValidationRule(Func<IBoard, bool> evaluator) : base(evaluator) {
        }
    }
}