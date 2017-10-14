namespace Mills.Game.Data.Contract {
    /// <summary>
    /// Base Interface for a player
    /// </summary>
    public interface IPlayer {
        /// <summary>
        /// Name of the player
        /// </summary>
        string Name { get; }
        /// <summary>
        /// Color of the Player
        /// Can be Black or White
        /// </summary>
        Colors Color { get; set; }
    }
}