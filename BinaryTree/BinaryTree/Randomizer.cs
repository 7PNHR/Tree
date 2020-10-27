using System;
using System.Collections.Generic;

namespace BinaryTree
{
    public static class Randomizer
    {
        public static List<int> GetRandomValuesList(int amount, int min, int max)
        {
            var rnd = new Random();
            var list = new List<int>();
            for (var i = 0; i < amount; i++)
                list.Add(rnd.Next(min, max));
            return list;
        }
    }
}