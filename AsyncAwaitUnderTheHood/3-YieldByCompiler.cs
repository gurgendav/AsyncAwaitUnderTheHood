using System;
using System.Collections;
using System.Collections.Generic;

namespace AsyncAwaitUnderTheHood
{
    public class CompilerGenerator
    {
        public static void Test()
        {
            var generator = new CompilerGenerator();

            foreach (var item in generator.GetSequence(stopAt: 9))
            {
                Console.WriteLine($"Current Item: {item}");
            }
        }
        
        public IEnumerable<int> GetSequence(int stopAt)
        {
            var enumerator = new YieldByCompiler();
            enumerator.StopAt = stopAt;
            return enumerator;
        }
        
        public class YieldByCompiler : IEnumerable<int>, IEnumerator<int>
        {
            public int StopAt;
        
            public int Current { get; private set; }
            object IEnumerator.Current => Current;

            private int _state = 0;
        
            private int _i;
        
            public IEnumerator<int> GetEnumerator() => this;
            IEnumerator IEnumerable.GetEnumerator() => this;

            public bool MoveNext()
            {
                switch (_state)
                {
                    case 0:
                        _i = -1;
                        break;
                }

                if (_i == StopAt)
                {
                    return false;
                }
            
                _state = 1;
                _i++;
            
                Current = _i;

                return true;
            }

            public void Reset()
            {
                throw new System.NotSupportedException();
            }

            public void Dispose()
            {
            }
        }
    }
}