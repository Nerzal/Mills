namespace Mills.ConsoleClient.Board {
    /// <summary>
    /// A single coordinate on the board
    /// </summary>
    public struct Coordinate {
        /// <summary>
        /// There are 3 levels on the board
        /// </summary>

        public int Level { get; set; }

        /// <summary>
        /// x coordinate
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// y coordinate
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="level"><see cref="Level"/></param>
        /// <param name="x"><see cref="X"/></param>
        /// <param name="y"><see cref="Y"/></param>
        public Coordinate(int level, int x, int y) {
            this.Level = level;
            this.X = x;
            this.Y = y;
        }

        /// <inheritdoc />
        public override string ToString() {
            return $"Level: {this.Level} X: {this.X}, Y: {this.Y}";
        }
    }
}