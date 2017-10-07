namespace Mills.ConsoleClient {
  public class Move {
    public Coordinate? Source { get; set; }
    public Coordinate Destination { get; set; }
    public IPlayer Player { get; set; }

    public Move(Coordinate? source, Coordinate target, IPlayer activePlayer) {
      this.Source = source;
      this.Destination = target;
      this.Player = activePlayer;
    }
  }
}