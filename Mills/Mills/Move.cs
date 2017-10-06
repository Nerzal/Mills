namespace Mills {
  public class Move {
    public Spot Source { get; set; }
    public Spot Destination { get; set; }
    public IPlayer Player { get; set; }

    public Move(Spot source, Spot target, IPlayer activePlayer) {
      this.Source = source;
      this.Destination = target;
      this.Player = activePlayer;
    }
  }
}