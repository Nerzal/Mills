using System;
using Mills.ConsoleClient.Board;
using Mills.ConsoleClient.GameController;

namespace Mills.ConsoleClient.Rules.Movement {
    /// <summary>
    /// Extends <see cref="BaseRules{TEvaluationObject}"/>
    /// Implements <seealso cref="IMovementRules"/>
    /// 
    /// Holds all rules that are important for movement
    /// </summary>
    public class MovementRules : BaseRules<Move>, IMovementRules {

        /// <inheritdoc />
        public IBoard Board { get; }

        /// <inheritdoc />
        public MovementRules(IBoard board) {
            this.Board = board;
        }

        /// <inheritdoc cref="BaseRules{Move}" />
        public override void Initialize() {
            this.Rules.Add(new MoveValidationRule(IsValidCoordinate));
            this.Rules.Add(new MoveValidationRule(IsInRange));
            this.Rules.Add(new MoveValidationRule(IsConnected));
            this.Rules.Add(new MoveValidationRule(IsFreeSpot));
        }

        /// <summary>
        /// Checks if the destination is a valid coordinate
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        private bool IsValidCoordinate(Move arg) {
            if (arg.Destination.Level == 2 && arg.Destination.X == 1 && arg.Destination.Y == 1) {
                //that would be the middle of the board which is not a valid field
                return false;
            }

            if (arg.Destination.Level < 0 || arg.Destination.Level > this.Board.LevelCount - 1) {
                return false;
            }

            if (arg.Destination.X < 0 || arg.Destination.X > this.Board.DimensionCount - 1) {
                return false;
            }

            if (arg.Destination.Y < 0 || arg.Destination.Y > this.Board.DimensionCount - 1) {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Checks if source and destination spots are connected
        /// </summary>
        /// <param name="move"></param>
        /// <returns></returns>
        private bool IsConnected(Move move) {
            Coordinate source = move.Source.Value;
            Coordinate destination = move.Destination;

            int distance = GetDistance(move);
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

        /// <summary>
        /// Checks if the spot is not occupied yet
        /// </summary>
        /// <param name="move"></param>
        /// <returns></returns>
        private bool IsFreeSpot(Move move) {
            Coordinate destination = move.Destination;
            return this.Board.Spots[destination.Level][destination.X, destination.Y] == null;
        }

        /// <summary>
        /// Checks if the source and destination spots are neighbours
        /// </summary>
        /// <param name="move"></param>
        /// <returns></returns>
        private bool IsInRange(Move move) {
            if (!move.Source.HasValue) {
                return true;
            }
            int distance = GetDistance(move);
            return distance == 1;
        }

        private int GetDistance(Move move) {
            Coordinate sourceValue = move.Source.Value;
            Coordinate destinationValue = move.Destination;
            int sumOfSourceCoordinate = sourceValue.Level + sourceValue.X + sourceValue.Y;
            int sumOfDestinationCoordinate = destinationValue.Level + destinationValue.X + destinationValue.Y;
            int distance = Math.Abs(sumOfSourceCoordinate - sumOfDestinationCoordinate);
            return distance;
        }
    }
}