namespace Mills {
  public class Move {
    public Spot Source { get; set; }
    public Spot Destination { get; set; }
    public IPlayer Player { get; set; }
  }
}