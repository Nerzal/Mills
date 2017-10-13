using Mills.Board.Logic.Contract;
using Mills.Game.Data.Contract;

namespace Mills.Board.Logic {
    /// <summary>
    /// Controls and analyzes the board..oh gosh i have to split that
    /// </summary>
    public class BoardController : IBoardController {
        private readonly IBoardAnalyzer _analyzer;

        /// <inheritdoc />
        public IBoard Board { get; }

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="board"></param>
        /// <param name="analyzer"></param>
        public BoardController(IBoard board, IBoardAnalyzer analyzer) {
            this.Board = board;
            this._analyzer = analyzer;
        }

        /// <inheritdoc />
        public bool Set(Coordinate coordinate, IPlayer player) {
            if (!this._analyzer.IsValidCoordinate(coordinate) || !this._analyzer.IsFreeSpot(coordinate)) {
                return false;
            }

            this.Board.Spots[coordinate.Level][coordinate.X, coordinate.Y] = new Spot(player);
            if (player.Color == Colors.White) {
                this.Board.Player1OffBoardStones--;
            } else {
                this.Board.Player2OffBoardStones--;
            }
            return true;
        }

        /// <inheritdoc />
        public bool Unset(Coordinate coordinate, IPlayer activePlayer) {
            if (this._analyzer.IsFreeSpot(coordinate)) {
                return false;
            }

            IPlayer occupier = this._analyzer.GetOccupier(coordinate);
            if (occupier != activePlayer) {
                this.Board.Spots[coordinate.Level][coordinate.X, coordinate.Y].Player = null;
                return true;
            }

            return false;
        }

        /// <inheritdoc />
        public bool Move(Move move) {
            if (!CheckDestinationIsValidAndFree(move.Destination)) {
                return false;
            }

            if (!this._analyzer.CheckCoordinatesAreConnected(move.Source, move.Destination)) {
                return false;
            }

            if (this._analyzer.GetDistance(move.Source, move.Destination) != 1) {
                return false;
            }
            ApplyMove(move);
            return true;
        }

        private bool CheckDestinationIsValidAndFree(Coordinate destination) {
            if (!this._analyzer.IsValidCoordinate(destination)) {
                return false;
            }
            if (!this._analyzer.IsFreeSpot(destination)) {
                return false;
            }
            return true;
        }

        /// <inheritdoc />
        public bool Jump(Move move) {
            if (!CheckDestinationIsValidAndFree(move.Destination)) {
                return false;
            }

            ApplyMove(move);
            return true;
        }

        /// <inheritdoc />
        public void Initialize() {
            this.Board.Player1OffBoardStones = 8;
            this.Board.Player2OffBoardStones = 8;
            int dimension = this.Board.DimensionCount;
            for (int levelIndex = 0; levelIndex < this.Board.LevelCount; levelIndex++) {
                Spot[,] level = this.Board.Spots[levelIndex] = new Spot[dimension, dimension];
                for (int xIndex = 0; xIndex < dimension; xIndex++) {
                    for (int yIndex = 0; yIndex < dimension; yIndex++) {
                        level[xIndex, yIndex] = new Spot(null);
                    }
                }
            }
        }

        /// <summary>
        /// Unset source and set destination
        /// </summary>
        /// <param name="move"></param>
        private void ApplyMove(Move move) {
            Coordinate source = move.Source;
            Coordinate destination = move.Destination;
            this.Board.Spots[source.Level][source.X, source.Y].Player = null;
            this.Board.Spots[destination.Level][destination.X, destination.Y].Player = move.Player;
        }
    }
}