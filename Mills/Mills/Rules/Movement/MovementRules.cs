using System;
using Mills.ConsoleClient.Board;
using Mills.ConsoleClient.Board.Analyzer;
using Mills.ConsoleClient.GameController;

namespace Mills.ConsoleClient.Rules.Movement {
    /// <summary>
    /// Extends <see cref="BaseRules{TEvaluationObject}"/>
    /// Implements <seealso cref="IMovementRules"/>
    /// 
    /// Holds all rules that are important for movement
    /// </summary>
    public class MovementRules : BaseRules<Move>, IMovementRules {
        private readonly IBoard _board;

        /// <inheritdoc />
        public IBoardAnalyzer BoardAnalyzer { get; }

        /// <inheritdoc />
        public MovementRules(IBoardAnalyzer boardAnalyzer, IBoard board) {
            this.BoardAnalyzer = boardAnalyzer;
            this._board = board;
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
                //that would be the middle of the boardAnalyzer which is not a valid field
                return false;
            }

            if (arg.Destination.Level < 0 || arg.Destination.Level > this._board.LevelCount - 1) {
                return false;
            }

            if (arg.Destination.X < 0 || arg.Destination.X > this._board.DimensionCount - 1) {
                return false;
            }

            if (arg.Destination.Y < 0 || arg.Destination.Y > this._board.DimensionCount - 1) {
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
            if (!move.Source.HasValue) {
                return true; //TODO fix me i don't want to be executed in phase 1
            }
            Coordinate source = move.Source.Value;
            Coordinate destination = move.Destination;
            return CheckCoordinatesAreConnected(source, destination);
        }

        private bool CheckCoordinatesAreConnected(Coordinate source, Coordinate destination) {
            int distance = this.BoardAnalyzer.GetDistance(source, destination);
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
        /// Checks if the source and destination spots are neighbours
        /// </summary>
        /// <param name="move"></param>
        /// <returns></returns>
        private bool IsInRange(Move move) {
            if (!move.Source.HasValue) {
                return true;
            }
            int distance = this.BoardAnalyzer.GetDistance(move.Source.Value, move.Destination);
            return distance == 1;
        }
        private bool IsFreeSpot(Move arg) {
            return this.BoardAnalyzer.IsFreeSpot(arg.Destination);
        }
    }
}