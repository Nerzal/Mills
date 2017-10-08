using System;
using Mills.ConsoleClient.GameController;
using Mills.ConsoleClient.Player;

namespace Mills.ConsoleClient.Board.Controller {
    /// <summary>
    /// Controls and analyzes the board..oh gosh i have to split that
    /// </summary>
    public class BoardController : IBoardController {

        /// <inheritdoc />
        public IBoard Board { get; }

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="board"></param>
        public BoardController(IBoard board) {
            this.Board = board;
        }

        /// <inheritdoc />
        public void Set(Coordinate coordinate, IPlayer player) {
            this.Board.Spots[coordinate.Level][coordinate.X, coordinate.Y] = new Spot(player);
            if (player.Color == Colors.White) {
                this.Board.Player1OffBoardStones--;
            } else {
                this.Board.Player2OffBoardStones--;
            }
        }

        /// <inheritdoc />
        public void Move(Move move) {
            throw new NotImplementedException();
        }
        
        /// <inheritdoc />
        public void Jump(Move move) {
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