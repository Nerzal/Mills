namespace Mills.ConsoleClient {
    public class Player : IPlayer {
        public string Name { get; }
        public Colors Color { get; set; }

        public Player(string name) {
            this.Name = name;
        }
    }
}