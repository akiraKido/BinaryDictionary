using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace BinaryDictionary.Bench
{
    internal static class Program
    {
        private static void Main()
        {
            BenchmarkRunner.Run<Tests>();
        }
    }

    public class Tests
    {
        [Benchmark]
        public bool BinaryDictionary()
        {
            var bd = new BinaryDictionary();
            bd.Add(1);
            return bd.Contains(1);
        }

        [Benchmark]
        public bool HashSet()
        {
            var set = new HashSet<int>();
            set.Add(1);
            return set.Contains(1);
        }

        [Benchmark]
        public bool LargeNumber_BinaryDictionary()
        {
            var bd = new BinaryDictionary();
            for (int i = 0; i <= 1000000; i++)
            {
                bd.Add(i);
            }
            return bd.Contains(1000000);
        }
        
        [Benchmark]
        public bool LargeNumber_HashSet()
        {
            var set = new HashSet<int>();
            for (int i = 0; i <= 1000000; i++)
            {
                set.Add(i);
            }
            return set.Contains(1000000);
        }
    }
}