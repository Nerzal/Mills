using System.Collections.Generic;

namespace Mills.ConsoleClient {
    /// <summary>
    /// The games board
    /// </summary>
    public interface IBoard {
        /// <summary>
        /// Stones that are not set onto the board yet
        /// </summary>
        int Player1OffBoardStones { get; }

        /// <summary>
        /// Stones that are not set onto the board yet
        /// </summary>
        int Player2OffBoardStones { get; }

        /// <summary>
        /// Count of the levels
        /// </summary>
        int LevelCount { get; }

        /// <summary>
        /// Count of the dimension
        /// </summary>
        int DimensionCount { get; }

        /// <summary>
        /// Holds all valid spots
        /// </summary>
        IEnumerable<Coordinate> ValidCoordinates { get; }

        /// <summary>
        /// Initializes the board with the default state
        /// </summary>
        void Initialize();

        /// <summary>
        /// Applies a move onto the board
        /// </summary>
        /// <param name="move"></param>
        void Move(Move move);

        /// <summary>
        /// The board itself
        /// </summary>
        Spot[][,] Spots { get; set; }
    }
}