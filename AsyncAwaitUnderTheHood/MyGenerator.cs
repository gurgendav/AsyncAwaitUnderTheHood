using System;
using System.Collections;
using System.Collections.Generic;

namespace AsyncAwaitUnderTheHood
{
    public class MyGenerator : IEnumerable<int>
    {
        public class MyEnumerator : IEnumerator<int>
        {
            public int Current { get; private set; } = -1;
            object IEnumerator.Current => Current;

            public bool MoveNext()
            {
                if (Current == 9)
                {
                    return false;
                }

                Current++;
                return true;
            }
            
            public void Reset()
            {
                throw new NotSupportedException();
            }

            public void Dispose()
            {
            }
        }
        
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        
        public IEnumerator<int> GetEnumerator()
        {
            return new MyEnumerator();
        }
        
        public static void Test()
        {
            var generator = new MyGenerator();

            foreach (var item in generator)
            {
                Console.WriteLine($"Current Item: {item}");
            }
        }
    }
}