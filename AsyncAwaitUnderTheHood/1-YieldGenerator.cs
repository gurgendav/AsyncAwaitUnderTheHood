using System;
using System.Collections;
using System.Collections.Generic;

namespace AsyncAwaitUnderTheHood
{
    public class YieldGenerator
    {
        public IEnumerable<int> GetSequence(int stopAt)
        {
            var i = -1;
            while (i != stopAt)
            {
                i++;
                yield return i;
            }
        }
        
        public static void Test()
        {
            var generator = new YieldGenerator();

            foreach (var item in generator.GetSequence(stopAt: 9))
            {
                Console.WriteLine($"Current Item: {item}");
            }
        }
    }
}