namespace Mills.ConsoleClient.Rules {
    /// <summary>
    /// Validator to determine if the game is in a gameover state
    /// </summary>
    public interface IGameOverValidator {
        /// <summary>
        /// Is this game over?
        /// </summary>
        /// <param name="board">the board</param>
        /// <returns>true when the game is over</returns>
        bool IsGameOver(IBoard board);
    }
}