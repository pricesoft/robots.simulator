using NUnit.Framework;
using Robots.Simulator;

namespace Robot.Simulator.Tests
{
  [TestFixture]
  public class ToyRobotTests
  {
    private ToyRobot _toyRobot;

    [SetUp]
    public void Setup()
    {
     _toyRobot = new ToyRobot();
    }

    [Test]
    public void ReturnInvalid_IfPlaceCommandIsNotZero_Zero()
    {
      //setup invalid placements
      const int _x = 4;
      const int _y = 3;

      //test
      var isValid = _toyRobot.Place(_x, _y);

      //assert
      Assert.AreEqual(false, isValid);
    }
  }
}
