using System.Collections.Generic;

namespace Jaylan.Algorithm.CommonAlgorithms
{
    /// <summary>
    /// 堆排序
    /// 
    /// 堆排序其实要利用到二叉堆，二叉堆其实完全可以理解为一颗有限制的完全二叉树。
    /// 二叉堆的定义：二叉堆可以分为最大堆和最小堆。最大堆为对于所有节点它的左右节点权值一定比它小，最小堆为对于所有节点它的左右节点权值一定比它大。
    /// 二叉堆的插入：将一个序列下表从0开始一个一个往堆里插入，因为满足完全二叉树性质，所以这么做是可行的。对于插入的第i个数，那么从下往上，它的父亲节点为（i-1）/2个数，再根据二叉堆的性质进行调整。
    /// 二叉堆的删除：每次进行一次堆调整之后，根节点必是最大的（最大堆），每次把根节点a[0] 取出和数组第n个数互换，然后再用数组第1个到第n-1个数再次建堆，如此反复取出再建堆，那么得到的新序列必是一个有序序列
    /// 
    /// 平均时间复杂度: O(nlogn)
    /// </summary>
    public static class HeapSort
    {
        public static List<int> Sort(List<int> list)
        {
            BuildMaxHeap(list);    //创建大顶推（初始状态看做：整体无序）
            for (var i = list.Count - 1; i > 0; i--)
            {
                //将堆顶元素依次与无序区的最后一位交换（使堆顶元素进入有序区）
                var temp = list[0];
                list[0] = list[i];
                list[i] = temp;
                MaxHeapify(list, 0, i); //重新将无序区调整为大顶堆
            }
            return list;
        }

        ///<summary>
        /// 创建大顶推（根节点大于左右子节点）
        ///</summary>
        ///<param name="list">待排数组</param>
        private static void BuildMaxHeap(List<int> list)
        {
            //根据大顶堆的性质可知：数组的前半段的元素为根节点，其余元素都为叶节点
            for (int i = list.Count / 2 - 1; i >= 0; i--) //从最底层的最后一个根节点开始进行大顶推的调整
            {
                MaxHeapify(list, i, list.Count); //调整大顶堆
            }
        }

        ///<summary>
        /// 大顶推的调整过程
        ///</summary>
        ///<param name="list">待调整的数组</param>
        ///<param name="currentIndex">待调整元素在数组中的位置（即：根节点）</param>
        ///<param name="heapSize">堆中所有元素的个数</param>
        private static void MaxHeapify(List<int> list, int currentIndex, int heapSize)
        {
            var left = 2 * currentIndex + 1;    //左子节点在数组中的位置
            var right = 2 * currentIndex + 2;   //右子节点在数组中的位置
            var large = currentIndex;   //记录此根节点、左子节点、右子节点 三者中最大值的位置

            if (left < heapSize && list[left] > list[large])  //与左子节点进行比较
            {
                large = left;
            }
            if (right < heapSize && list[right] > list[large])    //与右子节点进行比较
            {
                large = right;
            }
            if (currentIndex != large)  //如果 currentIndex != large 则表明 large 发生变化（即：左右子节点中有大于根节点的情况）
            {
                //将左右节点中的大者与根节点进行交换（即：实现局部大顶堆）
                var temp = list[currentIndex];
                list[currentIndex] = list[large];
                list[large] = temp;

                MaxHeapify(list, large, heapSize); //以上次调整动作的large位置（为此次调整的根节点位置），进行递归调整
            }
        }

    }


}
