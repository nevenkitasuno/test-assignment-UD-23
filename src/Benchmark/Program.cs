using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;

namespace Benchmark
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var config = DefaultConfig.Instance;
            var summary = BenchmarkRunner.Run<Benchmarks>(config.WithOptions(ConfigOptions.DisableOptimizationsValidator));
        }
    }
}