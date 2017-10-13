using Mills.Game.Data.Contract;

namespace Mills.Game.Player {
    public abstract class BasePlayer : IPlayer {
        public string Name { get; }
        public Colors Color { get; set; }

        protected BasePlayer(string name) {
            this.Name = name;
        }
    }
}