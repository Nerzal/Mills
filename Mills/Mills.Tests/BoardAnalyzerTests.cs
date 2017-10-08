using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mills.ConsoleClient.Board;
using Mills.ConsoleClient.GameController;

namespace Mills.Tests {
    [TestClass]
    public class BoardAnalyzerTests : BaseAnalyzerControllerTests {

        [TestMethod]
        public void CountPlayerSpots_3Spots_White() {
            //Arrange
            this.Controller.Move(new Move(null, new Coordinate(0, 0, 0), this.Player));
            this.Controller.Move(new Move(null, new Coordinate(0, 1, 0), this.Player));
            this.Controller.Move(new Move(null, new Coordinate(0, 0, 1), this.Player));
            //Act
            int whiteCount = this.Analyzer.CountPlayerSpots(Colors.White);
            //Assert
            Assert.AreEqual(3, whiteCount);
        }
    }
}
