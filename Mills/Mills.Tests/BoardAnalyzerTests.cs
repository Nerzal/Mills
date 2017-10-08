using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mills.ConsoleClient.Board;
using Mills.ConsoleClient.Board.Controller;

namespace Mills.Tests {
    [TestClass]
    public class BoardAnalyzerTests {
        [TestMethod]
        public void TestMethod1() {
            IBoard board = new Board();
            IBoardController analyzer = new BoardController(board);
            //board.
        }
    }
}
