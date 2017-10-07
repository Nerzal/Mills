using Mills.ConsoleClient.GameController;

namespace Mills.ConsoleClient.Rules.Movement {
    /// <summary>
    /// MoveMentValidator
    /// </summary>
    public interface IMovementEvaluator {
        /// <summary>
        /// Validates if the move is valid
        /// </summary>
        /// <param name="move"></param>
        /// <returns>true for valid moves</returns>
        bool ValidateMovement(Move move);
    }
}