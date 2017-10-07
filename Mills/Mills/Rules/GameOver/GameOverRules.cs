using System.Collections;
using System.Collections.Generic;

namespace Mills.ConsoleClient.Rules.GameOver {
    /// <summary>
    /// Holds all GameOver rules
    /// </summary>
    public class GameOverRules : IGameOverRules {
        private readonly ICollection<ValidationRule<IBoard>> _rules;

        /// <summary>
        /// ctor
        /// </summary>
        public GameOverRules() {
            this._rules = new List<ValidationRule<IBoard>>();
        }
        
        public void Initialize() {
            this._rules.Add(new GameOverValidationRule(PlayerHasMoreThan2Stones));
        }
        
        private bool PlayerHasMoreThan2Stones(IBoard arg) {
            int player1SpotCount = 0;
            int player2SpotCount = 0;

            foreach (Spot[,] level in arg.Spots) {
                foreach (Spot spot in level) {
                    if (spot.Player.Color == Colors.White) {
                        player1SpotCount++;
                    } else if (spot.Player.Color == Colors.Black) {
                        player2SpotCount++;
                    }
                }
            }

            return player2SpotCount > 2 && player1SpotCount > 2;
        }

        /// <inheritdoc />
        public IEnumerator<ValidationRule<IBoard>> GetEnumerator() {
            return this._rules.GetEnumerator();
        }

        /// <inheritdoc />
        IEnumerator IEnumerable.GetEnumerator() {
            return this._rules.GetEnumerator();
        }
    }
}