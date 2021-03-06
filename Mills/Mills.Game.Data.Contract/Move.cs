﻿namespace Mills.Game.Data.Contract {
    /// <summary>
    /// Represents a single player move
    /// A Move can be setting a new stone, ore moving one
    /// </summary>
    public class Move {
        /// <summary>
        /// The source of the movement
        /// </summary>
        public Coordinate Source { get; set; }
        /// <summary>
        /// The destination of the movement
        /// </summary>
        public Coordinate Destination { get; set; }

        /// <summary>
        /// The player, who executed this movement
        /// </summary>
        public IPlayer Player { get; set; }

      /// <summary>
      /// ctor
      /// </summary>
      /// <param name="source"></param>
      /// <param name="target"></param>
      /// <param name="activePlayer"></param>
      public Move(Coordinate source, Coordinate target, IPlayer activePlayer):this(source, target)
      {
        this.Player = activePlayer;
    }

      /// <summary>
      /// ctor
      /// </summary>
      /// <param name="source"></param>
      /// <param name="target"></param>
      public Move(Coordinate source, Coordinate target)
      {
        this.Source = source;
        this.Destination = target;
      }
  }
}