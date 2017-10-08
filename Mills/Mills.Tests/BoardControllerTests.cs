using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mills.ConsoleClient.Board;
using Mills.ConsoleClient.GameController;

namespace Mills.Tests {
    [TestClass]
    public class BoardControllerTests : BaseAnalyzerControllerTests {

        [TestMethod]
        public void Move_SetNew_PlayerWhite() {
            //Arrange
            //This part is done by the TestInitialize in the BaseClass
            //Act
            bool result = this.Controller.Set(new Coordinate(0, 0, 0), this.Player);
            //Assert
            Spot spot = this.Board.Spots[0][0, 0];
            Assert.IsNotNull(spot.Player);
            Assert.AreEqual(spot.Player, this.Player);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Move_SetNew_PlayerBlack() {
            //Arrange
            //This part is done by the TestInitialize in the BaseClass
            //Act
            bool result = this.Controller.Set(new Coordinate(0, 0, 0), this.Player2);
            //Assert
            Spot spot = this.Board.Spots[0][0, 0];
            Assert.IsNotNull(spot.Player);
            Assert.AreEqual(spot.Player, this.Player2);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Move_IsFalse_InvalidCoordinate() {
            //Arrange
            //This part is done by the TestInitialize in the BaseClass
            //Act
            bool result = this.Controller.Set(new Coordinate(3, 3, 3), this.Player2);
            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Move_IsFalse_InvalidCoordinateMiddleOfField() {
            //Arrange
            //This part is done by the TestInitialize in the BaseClass
            //Act
            bool result = this.Controller.Set(new Coordinate(2, 1, 1), this.Player2);
            //Assert
            Assert.IsFalse(result);
        }
    }
}