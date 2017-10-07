namespace Mills.ConsoleClient {
  public struct Coordinate {
    
    public int Level { get; set; }

    public int X { get; set; }

    public int Y { get; set; }

    public IPlayer ActivePlayer { get; private set; }

    public Coordinate(int level, int x, int y, IPlayer activePlayer) {
      this.Level = level;
      this.X = x;
      this.Y = y;
      this.ActivePlayer = activePlayer;
    }
   }
}