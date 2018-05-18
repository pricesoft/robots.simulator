namespace Robots.Simulator.Abstractions
{
  public interface IOrientationStrategy
  {
    OrientationEnum Name { get; }

    IOrientationStrategy TurnRight();
    IOrientationStrategy TurnLeft();
    IPosition MoveFrom(IPosition currentPosition);
  }
}
