using Mills.Game.Data.Contract;

namespace Mills.Rules.Contract {
    /// <summary>
    /// Evaluator to determine if the game is in a gameover state
    /// </summary>
    public interface IGameOverEvaluator {
        /// <summary>
        /// Is this game over?
        /// </summary>
        /// <param name="board">the board</param>
        /// <returns>true when the game is over</returns>
        bool IsGameOver(IBoard board);
    }
}