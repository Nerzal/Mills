using Mills.Game.Data.Contract;

namespace Mills.Game.Player {
    /// <summary>
    /// BaseClass for all players
    /// </summary>
    public abstract class BasePlayer : IPlayer {

        /// <inheritdoc cref="IPlayer.Name"/>
        public string Name { get; }
        /// <inheritdoc cref="IPlayer.Color"/>
        public Colors Color { get; set; }
        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="name">The name of this player</param>
        protected BasePlayer(string name) {
            this.Name = name;
        }
    }
}