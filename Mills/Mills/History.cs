using System.Collections.Generic;

namespace Mills.ConsoleClient {
    /// <summary>
    /// Implementation of <see cref="IHistory"/>
    /// Holds a the history of every move that have been made in a single game
    /// </summary>
    public class History : IHistory {
        private readonly Stack<Move> _moves;

        public History() {
            this._moves = new Stack<Move>();
        }

        public History(Stack<Move> moves) {
            this._moves = moves;
        }

        public void Add(Move move) {
            this._moves.Push(move);
        }
    }
}