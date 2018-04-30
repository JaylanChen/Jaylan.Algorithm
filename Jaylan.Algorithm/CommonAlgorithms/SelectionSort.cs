using System.Collections.Generic;

namespace Jaylan.Algorithm.CommonAlgorithms
{
    /// <summary>
    /// 选择排序
    /// 
    /// 选择排序的思想其实和冒泡排序有点类似，都是在一次排序后把最小的元素放到最前面。但是过程不同，冒泡排序是通过相邻的比较和交换。
    /// 而选择排序是通过对整体的选择。举个栗子，对5,3,8,6,4这个无序序列进行简单选择排序，首先要选择5以外的最小数来和5交换，也就是选择3和5交换，一次排序后就变成了3,5,8,6,4.对剩下的序列一次进行选择和交换，最终就会得到一个有序序列。
    /// 其实选择排序可以看成冒泡排序的优化，因为其目的相同，只是选择排序只有在确定了最小数的前提下才进行交换，大大减少了交换的次数。
    /// 
    /// 时间复杂度：O(n²)
    /// </summary>
    public static class SelectionSort
    {
        public static List<int> Sort(List<int> list)
        {
            for (var i = 0; i < list.Count - 1; i++)
            {
                var minIndex = i;
                for (var j = i + 1; j < list.Count; j++)
                {
                    //寻找最小的数
                    if (list[j] < list[minIndex])
                    {
                        minIndex = j;//将最小数的索引保存
                    }
                }
                var temp = list[i];
                list[i] = list[minIndex];
                list[minIndex] = temp;
            }
            return list;
        }
    }
}
