using Mills.ConsoleClient.Board;

namespace Mills.ConsoleClient.Player {
    public interface IPlayer {
        string Name { get; }
        Colors Color { get; set; }
    }
}