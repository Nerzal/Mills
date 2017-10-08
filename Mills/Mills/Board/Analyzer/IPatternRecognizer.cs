using System.Collections.Generic;
using Mills.ConsoleClient.Player;

namespace Mills.ConsoleClient.Board.Analyzer {
    /// <summary>
    /// Analyzes the Board and finds Rows.
    /// A Mill is a row of 3
    /// </summary>
    public interface IPatternRecognizer {
        /// <summary>
        /// Finds all rows of the given player
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        IEnumerable<Row> FindAllRowsFor(IPlayer player);

        /// <summary>
        /// Finds all mills for the given player
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        IEnumerable<Row> FindAllMillsFor(IPlayer player);
    }
}