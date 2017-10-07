using System.Collections.Generic;
using Mills.ConsoleClient.GameController;

namespace Mills.ConsoleClient {
    /// <summary>
    /// Implementation of <see cref="IHistory"/>
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

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="moves"></param>
        public History(Stack<Move> moves) {
            this._moves = moves;
        }
        /// <summary>
        /// <inheritdoc cref="IHistory.Add"/>
        /// </summary>
        /// <param name="move"></param>
        public void Add(Move move) {
            this._moves.Push(move);
        }
    }
}