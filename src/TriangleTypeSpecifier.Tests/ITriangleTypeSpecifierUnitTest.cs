using Microsoft.VisualBasic;
using TriangleTypeLib;

namespace TriangleTypeLib.Tests;

public abstract class TestBase
{
    private readonly ITriangleTypeSpecifier _specifier;

    public TestBase(ITriangleTypeSpecifier specifier)
    {
        _specifier = specifier;
    }

    private void CanSpecAssert(float a, float b, float c, TriangleType expected)
    {
        var result = _specifier.Specify(a, b, c);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(5, 9, 123)]
    [InlineData(123, 5, 9)]
    [InlineData(5, 123, 9)]
    public void CanSpecImpossibleTheory(float a, float b, float c)
    {
        var expected = TriangleType.Impossible;
        CanSpecAssert(a, b, c, expected);
    }

    [Theory]
    [InlineData(7, 10, 16)]
    [InlineData(7, 8, 12)]
    [InlineData(16, 10, 7)]
    [InlineData(10, 16, 7)]
    [InlineData(25, 25, 48)]
    public void CanSpecObtuseTheory(float a, float b, float c)
    {
        var expected = TriangleType.Obtuse;
        CanSpecAssert(a, b, c, expected);
    }

    [Theory]
    [InlineData(5, 6, 7)]
    [InlineData(7, 6, 5)]
    [InlineData(5, 7, 6)]
    [InlineData(5, 7, 8)]
    public void CanSpecAcuteTheory(float a, float b, float c)
    {
        var expected = TriangleType.Acute;
        CanSpecAssert(a, b, c, expected);
    }

    [Theory]
    [InlineData(3, 4, 5)]
    [InlineData(5, 4, 3)]
    [InlineData(3, 5, 4)]
    [InlineData(5, 12, 13)]
    [InlineData(8, 15, 17)]
    [InlineData(9, 40, 41)]
    public void CanSpecRightTheory(float a, float b, float c)
    {
        var expected = TriangleType.Right;
        CanSpecAssert(a, b, c, expected);
    }

    [Theory]
    [InlineData(0, 0, 0)]
    [InlineData(-5, -4, -3)]
    [InlineData(-3, 5, 4)]
    [InlineData(5, -12, -13)]
    [InlineData(8, 15, 0)]
    [InlineData(9, 0, 41)]
    [InlineData(0, 4, 3)]
    [InlineData(-5, 0, 3)]
    [InlineData(5, 0, -5)]
    public void NegativeAndZeroTheory(float a, float b, float c)
    {
        var expected = TriangleType.Impossible;
        CanSpecAssert(a, b, c, expected);
    }

    [Theory]
    [InlineData(float.MaxValue, 4, 5, TriangleType.Impossible)]
    [InlineData(3, float.MaxValue, 5, TriangleType.Impossible)]
    [InlineData(3, 5, float.MaxValue, TriangleType.Impossible)]
    [InlineData(float.MaxValue, float.MaxValue - 1, float.MaxValue - 2, TriangleType.Acute)]
    public void MaxFloatTheory(float a, float b, float c, TriangleType expected) => CanSpecAssert(a, b, c, expected);

    [Theory]
    [InlineData(2, 4, 6)]
    [InlineData(6, 4, 2)]
    [InlineData(2, 6, 4)]
    public void DegeneracyTheory(float a, float b, float c)
    {
        var expected = TriangleType.Obtuse;
        CanSpecAssert(a, b, c, expected);
    }

    [Theory]
    [InlineData(2.9, 3.8, 5.2)]
    [InlineData(5.2, 2.9, 3.8)]
    [InlineData(2.9, 5.2, 3.8)]
    public void CanSpecFloatObtuseTheory(float a, float b, float c)
    {
        var expected = TriangleType.Obtuse;
        CanSpecAssert(a, b, c, expected);
    }

    [Theory]
    [InlineData(2.9, 3.8, 4.2)]
    [InlineData(4.2, 2.9, 3.8)]
    [InlineData(2.9, 4.2, 3.8)]
    public void CanSpecFloatAcuteTheory(float a, float b, float c)
    {
        var expected = TriangleType.Acute;
        CanSpecAssert(a, b, c, expected);
    }
}

public class TriangleTypeSpecifySortTests : TestBase
{
  public TriangleTypeSpecifySortTests(): base(new TriangleTypeSpecifySort()) { }
}

public class TriangleTypeSpecifySwapTests : TestBase
{
  public TriangleTypeSpecifySwapTests(): base(new TriangleTypeSpecifySwap()) { }
}