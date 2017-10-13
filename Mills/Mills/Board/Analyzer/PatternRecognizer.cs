﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
      List<Row> result = new List<Row>();
      for (int level = 0; level < this.Board.LevelCount; level++) {
        for (int x = 0; x < this.Board.DimensionCount; x++) {
          ICollection<Row> rows = FindVerticalRows(player, level, x);
          result.AddRange(rows);
        }
        for (int y = 0; y < this.Board.DimensionCount; y++) {
          ICollection<Row> rows = FindHorizontalRows(player, level, y);
          result.AddRange(rows);
        }
      }

      for (int y = 0; y < this.Board.DimensionCount; y++) {
        Row row = new Row(player);
        for (int level = 0; level < this.Board.LevelCount; level++) {
          IPlayer occuppier = this.Board.Spots[level][0, y].Player;
          if (occuppier == player) {
            this._controller.AddToRow(row, new Coordinate(level, 0, y));
          }
        }
        if (row.Second.HasValue) {
          result.Add(row);
        }
      }

      for (int x = 0; x < this.Board.DimensionCount; x++) {
        Row row = new Row(player);
        for (int level = 0; level < this.Board.LevelCount; level++) {
          IPlayer occuppier = this.Board.Spots[level][x, 0].Player;
          if (occuppier == player) {
            this._controller.AddToRow(row, new Coordinate(level, x, 0));
          }
        }
        if (row.Second.HasValue) {
          result.Add(row);
        }
      }

      Row foo = new Row(player);
      for (int level = 0; level < this.Board.LevelCount; level++) {
        IPlayer occuppier = this.Board.Spots[level][2, 1].Player;
        if (occuppier == player) {
          this._controller.AddToRow(foo, new Coordinate(level, 2, 1));
        }
      }
      if (foo.Second.HasValue) {
        result.Add(foo);
      }

      return result;
    }

    private ICollection<Row> FindHorizontalRows(IPlayer player, int level, int y) {
      ICollection<Row> result = new List<Row>();
      Row verticalRow = new Row(player);
      for (int x = 0; x < this.Board.DimensionCount; x++) {
        IPlayer occuppier = this.Board.Spots[level][x, y].Player;
        if (occuppier == player) {
          this._controller.AddToRow(verticalRow, new Coordinate(level, x, y));
        }
      }
      if (verticalRow.Second != null) {
        result.Add(verticalRow);
      }
      return result;
    }

    private ICollection<Row> FindVerticalRows(IPlayer player, int level, int x) {
      ICollection<Row> result = new List<Row>();
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
      return result;
    }

    /// <inheritdoc />
    public IEnumerable<Row> FindAllMillsFor(IPlayer player) {
      return this.FindAllRowsFor(player).Where(row => this._controller.IsMill(row));
    }
  }
}