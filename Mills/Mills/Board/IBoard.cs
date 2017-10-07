namespace Mills.ConsoleClient.Board {
    /// <summary>
    /// The games board
    /// </summary>
    public interface IBoard {
        /// <summary>
        /// Count of the levels
        /// </summary>
        int LevelCount { get; }

        /// <summary>
        /// Count of the dimension
        /// </summary>
        int DimensionCount { get; }

        /// <summary>
        /// The board itself
        /// </summary>
        Spot[][,] Spots { get; set; }
    }
}