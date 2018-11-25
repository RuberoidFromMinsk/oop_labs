using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
namespace lab10
{
	partial class MainClass
	{
		class MyQueue<T> : IEnumerable
        {
            private Queue<T> _queue;

            public Queue<T> Queue { get => _queue; set => _queue = value; }

            public MyQueue()
            {
                Queue = new Queue<T>();
            }

            public void Add(T item)
            {
                Queue.Enqueue(item);
            }

            public IEnumerator GetEnumerator()
            {
                return Queue.GetEnumerator();
            }
        }
	}
}
