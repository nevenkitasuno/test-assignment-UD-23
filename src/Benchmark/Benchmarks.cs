using System;
using BenchmarkDotNet;
using BenchmarkDotNet.Attributes;
using TriangleTypeLib;

namespace Benchmark
{
    public class Benchmarks
    {
        readonly int inputLimit = 50;

        private void Bench(ITriangleTypeSpecifier specifier)
        {
            for (float i = 0.5f; i < inputLimit; i++)
                for (float j = 0.5f; j < inputLimit; j++)
                    for (float k = 0.5f; k < inputLimit; k++)
                        specifier.Specify(i, j, k);
        }

        [Benchmark]
        public void Sort()
        {
            Bench(new TriangleTypeSpecifySort());
        }

        [Benchmark]
        public void Swap()
        {
            Bench(new TriangleTypeSpecifySwap());
        }
    }
}
