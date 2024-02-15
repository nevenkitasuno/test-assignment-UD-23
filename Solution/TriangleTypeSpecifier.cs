using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TriangleTypeLib
{
    public class TriangleTypeSpecifySwap : ITriangleTypeSpecifier
    {
        public TriangleType Specify(float a, float b, float c) {
            double[] sides = new double[3]{a, b, c};

            if (sides[0] > sides[1])
                (sides[0], sides[1]) = (sides[1], sides[0]);
            if (sides[0] > sides[2])
                (sides[0], sides[2]) = (sides[2], sides[0]);
            if (sides[1] > sides[2])
                (sides[1], sides[2]) = (sides[2], sides[1]);

            if (sides[0] + sides[1] < sides[2] ||
                sides[0] <= 0 || sides[0] <= 0 || sides[0] <= 0)
                return TriangleType.Impossible;

            var shortestSquaresSum = sides[0] * sides[0] + sides[1] * sides[1];
            var longestSquare = sides[2] * sides[2];

            // if (Math.Abs(longestSquare - shortestSquaresSum) < Options.Epsilon)
            //     return TriangleType.Right;
            // else if (longestSquare > shortestSquaresSum)
            //     return TriangleType.Obtuse;
            // else
            //     return TriangleType.Acute;

            if (longestSquare > shortestSquaresSum + Options.Epsilon)
                return TriangleType.Obtuse;
            else if (longestSquare < shortestSquaresSum - Options.Epsilon)
                return TriangleType.Acute;
            else
                return TriangleType.Right;
        }
    }
}