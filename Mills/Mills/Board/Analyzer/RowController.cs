using System;

namespace Mills.ConsoleClient.Board.Analyzer {
    /// <inheritdoc />
    /// <summary>
    /// Implementation of <see cref="IRowController"/>
    /// </summary>
    public class RowController : IRowController {
        /// <inheritdoc />
        public void AddToRow(Row row, Coordinate coordinate) {
            if (row == null) {
                throw new ArgumentNullException($"{nameof(row)} was null");
            }

            if (row.First == null) {
                row.First = coordinate;
            } else if (row.Second == null) {
                row.Second = coordinate;
            } else if (row.Third == null) {
                row.Third = coordinate;
            } else {
                throw new RowAllreadyFullException(row, coordinate);
            }
        }

        /// <inheritdoc />
        public bool IsMill(Row row) {
            if (row == null) {
                throw new ArgumentNullException($"{nameof(row)} was null");
            }

            return row.First != null && row.Second != null && row.Third != null;
        }

        /// <inheritdoc />
        public bool Contains(Row row, Coordinate coordinate) {
            if (row.First != null && row.First.Value.Equals(coordinate)) {
                return true;
            } else if (row.Second != null && row.Second.Value.Equals(coordinate)) {
                return true;
            } else if (row.Third != null && row.Third.Value.Equals(coordinate)) {
                return true;
            }

            return false;
        }
    }
}