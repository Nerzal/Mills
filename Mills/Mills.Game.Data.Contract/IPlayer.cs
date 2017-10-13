namespace Mills.Game.Data.Contract {
    public interface IPlayer {
        string Name { get; }
        Colors Color { get; set; }
    }
}