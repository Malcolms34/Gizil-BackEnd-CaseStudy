using System;
using System.IO;
using System.Text;
using NUnit.Framework;
using RobotVacuumCleanerApp.Models;

namespace RobotVacuumCleanerApp.UnitTest
{
    public class AppTest
    {
        
        [Test]
        public void Test_FirstPosition()
        {
            // Action
            var result = Room.ValidateFirstPosition(1,2,1,2);

            // Assert
            Assert.AreEqual((false), result);
            Assert.Fail("This test failed");
        }


    }
}
