using NUnit.Framework;
using Robots.Simulator;
using Robots.Simulator.Strategies;

namespace Robot.Simulator.Tests
{
  [TestFixture]
  public class StrategyTests
  {
    private NorthOrientationStrategy _northernOrientationStrategy;
    private SouthOrientationStrategy _southernOrientationStrategy;
    private WestOrientationStrategy _westernOrientationStrategy;
    private EastOrientationStrategy _easternOrientationStrategy;

    [SetUp]
    public void Setup()
    {
      _northernOrientationStrategy = new NorthOrientationStrategy();
      _southernOrientationStrategy = new SouthOrientationStrategy();
      _westernOrientationStrategy = new WestOrientationStrategy();
      _easternOrientationStrategy = new EastOrientationStrategy();
    }

    [Test]
    public void PreventMove_WhenNorthernStrategyOutOfBounds()
    {
      //assumes robot is on Northern boundary
      const int NorthernBoundaryPosition = 4;

      var currentPosition = new Position
      {
        X = 0,
        Y = NorthernBoundaryPosition
      };

      var newPosition = _northernOrientationStrategy.MoveFrom(currentPosition);

      //asserts that position remained the same
      Assert.AreEqual(newPosition.Y, NorthernBoundaryPosition);
    }

    [Test]
    public void PreventMove_WhenSouthernStrategyOutOfBounds()
    {
      //assumes robot is on Southern boundary
      const int SouthernBoundaryPosition = 0;

      var currentPosition = new Position
      {
        X = 0,
        Y = SouthernBoundaryPosition
      };

      var newPosition = _southernOrientationStrategy.MoveFrom(currentPosition);

      //asserts that position remained the same
      Assert.AreEqual(newPosition.Y, SouthernBoundaryPosition);
    }

    [Test]
    public void PreventMove_WhenWesternStrategyOutOfBounds()
    {
      //assumes robot is on Western boundary
      const int WesternBoundaryPosition = 0;

      var currentPosition = new Position
      {
        Y = 0,
        X = WesternBoundaryPosition
      };

      var newPosition = _westernOrientationStrategy.MoveFrom(currentPosition);

      //asserts that position remained the same
      Assert.AreEqual(newPosition.X, WesternBoundaryPosition);
    }

    [Test]
    public void PreventMove_WhenEasternStrategyOutOfBounds()
    {
      //assumes robot is on Eastern boundary
      const int EasternBoundaryPosition = 4;

      var currentPosition = new Position
      {
        Y = 0,
        X = EasternBoundaryPosition
      };

      var newPosition = _easternOrientationStrategy.MoveFrom(currentPosition);

      //asserts that position remained the same
      Assert.AreEqual(EasternBoundaryPosition, newPosition.X);
    }
  }
}
