using System;
using Mills.Game.Data.Contract;
using Mills.Rules.Contract;

namespace Mills.Rules.Movement {
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