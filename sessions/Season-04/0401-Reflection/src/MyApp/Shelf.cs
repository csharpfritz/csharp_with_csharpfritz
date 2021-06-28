using System.Collections;
using System.Collections.Generic;

namespace MyApp {

    public class Shelf<T> : IList<T>
    {

        private List<T> _this = new List<T>();

        public T this[int index] { get => _this[index]; set => _this[index] = value; }

        public int Count => _this.Count;

        public bool IsReadOnly => false;

        public void Add(T item)
        {
            _this.Add(item);
        }

        public void Clear()
        {
            _this.Clear();
        }

        public bool Contains(T item)
        {
            return _this.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            _this.CopyTo(array, arrayIndex);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _this.GetEnumerator();
        }

        public int IndexOf(T item)
        {
            return _this.IndexOf(item);
        }

        public void Insert(int index, T item)
        {
            _this.Insert(index, item);
        }

        public bool Remove(T item)
        {
            return _this.Remove(item);
        }

        public void RemoveAt(int index)
        {
            _this.RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _this.GetEnumerator();
        }
    }

}