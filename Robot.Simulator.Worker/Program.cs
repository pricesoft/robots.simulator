using System;
using Robots.Simulator;

namespace Robot.Simulator.Worker
{
  public class Program
  {
    static void Main(string[] args)
    {
      //Initiate Simulator
      InitiateSimulator();

      var robot = new ToyRobot();
      var surface = new Surface();

      var worker = new Robots.Simulator.Worker(robot, surface, Console.Out);

      while (true)
      {
        Console.WriteLine("Enter Command");
        Console.WriteLine("$$: ");
        var commandArgs = Console.ReadLine();

        worker.ProcessCommand(commandArgs);
      }
    }

    static void InitiateSimulator()
    {
      Console.WriteLine("Starting Simulator");
      Console.WriteLine("=====================");
      Console.WriteLine("=====================");
      Console.WriteLine(Environment.NewLine);
    }
  }
}
