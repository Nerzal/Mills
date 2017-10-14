using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mills.Board.Logic;
using Mills.Board.Logic.Contract;
using Mills.Game.Data.Contract;
using Mills.Game.Player;

namespace Mills.Tests {
    [TestClass]
    public abstract class BaseTests {
        protected IBoard Board;
        protected IBoardAnalyzer Analyzer;
        protected IBoardController Controller;
        protected IPatternRecognizer Recognizer;
        protected IRowController RowController;
        protected IPlayer Player;
        protected IPlayer Player2;

        [TestInitialize]
        public void InitializeTests() {
            this.Board = new Game.Data.Contract.Board();
            this.Analyzer = new BoardAnalyzer(this.Board);
            this.RowController = new RowController();
            this.Recognizer = new PatternRecognizer(this.Board, this.RowController);
            this.Controller = new BoardController(this.Board, this.Analyzer, this.Recognizer);
            this.Controller.Initialize();
            this.Player = new Player("Nerzal") { Color = Colors.White };
            this.Player2 = new Player("Wr4th0n") { Color = Colors.Black };
        }
    }
}