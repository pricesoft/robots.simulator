using Robots.Simulator.Abstractions;

namespace Robots.Simulator.Strategies
{
  /// <summary>
  /// Orientation Strategy for all things South
  /// </summary>
  public class SouthOrientationStrategy : IOrientationStrategy
  {
    public IPosition MoveFrom(IPosition currentPosition)
    {
      if (currentPosition.Y <= 0)
        return currentPosition;

      currentPosition.Y--;

      return currentPosition;
    }

    public IOrientationStrategy TurnLeft()
    {
      return new WestOrientationStrategy();
    }

    public IOrientationStrategy TurnRight()
    {
      return new EastOrientationStrategy();
    }

    public OrientationEnum Name => OrientationEnum.South;
  }
}
