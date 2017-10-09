using System.Collections.Generic;
using Mills.ConsoleClient.GameController;

namespace Mills.ConsoleClient {
  /// <inheritdoc />
  /// <summary>
  /// Implementation of <see cref="T:Mills.ConsoleClient.IHistory" />
  /// Holds a the history of every move that have been made in a single game
  /// </summary>
  public class History : IHistory {
    private readonly Stack<Move> _moves;

    /// <summary>
    /// ctor
    /// </summary>
    public History() {
      this._moves = new Stack<Move>();
    }

    /// <inheritdoc />
    public void Add(Move move) {
      this._moves.Push(move);
    }
  }
}