using System.Linq;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace mars_explorer_service
{
    public class InputEvaluator : IEvaluator
    {
        private readonly List<string> _inputLines = null;

        public InputEvaluator(List<string> inputLines)
        {
            this._inputLines = inputLines;
        }
        public void Evaluate(int horizonX, int horizonY, List<Rover> commands)
        {
            string[] horizon = this._inputLines[0].Trim().Split(' ');

            try
            {
                horizonX = int.Parse(horizon[0]);
                horizonY = int.Parse(horizon[1]);
                List<string> inputLinesExceptFirst = this._inputLines.Skip(1).ToList();
                Rover rover = null;
                
                for (int i = 0; i < inputLinesExceptFirst.Count - 1; i++)
                {
                    rover = new Rover();

                    if (i % 2 == 0)
                    {
                        string[] roverPosition = this._inputLines[i].Split(' ');
                        rover.PointX = int.Parse(roverPosition[0]);
                        rover.PointY = int.Parse(roverPosition[1]);
                        rover.Direction = (Direction)Enum.Parse(typeof(Direction), roverPosition[2]);
                    }
                    else if (i % 2 == 1)
                    {
                        rover.Moves = Regex.Split(this._inputLines[i], string.Empty).ToList();
                        commands.Add(rover);
                    }
                }
            }
            catch (ArgumentException)
            {
                throw;
            }
        }
    }
}
