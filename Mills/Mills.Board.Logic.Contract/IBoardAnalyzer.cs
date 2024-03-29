﻿using Mills.Game.Data.Contract;

namespace Mills.Board.Logic.Contract {
    /// <summary>
    /// Analyzes the board
    /// </summary>
    public interface IBoardAnalyzer {
        /// <summary>
        /// The games board
        /// </summary>
        IBoard Board { get; }

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

        /// <summary>
        /// Checks if the spot is free
        /// </summary>
        /// <param name="coordinate"></param>
        /// <returns>true if the coordinate is not occupied</returns>
        IPlayer GetOccupier(Coordinate coordinate);

        /// <summary>
        /// Checks if the destination is a valid coordinate
        /// </summary>
        /// <param name="coordinate"></param>
        /// <returns></returns>
        bool IsValidCoordinate(Coordinate coordinate);

        /// <summary>
        /// Checks if the fields of the 2 given coordinates are connected
        /// </summary>
        /// <param name="source">first field</param>
        /// <param name="destination">second field</param>
        /// <returns></returns>
        bool CheckCoordinatesAreConnected(Coordinate source, Coordinate destination);
    }
}