using System;
using Mills.Board.Data.Contract.Data;

namespace Mills.Board.Data.Contract.Exceptions {
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