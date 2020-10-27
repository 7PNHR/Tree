using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;

namespace BinaryTree
{
    public static class MeasureTime
    {
        public static TimeSpan MeasureTree(int count, int maxValue)
        {
            var rnd = new Random();
            var tree = new BinaryTree<int>();       
            var h = tree.FindHeight();
            for (var i = 0; i < count; i++)
                tree.Add(rnd.Next(1,maxValue+1));
            var timer = new Stopwatch();
            tree.GetKeys();
            GC.Collect();
            GC.WaitForPendingFinalizers();
            timer.Start();
            var arrayKeys = tree.GetKeys();
            timer.Stop();
            return timer.Elapsed;
        }
        
        public static TimeSpan MeasureList(List<int> list)
        {
            var timer = new Stopwatch();
            GC.Collect();
            GC.WaitForPendingFinalizers();
            timer.Start();
            list = list.OrderBy(x => x).ToList();
            timer.Stop();
            return timer.Elapsed;
        }
        
    }
}