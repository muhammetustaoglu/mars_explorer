using mars_explorer_entity;
using System;
using System.Collections.Generic;

namespace mars_explorer_business
{
    public class Explorer : IExplorer
    {
        protected IEvaluator Evaluator { get; set; }
        public Explorer(IEvaluator evaluator)
        {
            this.Evaluator = evaluator;
        }
        public List<string> Explore(List<string> lines)
        {
            IExploreEntity exploreEntity = this.Evaluator.Evaluate(lines);
            List<string> response = new List<string>();

            foreach (Rover rover in exploreEntity.Rovers)
            {
                foreach (char move in rover.Moves)
                {
                    switch (move)
                    {
                        case 'L':
                            rover.TurnLeft();
                            break;
                        case 'R':
                            rover.TurnRight();
                            break;
                        case 'M':
                            rover.ActOneGrid();
                            break;
                        default:
                            throw new ArgumentException(string.Format("Not expected character. {0}", move));
                    }
                }

                if (rover.PointX < 0 || rover.PointX > exploreEntity.HorizonX || rover.PointY < 0 || rover.PointY > exploreEntity.HorizonY)
                    response.Add(string.Format("Coordinates are out of rectangle surface with respect to given points. {0} {1} ", rover.PointX, rover.PointY));
                else
                    response.Add(string.Format("{0} {1} {2}", rover.PointX, rover.PointY, rover.Direction.ToString()));
            }

            return response;
        }
    }
}
