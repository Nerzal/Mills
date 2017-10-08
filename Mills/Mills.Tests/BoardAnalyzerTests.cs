using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mills.ConsoleClient.Board;
using Mills.ConsoleClient.GameController;
using Mills.ConsoleClient.Player;

namespace Mills.Tests {
    [TestClass]
    public class BoardAnalyzerTests : BaseAnalyzerControllerTests {

        [TestMethod]
        public void Set_True_FreeSpot() {
            //Arrange
            //Arranging is done by TestInitialize-Method from baseclass
            //Act
            bool wasSet = this.Controller.Set(new Coordinate(0, 0, 0), this.Player);
            //Assert
            Assert.IsTrue(wasSet);
        }

        [TestMethod]
        public void Set_False_OccupiedSpot() {
            //Arrange
            //Arranging is done by TestInitialize-Method from baseclass
            //Act
            this.Controller.Set(new Coordinate(0, 0, 0), this.Player);
            bool wasSet = this.Controller.Set(new Coordinate(0, 0, 0), this.Player2);
            //Assert
            Assert.IsFalse(wasSet);
        }

        [TestMethod]
        public void Set_False_InvalidCoordinate() {
            //Arrange
            //Arranging is done by TestInitialize-Method from baseclass
            //Act
            bool wasSet = this.Controller.Set(new Coordinate(-1, 0, 0), this.Player2);
            //Assert
            Assert.IsFalse(wasSet);
        }

        [TestMethod]
        public void CountPlayerSpots_3Spots_White() {
            //Arrange
            this.Controller.Set(new Coordinate(0, 0, 0), this.Player);
            this.Controller.Set(new Coordinate(0, 1, 0), this.Player);
            this.Controller.Set(new Coordinate(0, 0, 1), this.Player);
            //Act
            int whiteCount = this.Analyzer.CountPlayerSpots(Colors.White);
            //Assert
            Assert.AreEqual(3, whiteCount);
        }

        [TestMethod]
        public void GetOccupier_000_Player() {
            //Arrange
            this.Controller.Set(new Coordinate(0, 0, 0), this.Player);
            //Act
            IPlayer player = this.Analyzer.GetOccupier(new Coordinate(0, 0, 0));
            //Assert
            Assert.AreEqual(player, this.Player);
        }
    }
}
