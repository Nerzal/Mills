namespace Mills.ConsoleClient {
  public class Spot {
    
    public IPlayer Player { get; set; }

    public Spot(IPlayer player) {
      this.Player = player;
    }

    /// <summary>
    /// TODO kill me
    /// </summary>
    /// <returns></returns>
    public override string ToString() {
      string result;
      switch (this.Player?.Color) {
        case Colors.Black: {
            result = "B";
            break;
          }
        case Colors.White: {
            result = "W";
            break;
          }
        default: {
            result = " ";
            break;
          }
      }
      return result;
    }
  }
}