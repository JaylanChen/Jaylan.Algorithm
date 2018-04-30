using System.Collections.Generic;

namespace Jaylan.Algorithm.CommonAlgorithms
{
    /// <summary>
    /// 
    /// 
    /// 希尔(Shell)排序又称为缩小增量排序，它是一种插入排序。它是直接插入排序算法的一种威力加强版。
    ///基本思想：
    /// 把记录按步长 gap 分组，对每组记录采用直接插入排序方法进行排序。
    /// 随着步长逐渐减小，所分成的组包含的记录越来越多，当步长的值减小到 1 时，整个数据合成为一组，构成一组有序记录，则完成排序。
    /// 
    /// 平均时间复杂度: O(nlogn)
    /// </summary>
    public static class ShellSort
    {
        public static List<int> Sort(List<int> list)
        {
            var inc = 1;
            while (inc < list.Count / 3)//list.Count / 9
            {
                //动态定义间隔序列
                inc = inc * 3 + 1;
            }
            for (; inc > 0; inc /= 3)
            {
                for (var i = inc + 1; i <= list.Count; i += inc)
                {
                    var t = list[i - 1];
                    var j = i;
                    while ((j > inc) && (list[j - inc - 1] > t))
                    {
                        list[j - 1] = list[j - inc - 1];
                        j -= inc;
                    }
                    list[j - 1] = t;
                }
            }
            return list;
        }
    }
}
