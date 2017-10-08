using System;
using Mills.ConsoleClient.Board.Analyzer;
using Mills.ConsoleClient.GameController;
using Mills.ConsoleClient.Player;

namespace Mills.ConsoleClient.Board.Controller {
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
        public bool Move(Move move) {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public bool Jump(Move move) {
            throw new System.NotImplementedException();
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

    }
}