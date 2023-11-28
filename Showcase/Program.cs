using Solution;

Console.WriteLine("Type in lengths of triangle sides: ");
var lengths = Console.ReadLine().Split(' ').Select(float.Parse).ToArray();

var res = TriangleTypeSpecifier.Specify(lengths[0], lengths[1], lengths[2]);

Console.WriteLine("This triangle is " + Enum.GetName(res));