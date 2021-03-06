﻿using System.Collections.Generic;

namespace Jaylan.Algorithm.CommonAlgorithms
{
    /// <summary>
    /// 冒泡排序
    /// 
    /// 已知一组无序数据a[1]、a[2]、……a[n]，需将其按升序排列。首先比较a[1]与a[2]的值，若a[1]大于a[2]则交换两者的值，否则不变。
    /// 再比较a[2]与a[3]的值，若a[2]大于a[3]则交换两者的值，否则不变。再比较a[3]与a[4]，以此类推，最后比较a[n-1]与a[n]的值。
    /// 这样处理一轮后，a[n]的值一定是这组数据中最大的。再对a[1]~a[n-1]以相同方法处理一轮，则a[n-1]的值一定是a[1]~a[n-1]中最大的。
    /// 再对a[1]~a[n-2]以相同方法处理一轮，以此类推。共处理n-1轮后a[1]、a[2]、……a[n]就以升序排列了。
    /// 降序排列与升序排列相类似，若a[1]小于a[2]则交换两者的值，否则不变，后面以此类推。
    /// 总的来讲，每一轮排序后最大（或最小）的数将移动到数据序列的最后，理论上总共要进行n(n-1）/2次交换。
    /// 
    /// 冒泡排序算法的运作如下：（从后往前）
    /// 1）比较相邻的元素。如果第一个比第二个大，就交换他们两个。
    /// 2）对每一对相邻元素作同样的工作，从开始第一对到结尾的最后一对。在这一点，最后的元素应该会是最大的数。
    /// 3）针对所有的元素重复以上的步骤，除了最后一个。
    /// 4）持续每次对越来越少的元素重复上面的步骤，直到没有任何一对数字需要比较。
    /// 
    /// 平均时间复杂度: O(n²)
    /// </summary>
    public static class BubbleSort
    {
        public static List<int> Sort(List<int> list)
        {
            // 要遍历的次数
            for (var i = 0; i < list.Count - 1; i++)
            {
                // 从后向前依次的比较相邻两个数的大小，遍历一次后，把数组中第i小的数放在第i个位置上
                for (var j = list.Count - 1; j > i; j--)
                {
                    // 比较相邻的元素，如果前面的数大于后面的数，则交换
                    if (list[j - 1] > list[j])
                    {
                        var temp = list[j - 1]; // 用来交换的临时数
                        list[j - 1] = list[j];
                        list[j] = temp;
                    }
                }
            }
            return list;
        }
    }
}
