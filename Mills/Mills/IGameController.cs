using System;

namespace Mills {
  public interface IGameController {
    event Action<IPlayer> PlayerWon;

    IPlayer ActivePlayer { get; }

    void NewGame(IPlayer player1, IPlayer player2);

    bool DoTurn(Move mühv);
  }
}