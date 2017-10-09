using System.Collections.Generic;
using System.Linq;
using Mills.ConsoleClient.Player;

namespace Mills.ConsoleClient.Board.Analyzer {
  /// <inheritdoc />
  /// <summary>
  /// Implementation of <see cref="T:Mills.ConsoleClient.Board.Analyzer.IPatternRecognizer" />
  /// Finds all rows and mills
  /// </summary>
  public class PatternRecognizer : IPatternRecognizer {
    private IRowController _controller;

    /// <inheritdoc />
    public IBoard Board { get; }

    /// <summary>
    /// ctor
    /// </summary>
    /// <param name="board"></param>
    /// <param name="controller"></param>
    public PatternRecognizer(IBoard board, IRowController controller) {
      this.Board = board;
      this._controller = controller;
    }

    /// <inheritdoc />
    public IEnumerable<Row> FindAllRowsFor(IPlayer player) {
      ICollection<Row> result = new List<Row>();
      for (int level = 0; level < this.Board.LevelCount; level++) {
        Row row = new Row();
        for (int x = 0; x < this.Board.DimensionCount; x++) {
          IPlayer occuppier = this.Board.Spots[level][x, 0].Player;
          if (occuppier == player) {

          }
        }
      }
      return result;
    }

    /// <inheritdoc />
    public IEnumerable<Row> FindAllMillsFor(IPlayer player) {
      return this.FindAllRowsFor(player).Where(row => this._controller.IsMill(row));
    }
  }
}