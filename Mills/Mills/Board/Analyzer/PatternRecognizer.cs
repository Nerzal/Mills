using System.Collections.Generic;
using Mills.ConsoleClient.Player;

namespace Mills.ConsoleClient.Board.Analyzer {
    /// <summary>
    /// Implementation of <see cref="IPatternRecognizer"/>
    /// Finds all rows and mills
    /// </summary>
    public class PatternRecognizer : IPatternRecognizer {
        /// <inheritdoc />
        public IEnumerable<Row> FindAllRowsFor(IPlayer player) {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc />
        public IEnumerable<Row> FindAllMillsFor(IPlayer player) {
            throw new System.NotImplementedException();
        }
    }
}