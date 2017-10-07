namespace Mills.ConsoleClient.Board {
    /// <summary>
    /// Analyzes the board
    /// </summary>
    public interface IBoardAnalyzer {
        /// <summary>
        /// Stones that are not set onto the board yet
        /// </summary>
        int Player1OffBoardStones { get; }

        /// <summary>
        /// Stones that are not set onto the board yet
        /// </summary>
        int Player2OffBoardStones { get; }

        /// <summary>
        /// Counts all spots owned by the given color
        /// </summary>
        /// <param name="color">the color of the player</param>
        /// <returns></returns>
        int CountPlayerSpots(Colors color);
    }
}