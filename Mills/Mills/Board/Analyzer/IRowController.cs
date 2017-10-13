namespace Mills.ConsoleClient.Board.Analyzer {
    /// <summary>
    /// Controller for <see cref="Row"/>s
    /// </summary>
    public interface IRowController {
        /// <summary>
        /// Adds a coordinate into a row
        /// </summary>
        /// <param name="row">the row the coordinate will be added too</param>
        /// <param name="coordinate">the coordinate to add</param>
        void AddToRow(Row row, Coordinate coordinate);
        /// <summary>
        /// Checks if a row is a mill
        /// </summary>
        /// <param name="row">the row to check</param>
        /// <returns>true if there are 3 coordinates in a row</returns>
        bool IsMill(Row row);
        /// <summary>
        /// Checks if a row contains a coordinate
        /// </summary>
        /// <param name="row"></param>
        /// <param name="coordinate"></param>
        /// <returns></returns>
        bool Contains(Row row, Coordinate coordinate);
    }
}