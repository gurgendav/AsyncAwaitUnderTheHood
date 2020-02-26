using System;
using System.Collections;
using System.Collections.Generic;

namespace AsyncAwaitUnderTheHood
{
    public class YieldGenerator
    {
        public IEnumerable<int> GetSequence()
        {
            var current = -1;
            while (current != 9)
            {
                current++;
                yield return current;
            }
        }
        
        public static void Test()
        {
            var generator = new YieldGenerator();

            foreach (var item in generator.GetSequence())
            {
                Console.WriteLine($"Current Item: {item}");
            }
        }
    }
}