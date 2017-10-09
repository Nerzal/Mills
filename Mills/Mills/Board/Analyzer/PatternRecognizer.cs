using System.Collections.Generic;
using System.Linq;
using Mills.ConsoleClient.Player;

namespace Mills.ConsoleClient.Board.Analyzer {
    /// <summary>
    /// Implementation of <see cref="IPatternRecognizer"/>
    /// Finds all rows and mills
    /// </summary>
    public class PatternRecognizer : IPatternRecognizer {
        
        /// <inheritdoc />
        public IBoard Board { get; }

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="board"></param>
        public PatternRecognizer(IBoard board) {
            this.Board = board;
        }

        /// <inheritdoc />
        public IEnumerable<Row> FindAllRowsFor(IPlayer player) {
            ICollection<Row> result = new List<Row>();
            
            return result;
        }

        /// <inheritdoc />
        public IEnumerable<Row> FindAllMillsFor(IPlayer player) {
            return this.FindAllRowsFor(player).Where(row => row.IsMill);
        }
    }
}