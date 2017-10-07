using System;

namespace Mills.ConsoleClient {
    public class GameOverValidationRule : ValidationRule<IBoard> {
        /// <inheritdoc />
        public GameOverValidationRule(Func<IBoard, bool> evaluator) : base(evaluator) {
        }
    }
}