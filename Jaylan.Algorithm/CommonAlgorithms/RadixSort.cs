using System.Collections.Generic;

namespace Jaylan.Algorithm.CommonAlgorithms
{
    /// <summary>
    /// 基数排序
    /// 
    /// 基数排序是非比较排序算法,算法的时间复杂度是O(n). 相比于快速排序的O(nlgn),从表面上看具有不小的优势。
    /// 但事实上可能有些出入,因为基数排序的n可能具有比较大的系数K.因此在具体的应用中,应首先对这个排序函数的效率进行评估。
    /// 基数排序的主要思路是,将所有待比较数值(注意, 必须是正整数)统一为同样的数位长度,数位较短的数前面补零。
    /// 然后, 从最低位开始, 依次进行一次稳定排序(我们常用上一篇blog介绍的计数排序算法, 因为每个位可能的取值范围是固定的从0到9)。
    /// 这样从最低位排序一直到最高位排序完成以后, 数列就变成一个有序序列。
    /// 
    /// 基数是一种不稳定的排序，它的时间复杂度为O（k*n），k表示最大数的位数，所以当一个序列中有一个很大很大的数时，它排序所花费的时间是非常高昂的。
    /// 基数排序的原理是一位一位来排序：先按个位大小排序，再按十位大小排序，接着百位……，一直排到最大位数停止。
    /// 
    /// 平均时间复杂度: O(k*n)
    /// </summary>
    public static class RadixSort
    {
        public static List<int> Sort(List<int> list, int digit)
        {
            const int radix = 10; // 基数
            var count = new int[radix]; // 存放各个桶的数据统计个数
            var bucket = new int[list.Count];

            // 按照从低位到高位的顺序执行排序过程
            for (var d = 1; d <= digit; d++)
            {

                // 置空各个桶的数据统计
                var i = 0;
                for (i = 0; i < radix; i++)
                {
                    count[i] = 0;
                }

                // 统计各个桶将要装入的数据个数
                var j = 0;
                for (i = 0; i <= list.Count - 1; i++)
                {
                    j = GetDigit(list[i], d);
                    count[j]++;
                }

                // count[i]表示第i个桶的右边界索引
                for (i = 1; i < radix; i++)
                {
                    count[i] = count[i] + count[i - 1];
                }

                // 将数据依次装入桶中
                // 这里要从右向左扫描，保证排序稳定性
                for (i = list.Count - 1; i >= 0; i--)
                {
                    j = GetDigit(list[i], d); // 求出关键码的第k位的数字， 例如：576的第3位是5
                    bucket[count[j] - 1] = list[i]; // 放入对应的桶中，count[j]-1是第j个桶的右边界索引
                    count[j]--; // 对应桶的装入数据索引减一
                }

                // 将已分配好的桶中数据再倒出来，此时已是对应当前位数有序的表
                for (i = 0, j = 0; i <= list.Count - 1; i++, j++)
                {
                    list[i] = bucket[j];
                }
            }
            return list;
        }

        // 获取x这个数的d位数上的数字
        // 比如获取123的1位数，结果返回3
        private static int GetDigit(int x, int d)
        {
            var a = new[] { 1, 1, 10, 100 };
            //此测试最大数是百位数，所以只要到100就可以了
            return ((x / a[d]) % 10);
        }
    }
}
