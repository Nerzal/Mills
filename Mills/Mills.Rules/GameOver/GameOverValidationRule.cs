using System;
using Mills.Game.Data.Contract;
using Mills.Rules.Contract;
using Mills.Rules.Rules;

namespace Mills.Rules.GameOver {
    /// <summary>
    /// Single rule for GameOver state
    /// </summary>
    public class GameOverValidationRule : ValidationRule<IBoard> {
        /// <inheritdoc />
        public GameOverValidationRule(Func<IBoard, bool> evaluator) : base(evaluator) {
        }
    }
}