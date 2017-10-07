namespace Mills.ConsoleClient.Rules {
    /// <summary>
    /// Validates the rules
    /// </summary>
    public interface IRuleValidator {
        /// <summary>
        /// A set of rules
        /// </summary>
        IRuleSet Rules { get; }
    }
}