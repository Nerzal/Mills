namespace Mills.ConsoleClient.Board {
    /// <summary>
    /// BoardAnalyzer that holds all spots
    /// </summary>
    internal class Board : IBoard {
        private const int Levels = 3;
        private const int Dimensions = 3;

        /// <inheritdoc />
        public int LevelCount => Levels;

        /// <inheritdoc />
        public int DimensionCount => Dimensions;
        
        /// <inheritdoc />
        public int Player1OffBoardStones { get; set; }

        /// <inheritdoc />
        public int Player2OffBoardStones { get; set; }

        /// <inheritdoc />
        public Spot[][,] Spots { get; set; }
        
        /// <summary>
        /// ctor
        /// </summary>
        public Board() {
            this.Spots = new Spot[this.LevelCount][,];
        }
    }
}