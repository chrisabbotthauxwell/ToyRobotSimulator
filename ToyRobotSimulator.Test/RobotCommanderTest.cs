using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToyRobotSimulator;
using ToyRobotSimulator.State;

namespace ToyRobotSimulator.Test
{
    [TestClass]
    public class RobotCommanderTest
    {
        [TestMethod]
        public void RobotCommander_Created()
        {
            RobotCommander robotCommander = new RobotCommander(new Robot(new RobotStateDefault()));
            Assert.IsNotNull(robotCommander);
        }

        [TestMethod]
        public void RobotCommander_SendCommand_Report_LowerCase()
        {
            RobotCommander robotCommander = new RobotCommander(new Robot(new RobotStateNorth(Table.Min, Table.Min)));
            string expected = "0,0,NORTH";
            string result = robotCommander.SendCommand("report");
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void RobotCommander_SendCommand_Report_UpperCase()
        {
            RobotCommander robotCommander = new RobotCommander(new Robot(new RobotStateNorth(Table.Min, Table.Min)));
            string expected = "0,0,NORTH";
            string result = robotCommander.SendCommand("REPORT");
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void RobotCommander_SendCommand_Report_NotOnTable()
        {
            RobotCommander robotCommander = new RobotCommander(new Robot(new RobotStateDefault()));
            string expected = string.Empty;
            string result = robotCommander.SendCommand("report");
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void RobotCommander_SendCommand_Move_RobotNorthFacing_CanMove()
        {
            RobotCommander robotCommander = new RobotCommander(new Robot(new RobotStateNorth(Table.Min, Table.Min)));
            string expected = "0,1,NORTH";
            robotCommander.SendCommand("move");
            string result = robotCommander.SendCommand("report");
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void RobotCommander_SendCommand_Move_RobotEastFacing_CanMove()
        {
            RobotCommander robotCommander = new RobotCommander(new Robot(new RobotStateEast(Table.Min, Table.Min)));
            string expected = "1,0,EAST";
            robotCommander.SendCommand("move");
            string result = robotCommander.SendCommand("report");
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void RobotCommander_SendCommand_Move_RobotSouthFacing_CanMove()
        {
            RobotCommander robotCommander = new RobotCommander(new Robot(new RobotStateSouth(Table.Min, Table.Max)));
            string expected = "0,3,SOUTH";
            robotCommander.SendCommand("move");
            string result = robotCommander.SendCommand("report");
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void RobotCommander_SendCommand_Move_RobotWestFacing_CanMove()
        {
            RobotCommander robotCommander = new RobotCommander(new Robot(new RobotStateWest(Table.Max, Table.Min)));
            string expected = "3,0,WEST";
            robotCommander.SendCommand("move");
            string result = robotCommander.SendCommand("report");
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void RobotCommander_SendCommand_Move_RobotNorthFacing_CanNotMove()
        {
            RobotCommander robotCommander = new RobotCommander(new Robot(new RobotStateNorth(Table.Min, Table.Max)));
            string expected = "0,4,NORTH";
            robotCommander.SendCommand("move");
            string result = robotCommander.SendCommand("report");
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void RobotCommander_SendCommand_Move_RobotEastFacing_CanNotMove()
        {
            RobotCommander robotCommander = new RobotCommander(new Robot(new RobotStateEast(Table.Max, Table.Min)));
            string expected = "4,0,EAST";
            robotCommander.SendCommand("move");
            string result = robotCommander.SendCommand("report");
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void RobotCommander_SendCommand_Move_RobotSouthFacing_CanNotMove()
        {
            RobotCommander robotCommander = new RobotCommander(new Robot(new RobotStateSouth(Table.Min, Table.Min)));
            string expected = "0,0,SOUTH";
            robotCommander.SendCommand("move");
            string result = robotCommander.SendCommand("report");
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void RobotCommander_SendCommand_Move_RobotWestFacing_CanNotMove()
        {
            RobotCommander robotCommander = new RobotCommander(new Robot(new RobotStateWest(Table.Min, Table.Min)));
            string expected = "0,0,WEST";
            robotCommander.SendCommand("move");
            string result = robotCommander.SendCommand("report");
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void RobotCommander_SendCommand_Move_RobotNotOnTable()
        {
            RobotCommander robotCommander = new RobotCommander(new Robot(new RobotStateDefault()));
            string expected = string.Empty;
            robotCommander.SendCommand("move");
            string result = robotCommander.SendCommand("report");
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void RobotCommander_SendCommand_Place_Incomplete_NoCoordinatesOrFacing()
        {
            RobotCommander robotCommander = new RobotCommander(new Robot(new RobotStateDefault()));
            string expected = string.Empty;
            robotCommander.SendCommand("place");
            string result = robotCommander.SendCommand("report");
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void RobotCommander_SendCommand_Place_Incomplete_CoordinatesOnly()
        {
            RobotCommander robotCommander = new RobotCommander(new Robot(new RobotStateDefault()));
            string expected = string.Empty;
            robotCommander.SendCommand("place 0,0");
            string result = robotCommander.SendCommand("report");
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void RobotCommander_SendCommand_Place_Incomplete_FacingOnly()
        {
            RobotCommander robotCommander = new RobotCommander(new Robot(new RobotStateDefault()));
            string expected = string.Empty;
            robotCommander.SendCommand("place north");
            string result = robotCommander.SendCommand("report");
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void RobotCommander_SendCommand_Place_Incomplete_MissingCommas()
        {
            RobotCommander robotCommander = new RobotCommander(new Robot(new RobotStateDefault()));
            string expected = string.Empty;
            robotCommander.SendCommand("place 0 0 NORTH");
            string result = robotCommander.SendCommand("report");
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void RobotCommander_SendCommand_Place_Incomplete_ExtraWhiteSpaceBetweenCOmmandAndCoordinates()
        {
            RobotCommander robotCommander = new RobotCommander(new Robot(new RobotStateDefault()));
            string expected = string.Empty;
            robotCommander.SendCommand("place   0,0,NORTH");
            string result = robotCommander.SendCommand("report");
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void RobotCommander_SendCommand_Place_Error_ExtraCommaInCoordinates()
        {
            RobotCommander robotCommander = new RobotCommander(new Robot(new RobotStateDefault()));
            string expected = string.Empty;
            robotCommander.SendCommand("place 0,,0,NORTH");
            string result = robotCommander.SendCommand("report");
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void RobotCommander_SendCommand_Place_Error_GarbageCoordinates()
        {
            RobotCommander robotCommander = new RobotCommander(new Robot(new RobotStateDefault()));
            string expected = string.Empty;
            robotCommander.SendCommand("place hjIU&%");
            string result = robotCommander.SendCommand("report");
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void RobotCommander_SendCommand_Place_Error_OffTable()
        {
            RobotCommander robotCommander = new RobotCommander(new Robot(new RobotStateDefault()));
            string expected = string.Empty;
            robotCommander.SendCommand("place 5,5,NORTH");
            string result = robotCommander.SendCommand("report");
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void RobotCommander_SendCommand_Left_RobotNorthFacing()
        {
            RobotCommander robotCommander = new RobotCommander(new Robot(new RobotStateNorth(Table.Min,Table.Min)));
            string expected = "0,0,WEST";
            robotCommander.SendCommand("left");
            string result = robotCommander.SendCommand("report");
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void RobotCommander_SendCommand_Left_RobotWestFacing()
        {
            RobotCommander robotCommander = new RobotCommander(new Robot(new RobotStateWest(Table.Min, Table.Min)));
            string expected = "0,0,SOUTH";
            robotCommander.SendCommand("left");
            string result = robotCommander.SendCommand("report");
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void RobotCommander_SendCommand_Left_RobotSouthFacing()
        {
            RobotCommander robotCommander = new RobotCommander(new Robot(new RobotStateSouth(Table.Min, Table.Min)));
            string expected = "0,0,EAST";
            robotCommander.SendCommand("left");
            string result = robotCommander.SendCommand("report");
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void RobotCommander_SendCommand_Left_RobotEastFacing()
        {
            RobotCommander robotCommander = new RobotCommander(new Robot(new RobotStateEast(Table.Min, Table.Min)));
            string expected = "0,0,NORTH";
            robotCommander.SendCommand("left");
            string result = robotCommander.SendCommand("report");
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void RobotCommander_SendCommand_Left_RobotNotOnTable()
        {
            RobotCommander robotCommander = new RobotCommander(new Robot(new RobotStateDefault()));
            string expected = string.Empty;
            robotCommander.SendCommand("left");
            string result = robotCommander.SendCommand("report");
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void RobotCommander_SendCommand_Right_RobotNorthFacing()
        {
            RobotCommander robotCommander = new RobotCommander(new Robot(new RobotStateNorth(Table.Min, Table.Min)));
            string expected = "0,0,EAST";
            robotCommander.SendCommand("right");
            string result = robotCommander.SendCommand("report");
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void RobotCommander_SendCommand_Right_RobotWestFacing()
        {
            RobotCommander robotCommander = new RobotCommander(new Robot(new RobotStateWest(Table.Min, Table.Min)));
            string expected = "0,0,NORTH";
            robotCommander.SendCommand("right");
            string result = robotCommander.SendCommand("report");
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void RobotCommander_SendCommand_Right_RobotSouthFacing()
        {
            RobotCommander robotCommander = new RobotCommander(new Robot(new RobotStateSouth(Table.Min, Table.Min)));
            string expected = "0,0,WEST";
            robotCommander.SendCommand("right");
            string result = robotCommander.SendCommand("report");
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void RobotCommander_SendCommand_Right_RobotEastFacing()
        {
            RobotCommander robotCommander = new RobotCommander(new Robot(new RobotStateEast(Table.Min, Table.Min)));
            string expected = "0,0,SOUTH";
            robotCommander.SendCommand("right");
            string result = robotCommander.SendCommand("report");
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void RobotCommander_SendCommand_Right_RobotNotOnTable()
        {
            RobotCommander robotCommander = new RobotCommander(new Robot(new RobotStateDefault()));
            string expected = string.Empty;
            robotCommander.SendCommand("right");
            string result = robotCommander.SendCommand("report");
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void RobotCommander_SendCommand_InvalidCommand()
        {
            RobotCommander robotCommander = new RobotCommander(new Robot(new RobotStateNorth(Table.Min, Table.Min)));
            string expected = "0,0,NORTH";
            robotCommander.SendCommand("abcdef");
            string result = robotCommander.SendCommand("report");
            Assert.AreEqual(expected, result);
        }
    }
}
