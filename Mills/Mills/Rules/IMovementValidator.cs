namespace Mills.ConsoleClient.Rules {
    /// <summary>
    /// MoveMentValidator
    /// </summary>
    public interface IMovementValidator {
        /// <summary>
        /// Validates if the move is valid
        /// </summary>
        /// <param name="move"></param>
        /// <returns>true for valid moves</returns>
        bool ValidateMovement(Move move);
    }
}