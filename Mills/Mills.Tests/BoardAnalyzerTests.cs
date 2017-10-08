using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mills.ConsoleClient.Board;
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
        public void GetOccupier_Player_000() {
            //Arrange
            this.Controller.Set(new Coordinate(0, 0, 0), this.Player);
            //Act
            IPlayer player = this.Analyzer.GetOccupier(new Coordinate(0, 0, 0));
            //Assert
            Assert.AreEqual(player, this.Player);
        }

        [TestMethod]
        public void GetOccupier_Null_000() {
            //Arrange
            //Arranging is done by TestInitialize-Method from baseclass
            //Act
            IPlayer player = this.Analyzer.GetOccupier(new Coordinate(0, 0, 0));
            //Assert
            Assert.IsNull(player);
        }

        [TestMethod]
        public void GetDistance_0_000To000() {
            //Arrange
            Coordinate source = new Coordinate(0, 0, 0);
            Coordinate destination = new Coordinate(0, 0, 0);
            //Act
            int result = this.Analyzer.GetDistance(source, destination);
            //Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void GetDistance_1_000To010() {
            //Arrange
            Coordinate source = new Coordinate(0, 0, 0);
            Coordinate destination = new Coordinate(0, 1, 0);
            //Act
            int result = this.Analyzer.GetDistance(source, destination);
            //Assert
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void GetDistance_2_000To002() {
            //Arrange
            Coordinate source = new Coordinate(0, 0, 0);
            Coordinate destination = new Coordinate(0, 0, 2);
            //Act
            int result = this.Analyzer.GetDistance(source, destination);
            //Assert
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void IsFreeSpot_True_000() {
            //Arrange
            Coordinate coordinate = new Coordinate(0, 0, 0);
            //Act
            bool result = this.Analyzer.IsFreeSpot(coordinate);
            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsFreeSpot_False_000() {
            //Arrange
            Coordinate coordinate = new Coordinate(0, 0, 0);
            this.Controller.Set(coordinate, this.Player);
            //Act
            bool result = this.Analyzer.IsFreeSpot(coordinate);
            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CheckCoordinatesAreConnected_True_000To010() {
            //Arrange
            Coordinate firstSpot = new Coordinate(0, 0, 0);
            Coordinate secondSpot = new Coordinate(0, 1, 0);
            //Act
            bool result = this.Analyzer.CheckCoordinatesAreConnected(firstSpot, secondSpot);
            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CheckCoordinatesAreConnected_False_000To020() {
            //Arrange
            Coordinate firstSpot = new Coordinate(0, 0, 0);
            Coordinate secondSpot = new Coordinate(0, 2, 0);
            //Act
            bool result = this.Analyzer.CheckCoordinatesAreConnected(firstSpot, secondSpot);
            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CheckCoordinatesAreConnected_True_001To101() {
            //Arrange
            Coordinate firstSpot = new Coordinate(0, 0, 1);
            Coordinate secondSpot = new Coordinate(1, 0, 1);
            //Act
            bool result = this.Analyzer.CheckCoordinatesAreConnected(firstSpot, secondSpot);
            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CheckCoordinatesAreConnected_True_002To012() {
            //Arrange
            Coordinate firstSpot = new Coordinate(0, 0, 2);
            Coordinate secondSpot = new Coordinate(0, 1, 2);
            //Act
            bool result = this.Analyzer.CheckCoordinatesAreConnected(firstSpot, secondSpot);
            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CheckCoordinatesAreConnected_True_221To121() {
            //Arrange
            Coordinate firstSpot = new Coordinate(2, 2, 1);
            Coordinate secondSpot = new Coordinate(1, 2, 1);
            //Act
            bool result = this.Analyzer.CheckCoordinatesAreConnected(firstSpot, secondSpot);
            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CheckCoordinatesAreConnected_False_022To122() {
            //Arrange
            Coordinate firstSpot = new Coordinate(0, 2, 2);
            Coordinate secondSpot = new Coordinate(1, 2, 2);
            //Act
            bool result = this.Analyzer.CheckCoordinatesAreConnected(firstSpot, secondSpot);
            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CheckCoordinatesAreConnected_False_002To122() {
            //Arrange
            Coordinate firstSpot = new Coordinate(0, 0, 2);
            Coordinate secondSpot = new Coordinate(1, 2, 2);
            //Act
            bool result = this.Analyzer.CheckCoordinatesAreConnected(firstSpot, secondSpot);
            //Assert
            Assert.IsFalse(result);
        }
    }
}
