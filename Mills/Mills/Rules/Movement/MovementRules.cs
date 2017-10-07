using System.Collections;
using System.Collections.Generic;

namespace Mills.ConsoleClient.Rules.Movement {
    public class MovementRules : IMovementRules {
        public IEnumerator<ValidationRule<Move>> GetEnumerator() {
            throw new System.NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            throw new System.NotImplementedException();
        }
    }
}