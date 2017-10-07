using System.Collections;
using System.Collections.Generic;

namespace Mills.ConsoleClient.Rules {
  /// <summary>
  /// Set of rules
  /// </summary>
  public interface IRuleSet {
    /// <summary>
    /// Rules for movement
    /// </summary>
    IEnumerable<ValidationRule<Move>> MoveValidationRules { get; }
    /// <summary>
    /// Rules that check gameover state
    /// </summary>
    IEnumerable<ValidationRule<IBoard>> GameOverRules { get; }
  }

    public interface IMovementRules : IEnumerable<ValidationRule<Move>> {
              
    }

    public interface IGameOverRules : IEnumerable<ValidationRule<IBoard>> {

    }

    public class MovementRules : IMovementRules
    {
        public IEnumerator<ValidationRule<Move>> GetEnumerator()
        {
            throw new System.NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new System.NotImplementedException();
        }
    }

    public class GameOverRules : IGameOverRules
    {
        public IEnumerator<ValidationRule<IBoard>> GetEnumerator()
        {
            throw new System.NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new System.NotImplementedException();
        }
    }
}