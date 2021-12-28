using mars_explorer_entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace mars_explorer_business
{
    public class InputEvaluator : IEvaluator
    {
        protected IExploreEntity ExploreEntity { get; set; }
        public InputEvaluator(IExploreEntity exploreEntity)
        {
            this.ExploreEntity = exploreEntity;
        }

        public IExploreEntity Evaluate(List<string> inputLines)
        {
            string[] horizon = inputLines[0].Trim().Split(' ');

            try
            {
                this.ExploreEntity.HorizonX = int.Parse(horizon[0]);
                this.ExploreEntity.HorizonY = int.Parse(horizon[1]);
                List<string> inputLinesExceptFirst = inputLines.Skip(1).ToList();
                Rover rover = null;

                for (int i = 0; i <= inputLinesExceptFirst.Count - 1; i++)
                {
                    if (i % 2 == 0)
                    {
                        rover = new Rover();
                        string[] roverPosition = inputLinesExceptFirst[i].Split(' ');
                        rover.PointX = int.Parse(roverPosition[0]);
                        rover.PointY = int.Parse(roverPosition[1]);
                        rover.Direction = (Direction)Enum.Parse(typeof(Direction), roverPosition[2]);
                    }
                    else if (i % 2 == 1)
                    {
                        rover.Moves = inputLinesExceptFirst[i].ToCharArray().ToList();
                        //Regex.Split(inputLinesExceptFirst[i], string.Empty).ToList();
                        this.ExploreEntity.Rovers.Add(rover);
                    }
                }
            }
            catch (ArgumentException)
            {
                throw;
            }

            return this.ExploreEntity;
        }
    }
}
