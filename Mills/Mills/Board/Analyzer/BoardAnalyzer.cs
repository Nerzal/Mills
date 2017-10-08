using System;
using System.Linq;

namespace Mills.ConsoleClient.Board.Analyzer {
    /// <summary>
    /// Implements <see cref="IBoardAnalyzer"/>
    /// Holds functionality to analyze the board.
    /// </summary>
    public class BoardAnalyzer : IBoardAnalyzer {

        /// <inheritdoc />
        public IBoard Board { get; }

        /// <inheritdoc />
        public BoardAnalyzer(IBoard board) {
            this.Board = board;
        }

        /// <inheritdoc />
        public int CountPlayerSpots(Colors color) {
            return this.Board.Spots.SelectMany(level => level.Cast<Spot>())
                .Count(spot => spot?.Player?.Color == color);
        }

        public int GetDistance(Coordinate source, Coordinate destination) {
            int sumOfSourceCoordinate = source.Level + source.X + source.Y;
            int sumOfDestinationCoordinate = destination.Level + destination.X + destination.Y;
            int distance = Math.Abs(sumOfSourceCoordinate - sumOfDestinationCoordinate);
            return distance;
        }

        /// <summary>
        /// Checks if the spot is not occupied yet
        /// </summary>
        /// <param name="move"></param>
        /// <returns></returns>
        public bool IsFreeSpot(Coordinate coordinate) {
            return this.Board.Spots[coordinate.Level][coordinate.X, coordinate.Y] == null;
        }
    }
}