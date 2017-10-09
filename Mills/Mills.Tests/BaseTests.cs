using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mills.ConsoleClient.Board;
using Mills.ConsoleClient.Board.Analyzer;
using Mills.ConsoleClient.Board.Controller;
using Mills.ConsoleClient.Player;

namespace Mills.Tests {
    [TestClass]
    public abstract class BaseTests {
        protected IBoard Board;
        protected IBoardAnalyzer Analyzer;
        protected IBoardController Controller;
        protected Player Player;
        protected Player Player2;

        [TestInitialize]
        public void InitializeTests() {
            this.Board = new Board();
            this.Analyzer = new BoardAnalyzer(this.Board);
            this.Controller = new BoardController(this.Board, this.Analyzer);
            this.Controller.Initialize();
            this.Player = new Player("Nerzal") { Color = Colors.White };
            this.Player2 = new Player("Wr4th0n") { Color = Colors.Black };
        }
    }
}