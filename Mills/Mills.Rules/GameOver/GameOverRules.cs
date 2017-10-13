using Mills.Board.Logic.Contract;
using Mills.Game.Data.Contract;
using Mills.Rules.Contract;
using Mills.Rules.Rules;

namespace Mills.Rules.GameOver {

  /// <inheritdoc cref="IGameOverRules"/>
  /// <summary>
  /// Holds all GameOver rules.
  /// See also <seealso cref="BaseRules{TEvaluationObject}"/>
  /// </summary>
  public class GameOverRules : BaseRules<IBoard>, IGameOverRules {
    /// <inheritdoc />
    public IBoardAnalyzer BoardAnalyzer { get; }

    /// <inheritdoc />
    /// <summary>
    /// ctor
    /// </summary>
    /// <param name="boardAnalyzer"></param>
    public GameOverRules(IBoardAnalyzer boardAnalyzer) {
      this.BoardAnalyzer = boardAnalyzer;
    }

    public override void Initialize() {
      this.Rules.Add(new GameOverValidationRule(PlayerHasLessThan3Stones));
    }

    private bool PlayerHasLessThan3Stones(IBoard board) {
      int player1SpotCount = this.BoardAnalyzer.CountPlayerSpots(Colors.White);
      int player2SpotCount = this.BoardAnalyzer.CountPlayerSpots(Colors.Black);

      //In phase 1 the offBoardStones need to be added to the count
      player1SpotCount += this.BoardAnalyzer.Board.Player1OffBoardStones;
      player2SpotCount += this.BoardAnalyzer.Board.Player2OffBoardStones;

      bool playerHasLessThan3Stones = player2SpotCount < 3 || player1SpotCount < 3;
      return playerHasLessThan3Stones;
    }
  }
}