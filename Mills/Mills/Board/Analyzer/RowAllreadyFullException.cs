using System;

namespace Mills.ConsoleClient.Board.Analyzer {
    /// <inheritdoc />
    /// <summary>
    /// Used when AddToRow is called on a full row(mill)
    /// </summary>
    public class RowAllreadyFullException : Exception {
        /// <inheritdoc />
        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="row"></param>
        /// <param name="coordinate"></param>
        public RowAllreadyFullException(Row row, Coordinate coordinate) : base($"The row ") {
        }
    }
}