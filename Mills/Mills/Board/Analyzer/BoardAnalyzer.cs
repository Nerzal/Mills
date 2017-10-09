using System;
using System.Linq;
using Mills.ConsoleClient.Player;

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
            return this.Board.Spots.SelectMany(level => level.OfType<Spot>())
                .Count(spot => spot?.Player?.Color == color);
        }

        /// <inheritdoc />
        public int GetDistance(Coordinate source, Coordinate destination) {
            int sumOfSourceCoordinate = source.Level + source.X + source.Y;
            int sumOfDestinationCoordinate = destination.Level + destination.X + destination.Y;
            int distance = Math.Abs(sumOfSourceCoordinate - sumOfDestinationCoordinate);
            return distance;
        }

        /// <inheritdoc />
        public IPlayer GetOccupier(Coordinate coordinate) {
            Spot spot = this.Board.Spots[coordinate.Level][coordinate.X, coordinate.Y];
            return spot.Player;
        }

        /// <inheritdoc />
        public bool IsValidCoordinate(Coordinate coordinate) {
            if (coordinate.Level == 2 && coordinate.X == 1 && coordinate.Y == 1) {
                //that would be the middle of the boardAnalyzer which is not a valid field
                return false;
            }

            if (coordinate.Level < 0 || coordinate.Level > this.Board.LevelCount - 1) {
                return false;
            }

            if (coordinate.X < 0 || coordinate.X > this.Board.DimensionCount - 1) {
                return false;
            }

            if (coordinate.Y < 0 || coordinate.Y > this.Board.DimensionCount - 1) {
                return false;
            }

            return true;
        }

        /// <inheritdoc />
        public bool IsFreeSpot(Coordinate coordinate) {
            return this.GetOccupier(coordinate) == null;
        }

        /// <inheritdoc />
        public bool CheckCoordinatesAreConnected(Coordinate source, Coordinate destination) {
            int distance = GetDistance(source, destination);
            if (distance > 1) {
                return false;
            }

            if (source.Level == destination.Level) {
                return true;
            }

            if (source.X == destination.X && source.Y == destination.Y) {
                if (source.X == 1) {
                    return true;
                }

                if (source.Y == 1) {
                    return true;
                }
            }

            return false;
        }
    }
}