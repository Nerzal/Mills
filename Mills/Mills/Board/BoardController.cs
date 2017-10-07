using System.Linq;

namespace Mills.ConsoleClient.Board {
    public class BoardController : IBoardController {

        /// <inheritdoc />
        public IBoard Board { get; }

        /// <inheritdoc />
        public int Player1OffBoardStones { get; private set; }

        /// <inheritdoc />
        public int Player2OffBoardStones { get; private set; }

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
                    this.Player1OffBoardStones--;
                } else {
                    this.Player2OffBoardStones--;
                }
            }
        }


        /// <inheritdoc />
        public void Initialize() {
            this.Player1OffBoardStones = 8;
            this.Player2OffBoardStones = 8;
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
  
        /// <inheritdoc />
        public int CountPlayerSpots(Colors color) {
            return this.Board.Spots.SelectMany(level => level.Cast<Spot>())
                .Count(spot => spot?.Player.Color == color);
        }
    }
}