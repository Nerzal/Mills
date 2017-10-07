using System.Linq;
using Mills.ConsoleClient.Board;
using Mills.ConsoleClient.GameController;
using Mills.ConsoleClient.Player;

namespace Mills.ConsoleClient.Rules {
    /// <summary>
    /// Used to validate GameRules
    /// </summary>
    public class Evaluator : IMillRuleEvaluator {
        /// <inheritdoc />
        public IRuleSet Rules { get; }

        /// <inheritdoc />
        public IBoardAnalyzer BoardAnalyzer { get; }

        /// <inheritdoc />
        public Evaluator(IRuleSet rules) {
            this.Rules = rules;
            this.Rules.GameOverRules.Initialize();
            this.Rules.MoveValidationRules.Initialize();
        }

        /// <inheritdoc />
        public bool ValidateMovement(Move move) {
            return this.Rules.MoveValidationRules.All(movementRules => movementRules.Evaluate(move));
        }

        /// <inheritdoc />
        public bool IsGameOver(IBoard board) {
            return this.Rules.GameOverRules.All(gameOverRules => gameOverRules.Evaluate(board));
        }

        /// <inheritdoc />
        public GamePhases EvaluatePhase(IPlayer player) {
            if (player.Color == Colors.White) {
                if (this.BoardAnalyzer.Player1OffBoardStones > 0) {
                    return GamePhases.Set;
                } else if(this.BoardAnalyzer.CountPlayerSpots(Colors.White) == 3) {
                    return GamePhases.Jump;
                }
            } else {
                if (this.BoardAnalyzer.Player2OffBoardStones > 0) {
                    return GamePhases.Set;
                } else if (this.BoardAnalyzer.CountPlayerSpots(Colors.Black) == 3) {
                    return GamePhases.Jump;
                }
            }
            return GamePhases.Draw;
        }
    }
}