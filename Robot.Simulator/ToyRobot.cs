﻿using Robots.Simulator.Abstractions;
using Robots.Simulator.Strategies;

namespace Robots.Simulator
{
  public class ToyRobot : ToyRobotBase
  {
    private const int _x = 0,  _y = 0;
    private static IPosition _currentPosition { get; set; }
    private static IOrientationStrategy _currentOrientation { get; set; }

    //strategy assumes starting point is south-west
    public override bool Place(int x, int y)
    {
      if (!x.Equals(_x) || !y.Equals(_y))
      {
        return false;
      }

      _currentPosition = new Position
      {
        X = x,
        Y = y
      };

      _currentOrientation = new NorthOrientationStrategy();

      Report("placed");

      return true;
    }

    public override void Move()
    {
      _currentPosition = _currentOrientation.MoveFrom(_currentPosition);

      Report("moved");
    }

    public override void ChangeLeft()
    {
      _currentOrientation = _currentOrientation.TurnLeft();

      Report("turned left");
    }

    public override void ChangeRight()
    {
      _currentOrientation = _currentOrientation.TurnRight();

      Report("turned right");
    }

    public override IOrientationStrategy GetCurrentOrientation()
    {
      return _currentOrientation;
    }

    public override IPosition GetCurrentPosition()
    {
      return _currentPosition;
    }
  }
}
