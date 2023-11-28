using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TriangleTypeLib
{
    public interface ITriangleTypeSpecifier
    {
        TriangleType Specify(float a, float b, float c);
    }
}