using System;
using System.Collections;
using System.Collections.Generic;

namespace AsyncAwaitUnderTheHood
{
    public class MyGenerator : IEnumerable<int>
    {
        private readonly int _stopAt;

        public MyGenerator(int stopAt)
        {
            _stopAt = stopAt;
        }

        public class MyEnumerator : IEnumerator<int>
        {
            private MyGenerator _generator;

            public MyEnumerator(MyGenerator generator)
            {
                _generator = generator;
            }
            
            public int Current { get; private set; } = -1;
            object IEnumerator.Current => Current;

            public bool MoveNext()
            {
                if (Current == _generator._stopAt)
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
            return new MyEnumerator(this);
        }
        
        public static void Test()
        {
            var generator = new MyGenerator(stopAt: 9);

            foreach (var item in generator)
            {
                Console.WriteLine($"Current Item: {item}");
            }
        }
    }
}