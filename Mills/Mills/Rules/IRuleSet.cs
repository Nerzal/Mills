using System.Collections.Generic;
using Mills.ConsoleClient.Rules.GameOver;
using Mills.ConsoleClient.Rules.Movement;

namespace Mills.ConsoleClient.Rules {
    /// <summary>
    /// Set of rules
    /// </summary>
    public interface IRuleSet {
        /// <summary>
        /// Rules for movement
        /// </summary>
        IMovementRules MoveValidationRules { get; }

        /// <summary>
        /// Rules that check gameover state
        /// </summary>
        IGameOverRules GameOverRules { get; }
    }
}