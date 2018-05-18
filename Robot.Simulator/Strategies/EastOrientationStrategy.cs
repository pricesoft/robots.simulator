using Robots.Simulator.Abstractions;

namespace Robots.Simulator.Strategies
{
  /// <summary>
  /// Orientation Strategy for all things East
  /// </summary>
  public class EastOrientationStrategy : IOrientationStrategy
  {
    public IPosition MoveFrom(IPosition currentPosition)
    {
      if (currentPosition.X >= 4)
        return currentPosition;

      currentPosition.X++;

      return currentPosition;
    }

    public IOrientationStrategy TurnLeft()
    {
      return new NorthOrientationStrategy();
    }

    public IOrientationStrategy TurnRight()
    {
      return new SouthOrientationStrategy();
    }

    public OrientationEnum Name => OrientationEnum.East;
  }
}
