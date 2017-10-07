using System.Collections.Generic;

namespace Mills.ConsoleClient.Rules.GameOver {
    public interface IGameOverRules : IEnumerable<ValidationRule<IBoard>> {
    }
}