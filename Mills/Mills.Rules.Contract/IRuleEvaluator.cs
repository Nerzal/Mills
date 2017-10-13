namespace Mills.Rules.Contract {
    /// <summary>
    /// Validates the rules
    /// </summary>
    public interface IRuleEvaluator {
        /// <summary>
        /// A set of rules
        /// </summary>
        IRuleSet Rules { get; }
    }
}