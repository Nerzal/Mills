namespace Mills.ConsoleClient {
    /// <summary>
    /// Board that holds all spots
    /// </summary>
    class Board : IBoard {
        private const int LevelCount = 3;
        private const int Dimensions = 3;

        public Spot[][,] Spots { get; set; }

        /// <inheritdoc />
        public int Player1OffBoardStones { get; private set; }

        /// <inheritdoc />
        public int Player2OffBoardStones { get; private set; }

        /// <summary>
        /// ctor
        /// </summary>
        public Board() {
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
                    }
                }
            }
        }
    }
}