using System;
using System.Collections.Generic;
using System.Diagnostics;
using Jaylan.Algorithm.CommonAlgorithms;

namespace Jaylan.Algorithm
{
    public class AlgorithmHelper
    {
        public static void RunSort()
        {
            var random = new Random(DateTime.Now.Millisecond);
            var list = new List<int>();
            for (int i = 0; i < 50; i++)
            {
                var num = random.Next(0, 1000);
                list.Add(num);
            }

            Console.Write("原始数组：");
            foreach (var num in list)
            {
                Console.Write(num + "  ");
            }
            Console.WriteLine();

            var stopwatch = new Stopwatch();
            stopwatch.Start();

            BubbleSort.Sort(list);

            stopwatch.Stop();

            Console.WriteLine();
            Console.WriteLine("排序耗时：" + stopwatch.Elapsed);
            Console.WriteLine();

            Console.Write("排序后数组：");
            foreach (var num in list)
            {
                Console.Write(num + "   ");
            }
            Console.WriteLine();

        }
    }
}
