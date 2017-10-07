using System.Collections.Generic;

namespace Mills.ConsoleClient {
    /// <summary>
    /// Board that holds all spots
    /// </summary>
    class Board : IBoard {
        private readonly ICollection<Coordinate> _validCoordinates;
        private const int Levels = 3;
        private const int Dimensions = 3;

        /// <inheritdoc />
        public int LevelCount => Levels;

        /// <inheritdoc />
        public int DimensionCount => Dimensions;

        public Spot[][,] Spots { get; set; }

        /// <inheritdoc />
        public int Player1OffBoardStones { get; private set; }

        /// <inheritdoc />
        public int Player2OffBoardStones { get; private set; }
        
        /// <inheritdoc />
        public IEnumerable<Coordinate> ValidCoordinates => this._validCoordinates;

        /// <summary>
        /// ctor
        /// </summary>
        public Board() {
            this._validCoordinates = new List<Coordinate>();
            this.Spots = new Spot[LevelCount][,];
        }

        /// <inheritdoc />
        public void Move(Move move) {
            if (!move.Source.HasValue) {
                this.Spots[move.Destination.Level][move.Destination.X, move.Destination.Y] = new Spot(move.Player);
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

            for (int levelIndex = 0; levelIndex < LevelCount; levelIndex++) {
                Spot[,] level = this.Spots[levelIndex] = new Spot[Dimensions, Dimensions];
                for (int xIndex = 0; xIndex < Dimensions; xIndex++) {
                    for (int yIndex = 0; yIndex < Dimensions; yIndex++) {
                        level[xIndex, yIndex] = new Spot(null);
                        this._validCoordinates.Add(new Coordinate(levelIndex, xIndex, yIndex, null));
                    }
                }
            }
        }
    }
}