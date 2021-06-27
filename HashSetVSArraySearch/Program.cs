using System;
using System.Collections.Generic;
using System.Linq;

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace HashSetVSArraySearch
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<Test>();
        }
    }

    [MemoryDiagnoser, RankColumn]
    public class Test
    {
        private const int __Size = 10000;
        private readonly string[] __Strings;
        private readonly HashSet<string> __HashSet;

        public Test()
        {
            var char_num = Enumerable.Range(0, 'z' - 'a' + 1).ToArray();
            var chars_low = char_num.Select(i => (char)(i + 'a'));
            var chars_hi = char_num.Select(i => (char)(i + 'A'));
            var digits = Enumerable.Range('0', '9' - '0' + 1).Select(i => (char)i);
            var str = new string(chars_low.Concat(chars_hi).Concat(digits).ToArray());

            var rnd = new Random();
            __Strings = new string[__Size];
            for (var i = 0; i < __Size; i++)
            {
                var len = rnd.Next(10, 100);
                __Strings[i] = new string(Enumerable.Range(0, len).Select(_ => str[rnd.Next(str.Length)]).ToArray());
            }

            __HashSet = new HashSet<string>(__Strings);
        }

        [Benchmark]
        public bool LinearSearch()
        {
            var rnd = new Random();
            var index = rnd.Next(__Size);
            var search_str = __Strings[index];
            var result = Array.IndexOf(__Strings, search_str);
            return result >= 0;
        }

        [Benchmark]
        public bool HashSetSearch()
        {
            var rnd = new Random();
            var index = rnd.Next(__Size);
            var search_str = __Strings[index];
            var result = __HashSet.Contains(search_str);
            return result;
        }
    }
}
