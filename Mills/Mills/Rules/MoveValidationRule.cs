using System;

namespace Mills.ConsoleClient.Rules {
    /// <summary>
    /// A single rule for movement
    /// </summary>
    public class MoveValidationRule : ValidationRule<Move> {
        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="evaluator"></param>
        public MoveValidationRule(Func<Move, bool> evaluator) : base(evaluator) { }
    }
}