using System;
using Mills.ConsoleClient.Rules;

namespace Mills.ConsoleClient {
  internal class GameController : IGameController {
    public event Action<IPlayer> PlayerWon;

    private IPlayer _player1;
    private IPlayer _player2;
    private readonly IBoard _board;
    private readonly IRuleSet _ruleSet;
    private readonly IHistory _history;

    public IPlayer ActivePlayer { get; private set; }

    public int Round { get; private set; }

    public GameController(IRuleSet rules, IBoard board, IHistory history) {
      this._ruleSet = rules;
      this._board = board;
      this._history = history;
    }

    public void NewGame(IPlayer player1, IPlayer player2) {
      this._player1 = player1;
      this._player1.Color = Colors.White;
      this._player2 = player2;
      this._player2.Color = Colors.Black;
      this.ActivePlayer = this._player1;
      this.Round = 0;
    }

    public bool DoTurn(Move move) {
      if (!ValidateMove(move)) {
        return false;
      }
      ApplyMove(move);
      this.Round++;
      if (IsGameOver()) {
        this.PlayerWon?.Invoke(this.ActivePlayer);
      }
      SetActivePlayer();
      return true;
    }

    private bool IsGameOver() {
      foreach (ValidationRule<IBoard> rule in this._ruleSet.GameOverRules) {
        if (!rule.Evaluate(this._board)) {
          return false;
        }
      }
      return true;
    }

    private void ApplyMove(Move mühv) {
      this._board.Move(mühv);
      this._history.Add(mühv);
    }

    private bool ValidateMove(Move mühv) {
      foreach (ValidationRule<Move> rule in this._ruleSet.MoveValidationRules) {
        if (!rule.Evaluate(mühv)) {
          return false;
        }
      }
      return true;
    }

    private void SetActivePlayer() {
      if (this.Round % 2 == 1) {
        this.ActivePlayer = this._player2;
      } else {
        this.ActivePlayer = this._player1;
      }
    }
  }
}