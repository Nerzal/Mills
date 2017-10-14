using System;
using System.Collections.Generic;
using System.Linq;

namespace Mills.Game.Data.Contract
{
  /// <summary>
  /// Created by the PatternRecognizer to identify mills and possible mills
  /// </summary>
  public class Row
  {
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
    public Row(IPlayer owner)
    {
      this.Owner = owner;
    }

    public Row(IPlayer player, IList<Coordinate> spots) : this(player)
    {
      if (spots.Count > 3)
      {
        throw new ArgumentException("inalid spots count", nameof(spots));
      }
      if (spots.Count > 0)
      {
        this.First = spots[0];
      }

      if (spots.Count > 1)
      {
        this.Second = spots[1];
      }

      if (spots.Count > 2)
      {
        this.Third = spots[2];
      }
    }

    /// <inheritdoc />
    public override string ToString()
    {
      return
        $"Row occupied by {this.Owner.Color}, Coordinates: First: {this.First} Second: {this.Second} Third: {this.Third}";
    }
  }
}