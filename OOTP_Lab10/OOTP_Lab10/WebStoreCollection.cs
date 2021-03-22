using System;
using System.Collections;
using System.Collections.Generic;

namespace OOTP_Lab10.Properties
{

    public class WebStoreCollection<T> : IList<T>
    {
        private int a;
        private IList<T> _listImplementation;

        public WebStoreCollection(List<string> list)
        {
        }

        public int A
        {
            get => a;
            set => a = value;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _listImplementation.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable) _listImplementation).GetEnumerator();
        }

        public void Add(T item)
        {
            _listImplementation.Add(item);
        }

        public void Clear()
        {
            _listImplementation.Clear();
        }

        public bool Contains(T item)
        {
            return _listImplementation.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            _listImplementation.CopyTo(array, arrayIndex);
        }

        public bool Remove(T item)
        {
            return _listImplementation.Remove(item);
        }

        public int Count => _listImplementation.Count;

        public bool IsReadOnly => _listImplementation.IsReadOnly;
        public object Display { get; set; }
        public object DisplayInLine { get; set; }

        public int IndexOf(T item)
        {
            return _listImplementation.IndexOf(item);
        }

        public void Insert(int index, T item)
        {
            _listImplementation.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            _listImplementation.RemoveAt(index);
        }

        public T this[int index]
        {
            get => _listImplementation[index];
            set => _listImplementation[index] = value;
        }
    }
}