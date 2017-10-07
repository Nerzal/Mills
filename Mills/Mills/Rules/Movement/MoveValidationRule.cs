using System;
using Mills.ConsoleClient.GameController;

namespace Mills.ConsoleClient.Rules.Movement {
    /// <summary>
    /// A single rule for movement
    /// </summary>
    public class MoveValidationRule : ValidationRule<Move> {
        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="evaluator"></param>
        public MoveValidationRule(Func<Move, bool> evaluator) : base(evaluator) {
        }
    }
}