using Mills.ConsoleClient.GameController;

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
        public void Move(Move move) {
            if (!move.Source.HasValue) {
                this.Board.Spots[move.Destination.Level][move.Destination.X, move.Destination.Y] = new Spot(move.Player);
                if (move.Player.Color == Colors.White) {
                    this.Board.Player1OffBoardStones--;
                } else {
                    this.Board.Player2OffBoardStones--;
                }
            }
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