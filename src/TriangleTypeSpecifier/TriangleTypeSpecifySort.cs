using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TriangleTypeLib
{
    public class TriangleTypeSpecifySort : ITriangleTypeSpecifier
    {
        public TriangleType Specify(float a, float b, float c) {
            double[] sides = new double[3]{a, b, c};

            Array.Sort(sides);

            if (sides[0] + sides[1] < sides[2] ||
                sides[0] <= 0 || sides[0] <= 0 || sides[0] <= 0)
                return TriangleType.Impossible;

            var shortestSquaresSum = sides[0] * sides[0] + sides[1] * sides[1];
            var longestSquare = sides[2] * sides[2];

            if (longestSquare > shortestSquaresSum)
                return TriangleType.Obtuse;
            else if (longestSquare < shortestSquaresSum)
                return TriangleType.Acute;
            else
                return TriangleType.Right;
        }
    }
}