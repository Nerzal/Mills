using Mills.ConsoleClient.Player;

namespace Mills.ConsoleClient.Board.Analyzer {
    /// <summary>
    /// Created by the PatternRecognizer to identify mills and possible mills
    /// </summary>
    public class Row {
        /// <summary>
        /// The Player to own this row
        /// </summary>
        public IPlayer Player { get; set; }
        /// <summary>
        /// First element of the row
        /// </summary>
        public Coordinate? First { get; set; }
        /// <summary>
        /// Second element of the row
        /// </summary>
        public Coordinate? Second { get; set; }
        /// <summary>
        /// Third element of the row
        /// </summary>
        public Coordinate? Third { get; set; }
        /// <summary>
        /// A mill is found when there 3 coordinates in a row are occupied by the same player
        /// </summary>
        public bool IsMill => this.First != null && this.Second != null && this.Third != null;
    }
}