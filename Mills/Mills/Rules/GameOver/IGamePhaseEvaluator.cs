using Mills.ConsoleClient.Player;

namespace Mills.ConsoleClient.Rules.GameOver {
    /// <summary>
    /// Evaluates the current gamePhase for the given player
    /// </summary>
    public interface IGamePhaseEvaluator {
        /// <summary>
        /// Evaluates the current gamePhase for the given player
        /// </summary>
        /// <param name="player">The player to evaluate the phase for</param>
        /// <returns></returns>
        GamePhases EvaluatePhase(IPlayer player);
    }
}