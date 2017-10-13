using Mills.ConsoleClient.Player;

namespace Mills.ConsoleClient.Board.Analyzer {
  /// <summary>
  /// Created by the PatternRecognizer to identify mills and possible mills
  /// </summary>
  public class Row {
    /// <summary>
    /// The Player to own this row
    /// </summary>
    public IPlayer Owner { get; }
    /// <summary>
    /// First element of the row
    /// </summary>
    public Coordinate? First { get; set; }
    /// <summary>
    /// Second element of the row
    /// </summary>
    public Coordinate? Second { get; set; }
    /// <summary>
    /// Third element of the row
    /// </summary>
    public Coordinate? Third { get; set; }

    /// <summary>
    /// ctor
    /// </summary>
    /// <param name="owner"></param>
    public Row(IPlayer owner) {
      this.Owner = owner;
    }

    /// <inheritdoc />
    public override string ToString() {
      return
        $"Row occupied by {this.Owner.Color}, Coordinates: First: {this.First} Second: {this.Second} Third: {this.Third}";
    }
  }
}