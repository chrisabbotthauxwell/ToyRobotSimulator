using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToyRobotSimulator;
using ToyRobotSimulator.State;

namespace ToyRobotSimulator.Test
{
    [TestClass]
    public class RobotTest
    {
        [TestMethod]
        public void Robot_Created_DefaultState()
        {
            Robot robot = new Robot(new RobotStateDefault());
            Assert.IsNotNull(robot);
        }

        [TestMethod]
        public void Robot_Created_NorthFacing()
        {
            Robot robot = new Robot(new RobotStateNorth(Table.Min, Table.Min));
            Assert.IsNotNull(robot);
        }

        [TestMethod]
        public void Robot_Created_EastFacing()
        {
            Robot robot = new Robot(new RobotStateEast(Table.Min, Table.Min));
            Assert.IsNotNull(robot);
        }

        [TestMethod]
        public void Robot_Created_SouthFacing()
        {
            Robot robot = new Robot(new RobotStateSouth(Table.Min, Table.Min));
            Assert.IsNotNull(robot);
        }

        [TestMethod]
        public void Robot_Created_WestFacing()
        {
            Robot robot = new Robot(new RobotStateWest(Table.Min, Table.Min));
            Assert.IsNotNull(robot);
        }

        [TestMethod]
        public void Robot_NotPlaced_CanNotMove()
        {
            Robot robot = new Robot(new RobotStateDefault());
            bool result = robot.Move();
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Robot_NotPlaced_CanNotTurnLeft()
        {
            Robot robot = new Robot(new RobotStateDefault());
            bool result = robot.TurnLeft();
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Robot_NotPlaced_CanNotTurnRight()
        {
            Robot robot = new Robot(new RobotStateDefault());
            bool result = robot.TurnRight();
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Robot_NotPlaced_CanNotReport()
        {
            Robot robot = new Robot(new RobotStateDefault());
            string expected = string.Empty;
            string result = robot.Report();
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Robot_Placed_CanTurnLeft()
        {
            Robot robot = new Robot(new RobotStateNorth(Table.Min, Table.Min));
            bool result = robot.TurnLeft();
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Robot_Placed_CanTurnRight()
        {
            Robot robot = new Robot(new RobotStateNorth(Table.Min, Table.Min));
            bool result = robot.TurnRight();
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Robot_Placed_CanReport()
        {
            Robot robot = new Robot(new RobotStateNorth(Table.Min, Table.Min));
            string expected = "0,0,NORTH";
            string result = robot.Report();
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Robot_Placed_NorthFacing_CanMove()
        {
            Robot robot = new Robot(new RobotStateNorth(Table.Min, Table.Min));
            bool result = robot.Move();
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Robot_Placed_NorthFacing_CanNotMove()
        {
            Robot robot = new Robot(new RobotStateNorth(Table.Min, Table.Max));
            bool result = robot.Move();
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Robot_Placed_EastFacing_CanMove()
        {
            Robot robot = new Robot(new RobotStateEast(Table.Min, Table.Max));
            bool result = robot.Move();
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Robot_Placed_EastFacing_CanNotMove()
        {
            Robot robot = new Robot(new RobotStateEast(Table.Max, Table.Min));
            bool result = robot.Move();
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Robot_Placed_SouthFacing_CanMove()
        {
            Robot robot = new Robot(new RobotStateSouth(Table.Min, Table.Max));
            bool result = robot.Move();
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Robot_Placed_SouthFacing_CanNotMove()
        {
            Robot robot = new Robot(new RobotStateSouth(Table.Min, Table.Min));
            bool result = robot.Move();
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Robot_Placed_WestFacing_CanMove()
        {
            Robot robot = new Robot(new RobotStateWest(Table.Max, Table.Min));
            bool result = robot.Move();
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Robot_Placed_WestFacing_CanNotMove()
        {
            Robot robot = new Robot(new RobotStateWest(Table.Min, Table.Min));
            bool result = robot.Move();
            Assert.IsFalse(result);
        }
    }
}
