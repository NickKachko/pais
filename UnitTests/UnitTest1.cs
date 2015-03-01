using System;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TSPP;
using System.Windows.Forms;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void TestNetConstructor1()
        {
            Net testNet = new Net(new Point(500,500));
            Assert.AreEqual(testNet.resolution.X, 10);
            Assert.AreEqual(testNet.resolution.Y, 10);
        }

        [TestMethod]
        public void TestNetConstructor2()
        {
            Net testNet = new Net(50);
            Assert.AreEqual(testNet.sizeOfCell, 50);
        }

        [TestMethod]
        public void TestSnakeConstructor()
        {
            Snake testSnake = Snake.GetSingleton();
            Assert.AreNotEqual(null, testSnake);
        }

        [TestMethod]
        public void TestSnakeMove()
        {
            Snake testSnake = Snake.GetSingleton();
            Point netRes = new Point(10, 10);
            Assert.AreEqual(testSnake.position.Count, 1);
            testSnake.Direction = ArrowDirection.Right;
            Assert.AreEqual(testSnake.position[0].X, 0);
            Assert.AreEqual(testSnake.position[0].Y, 0);
            testSnake.Move(netRes);
            Assert.AreEqual(testSnake.position[0].X, 1);
            Assert.AreEqual(testSnake.position[0].Y, 0);
            testSnake.Add();
            testSnake.Direction = ArrowDirection.Up;
            testSnake.Move(netRes);
            Assert.AreEqual(testSnake.position[0].X, 1);
            Assert.AreEqual(testSnake.position[0].Y, 9);
            Assert.AreEqual(testSnake.position[1].X, 1);
            Assert.AreEqual(testSnake.position[1].Y, 0);
        }

        [TestMethod]
        public void TestItems()
        {
            BlueItem blueItem = new BlueItem(new Point(0, 0));
            RedItem redItem = new RedItem(new Point(0, 0));
            Assert.IsNotNull(blueItem);
            Assert.IsNotNull(redItem);
            Assert.AreEqual(blueItem.isHelpful, true);
            Assert.AreEqual(redItem.isHelpful, false);
            Assert.AreEqual(redItem.maxSecond, 10);
        }
    }
}
