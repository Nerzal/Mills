namespace Mills.Game.Data.Contract {
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
        /// Stones that are not set onto the board yet
        /// </summary>
        int Player1OffBoardStones { get; set; }

        /// <summary>
        /// Stones that are not set onto the board yet
        /// </summary>
        int Player2OffBoardStones { get; set; }

        /// <summary>
        /// The board itself
        /// </summary>
        Spot[][,] Spots { get; set; }
    }
}