using System.ComponentModel.DataAnnotations;

namespace TriangleTypeLib;
public class TriangleTypeSpecifier
{
    ITriangleTypeSpecifier _method;
    public TriangleTypeSpecifier(ITriangleTypeSpecifier method) => _method = method;
    public TriangleType Specify(float a, float b, float c) => _method.Specify(a, b, c);
}
