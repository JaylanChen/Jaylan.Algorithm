﻿using System.Collections.Generic;
using System.Linq;

namespace Jaylan.Algorithm.CommonAlgorithms
{
    /// <summary>
    /// 桶排序
    /// 
    /// 桶排序是计数排序的升级版。它利用了函数的映射关系，高效与否的关键就在于这个映射函数的确定。
    /// 为了使桶排序更加高效，我们需要做到这两点：
    /// 在额外空间充足的情况下，尽量增大桶的数量
    /// 使用的映射函数能够将输入的N个数据均匀的分配到K个桶中
    /// 同时，对于桶中元素的排序，选择何种比较排序算法对于性能的影响至关重要。
    /// 什么时候最快（Best Cases）：
    /// 当输入的数据可以均匀的分配到每一个桶中
    /// 什么时候最慢（Worst Cases）：
    /// 当输入的数据被分配到了同一个桶中
    /// 
    /// 时间复杂度: O(n),但是耗空间
    /// </summary>
    public static class BucketSort
    {
        public static List<int> Sort(List<int> list, int max)
        {
            //声明一个长度为max+1的数组，并把数组中的元素全部初始化为0
            var tempArray = Enumerable.Repeat(0, max + 1).ToArray();
            for (var i = 0; i < list.Count; i++)
            {
                tempArray[i] += 1;//将tempArray下标中等于intArray[i]的元素+1
            }

            var insertIndex = 0;
            for (var j = 0; j < tempArray.Length; j++)
            {
                for (var k = 0; k < tempArray[j]; k++)
                    list[insertIndex++] = j;//将排序后的元素插入数组tempArray的下标即元素的值
            }

            return list;
        }
    }
}
