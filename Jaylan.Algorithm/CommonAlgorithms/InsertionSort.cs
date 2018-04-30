using System.Collections.Generic;

namespace Jaylan.Algorithm.CommonAlgorithms
{
    /// <summary>
    /// 插入排序
    /// 
    /// 插入排序原理很简单，讲一组数据分成两组，我分别将其称为有序组与待插入组。
    /// 每次从待插入组中取出一个元素，与有序组的元素进行比较，并找到合适的位置，将该元素插到有序组当中。
    /// 就这样，每次插入一个元素，有序组增加，待插入组减少。直到待插入组元素个数为0。当然，插入过程中涉及到了元素的移动。
    /// 
    /// 插入排序算法有种递归的思想在里面，它由N-1趟排序组成。初始时，只考虑数组下标0处的元素，只有一个元素，显然是有序的。
    /// 然后第一趟 对下标 1 处的元素进行排序，保证数组[0, 1] 上的元素有序；
    /// 第二趟 对下标 2 处的元素进行排序，保证数组[0, 2] 上的元素有序；
    /// .....
    /// .....
    /// 第N-1趟对下标 N-1 处的元素进行排序，保证数组[0, N - 1] 上的元素有序，也就是整个数组有序了。
    /// 它的递归思想就体现在：当对位置 i 处的元素进行排序时，[0, i-1] 上的元素一定是已经有序的了。
    /// 
    /// 平均时间复杂度: O(n²)
    /// </summary>
    public static class InsertionSort
    {
        public static List<int> Sort(List<int> list)
        {
            for (var i = 1; i < list.Count; i++)
            {
                var preIndex = i - 1;//i-1即为有序组最后一个元素（与待插入元素相邻）的下标
                var current = list[i];//从待插入组取出第一个元素
                while (preIndex >= 0 && list[preIndex] > current)//注意判断条件为两个，j>=0对其进行边界限制。第二个为插入判断条件
                {
                    list[preIndex + 1] = list[preIndex];//若不是合适位置，有序组元素向后移动
                    preIndex--;
                }
                list[preIndex + 1] = current;//找到合适位置，将元素插入
            }
            return list;
        }
    }
}
