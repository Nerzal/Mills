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

        /// <summary>
        /// Returns the distance of 2 coordinates
        /// The distance is measured in fields
        /// </summary>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        /// <returns></returns>
        int GetDistance(Coordinate source, Coordinate destination);

        /// <summary>
        /// Checks if the spot is free
        /// </summary>
        /// <param name="coordinate"></param>
        /// <returns>true if the coordinate is not occupied</returns>
        bool IsFreeSpot(Coordinate coordinate);
    }
}