using Mills.Board.Logic.Contract;
using Mills.Game.Contract;
using Mills.Game.Contract.Data;
using Mills.Game.Data.Contract;
using Mills.Game.GameController;
using Mills.Rules.Contract;

namespace Mills.Rules.Rules {
  /// <inheritdoc />
  /// <summary>
  /// Used to validate GameRules
  /// </summary>
  public class Evaluator : IMillRuleEvaluator {
    /// <inheritdoc />
    public IRuleSet Rules { get; }

    /// <inheritdoc />
    public IBoardAnalyzer BoardAnalyzer { get; }

    /// <inheritdoc />
    public Evaluator(IRuleSet rules, IBoardAnalyzer analyzer) {
      this.Rules = rules;
      this.Rules.GameOverRules.Initialize();
      this.Rules.MoveValidationRules.Initialize();

      this.BoardAnalyzer = analyzer;
    }

    /// <inheritdoc />
    public bool ValidateMovement(Move move) {
      return this.Rules.MoveValidationRules.Evaluate(move);
    }

    /// <inheritdoc />
    public bool IsGameOver(IBoard board) {
      return this.Rules.GameOverRules.Evaluate(board);
    }

    /// <inheritdoc />
    public GamePhases EvaluatePhase(IPlayer player) {
      if (player.Color == Colors.White) {
        if (this.BoardAnalyzer.Board.Player1OffBoardStones > 0) {
          return GamePhases.Set;
        }

        if (this.BoardAnalyzer.CountPlayerSpots(Colors.White) == 3) {
          return GamePhases.Jump;
        }
      } else {
        if (this.BoardAnalyzer.Board.Player2OffBoardStones > 0) {
          return GamePhases.Set;
        }

        if (this.BoardAnalyzer.CountPlayerSpots(Colors.Black) == 3) {
          return GamePhases.Jump;
        }
      }
      return GamePhases.Draw;
    }
  }
}