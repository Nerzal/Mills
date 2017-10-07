using Mills.ConsoleClient.Player;

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
        /// the player who holds a spot, can be null
        /// </summary>
        public IPlayer Owner { get; private set; }

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="level"><see cref="Level"/></param>
        /// <param name="x"><see cref="X"/></param>
        /// <param name="y"><see cref="Y"/></param>
        /// <param name="owner"><see cref="Owner"/></param>
        public Coordinate(int level, int x, int y, IPlayer owner) {
            this.Level = level;
            this.X = x;
            this.Y = y;
            this.Owner = owner;
        }
    }
}