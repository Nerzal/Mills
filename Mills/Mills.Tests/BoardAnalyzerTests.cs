using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mills.ConsoleClient.Board;
using Mills.ConsoleClient.Board.Analyzer;
using Mills.ConsoleClient.Board.Controller;
using Mills.ConsoleClient.GameController;
using Mills.ConsoleClient.Player;

namespace Mills.Tests {
    [TestClass]
    public class BoardAnalyzerTests {
        private Board _board;
        private BoardAnalyzer _analyzer;
        private BoardController _controller;
        private Player _player;
        private Player _player2;

        [TestInitialize]
        public void InitializeTests() {
            this._board = new Board();
            this._analyzer = new BoardAnalyzer(this._board);
            this._controller = new BoardController(this._board);
            this._controller.Initialize();
            this._player = new Player("Nerzal");
            this._player.Color = Colors.White;
            this._player2 = new Player("Wr4th0n");
            this._player2.Color = Colors.Black;
        }

        [TestMethod]
        public void CountPlayerSpots_3Spots_White() {
            //Arrange
            this._controller.Move(new Move(null, new Coordinate(0, 0, 0), this._player));
            this._controller.Move(new Move(null, new Coordinate(0, 1, 0), this._player));
            this._controller.Move(new Move(null, new Coordinate(0, 0, 1), this._player));
            //Act
            int whiteCount = this._analyzer.CountPlayerSpots(Colors.White);
            //Assert
            Assert.AreEqual(3, whiteCount);
        }
    }
}
