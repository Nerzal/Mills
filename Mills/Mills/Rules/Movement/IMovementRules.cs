using System.Collections.Generic;

namespace Mills.ConsoleClient.Rules.Movement {
    public interface IMovementRules : IEnumerable<ValidationRule<Move>> {
    }
}