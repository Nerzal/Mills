using System.Collections.Generic;
using Mills.Game.Data.Contract;

namespace Mills.Board.Logic.Contract {
    /// <summary>
    /// Analyzes the Board and finds Rows.
    /// A Mill is a row of 3
    /// </summary>
    public interface IPatternRecognizer {
        /// <summary>
        /// The games board
        /// </summary>
        IBoard Board { get; }

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