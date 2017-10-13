namespace Mills.Rules.Contract {
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