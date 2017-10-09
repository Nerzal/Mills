using System;
using Mills.ConsoleClient.Player;

namespace Mills.ConsoleClient.Board.Analyzer {
  /// <summary>
  /// Created by the PatternRecognizer to identify mills and possible mills
  /// </summary>
  public class Row {
    /// <summary>
    /// The Player to own this row
    /// </summary>
    public IPlayer Player { get; set; }
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

    /// <inheritdoc />
    public override string ToString() {
      return
        $"Row occupied by {this.Player.Color}, Coordinates: First: {this.First} Second: {this.Second} Third: {this.Third}";
    }
  }

  /// <summary>
  /// Controller for <see cref="Row"/>s
  /// </summary>
  public interface IRowController {
    /// <summary>
    /// Adds a coordinate into a row
    /// </summary>
    /// <param name="row">the row the coordinate will be added too</param>
    /// <param name="coordinate">the coordinate to add</param>
    void AddToRow(Row row, Coordinate coordinate);
    /// <summary>
    /// Checks if a row is a mill
    /// </summary>
    /// <param name="row">the row to check</param>
    /// <returns>true if there are 3 coordinates in a row</returns>
    bool IsMill(Row row);
  }

  /// <inheritdoc />
  /// <summary>
  /// Implementation of <see cref="IRowController"/>
  /// </summary>
  public class RowController : IRowController {
    /// <inheritdoc />
    public void AddToRow(Row row, Coordinate coordinate) {
      if (row == null) {
        throw new ArgumentNullException($"{nameof(row)} was null");
      }

      if (row.First == null) {
        row.First = coordinate;
      } else if (row.Second == null) {
        row.Second = coordinate;
      } else if (row.Third == null) {
        row.Third = coordinate;
      } else {
        throw new RowAllreadyFullException(row, coordinate);
      }
    }

    /// <inheritdoc />
    public bool IsMill(Row row) {
      if (row == null) {
        throw new ArgumentNullException($"{nameof(row)} was null");
      }

      return row.First != null && row.Second != null && row.Third != null;
    }
  }

  /// <inheritdoc />
  /// <summary>
  /// Used when AddToRow is called on a full row(mill)
  /// </summary>
  public class RowAllreadyFullException : Exception {
    /// <inheritdoc />
    /// <summary>
    /// ctor
    /// </summary>
    /// <param name="row"></param>
    /// <param name="coordinate"></param>
    public RowAllreadyFullException(Row row, Coordinate coordinate) : base($"The row ") {
    }
  }
}