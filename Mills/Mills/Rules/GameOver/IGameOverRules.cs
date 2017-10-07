using System.Collections.Generic;

namespace Mills.ConsoleClient.Rules.GameOver {
    /// <summary>
    /// ENumerable of GameOverRules
    /// </summary>
    public interface IGameOverRules : IEnumerable<ValidationRule<IBoard>> {
    }
}