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
		class MyDictionary<T, D> : IEnumerable
        {
            private Dictionary<T, D> _dictionary;

            public Dictionary<T, D> Dictionary { get => _dictionary; set => _dictionary = value; }

            public MyDictionary()
            {
                Dictionary = new Dictionary<T, D>();
            }

            public void Add(T key, D value)
            {
                Dictionary.Add(key, value);
            }

            public void Delete(int count)
            {
                for (int i = 0; i < count; i++)
                {
                    Dictionary.Remove(Dictionary.FirstOrDefault().Key);
                }
            }

            public IEnumerator GetEnumerator()
            {
                return Dictionary.GetEnumerator();
            }
        }
	}
}
