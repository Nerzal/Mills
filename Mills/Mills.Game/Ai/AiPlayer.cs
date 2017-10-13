using Mills.Board.Logic.Contract;
using Mills.Game.Contract;
using Mills.Game.Contract.Data;
using Mills.Game.Data.Contract;
using Mills.Game.GameController;
using Mills.Game.Player;

namespace Mills.Game.Ai {
  /// <summary>
  /// This class represents a Player, that is controlled by the computer
  /// It Analyzes the board and acts afterwards
  /// </summary>
  public abstract class AiPlayer : BasePlayer, IAiPlayer {
    private GamePhases _currentPhase;

    /// <inheritdoc />
    public IGameController GameController { get; }

    /// <inheritdoc />
    public IBoardAnalyzer BoardAnalyzer { get; }

    /// <inheritdoc />
    public GamePhases CurrentPhase => this._currentPhase;

    /// <inheritdoc />
    protected AiPlayer(IGameController controller, IBoardAnalyzer analyzer) : base("Computer") {
      this.GameController = controller;
      this.BoardAnalyzer = analyzer;
    }

    /// <inheritdoc />
    public Move Analyse() {
      this._currentPhase = GetCurrentPhase();
      return AnalyseInternal();
    }

    protected abstract Move AnalyseInternal();

    /// <inheritdoc />
    public void Act(Move move) {
      throw new System.NotImplementedException();
    }

    private GamePhases GetCurrentPhase() {
      // TODO if(this.BoardAnalyzer.CountPlayerSpots())
      return GamePhases.Set;
    }
  }
}