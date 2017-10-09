using System;
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
    private readonly IRowController _controller;

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
        for (int x = 0; x < this.Board.DimensionCount; x++) {
          Row verticalRow = new Row(player);
          for (int y = 0; y < this.Board.DimensionCount; y++) {
            IPlayer occuppier = this.Board.Spots[level][x, y].Player;
            if (occuppier == player) {
              this._controller.AddToRow(verticalRow, new Coordinate(level, x, y));
            }
          }
          if (verticalRow.Second != null) {
            result.Add(verticalRow);
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