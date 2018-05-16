using System.IO;
using System.Runtime.InteropServices;
using Moq;
using NUnit.Framework;
using Robots.Simulator;
using Robots.Simulator.Abstractions;

namespace Robot.Simulator.Tests
{
  [TestFixture]
  public class WorkerTests
  {
    private IWorker _worker;

    private Mock<ISurface> _surface;
    private Mock<ToyRobotBase> _robot;

    [SetUp]
    public void Setup()
    {
      _robot = new Mock<ToyRobotBase>();
      _surface = new Mock<ISurface>();

      _worker = new Worker(_robot.Object, _surface.Object, new StringWriter());
    }

    [Test]
    public void ReturnRejectCommand_IfRobotNotPlacedYet()
    {
      //setup
      const string invalidFirstCommand = "move";

      //test
       _worker.ProcessCommand(invalidFirstCommand);

      //asserts
      _robot.Verify(c => c.Move(), Times.Never);
      _robot.Verify(c => c.Place(It.IsAny<int>(), It.IsAny<int>()), Times.Never);
      _robot.Verify(c => c.ChangeLeft(), Times.Never);
      _robot.Verify(c => c.ChangeRight(), Times.Never);
    }
  }
}
