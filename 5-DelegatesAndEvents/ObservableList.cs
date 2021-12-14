namespace DelegatesAndEvents
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    /// <inheritdoc cref="IObservableList{T}" />
    public class ObservableList<TItem> : IObservableList<TItem>
    {
        private IList<TItem> _items;

        /// <inheritdoc cref="IObservableList{T}.ElementInserted" />
        public event ListChangeCallback<TItem> ElementInserted;

        /// <inheritdoc cref="IObservableList{T}.ElementRemoved" />
        public event ListChangeCallback<TItem> ElementRemoved;

        /// <inheritdoc cref="IObservableList{T}.ElementChanged" />
        public event ListElementChangeCallback<TItem> ElementChanged;

        /// <inheritdoc cref="ICollection{T}.Count" />
        public int Count { get => _items.Count; }

        /// <inheritdoc cref="ICollection{T}.IsReadOnly" />
        public bool IsReadOnly { get => _items.IsReadOnly; }

        public ObservableList()
        {
            _items = new List<TItem>();
        }

        /// <inheritdoc cref="IList{T}.this" />
        public TItem this[int index]
        {
            get => _items[index];
            set
            {
                ElementChanged?.Invoke(this, value, _items[index], index);
                _items[index] = value;
            }
        }

        /// <inheritdoc cref="IEnumerable{T}.GetEnumerator" />
        public IEnumerator<TItem> GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        /// <inheritdoc cref="IEnumerable.GetEnumerator" />
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        /// <inheritdoc cref="ICollection{T}.Add" />
        public void Add(TItem item)
        {
            if (!IsReadOnly)
            {
                _items.Add(item);
                ElementInserted?.Invoke(this, item, _items.IndexOf(item));
            }
        }

        /// <inheritdoc cref="ICollection{T}.Clear" />
        public void Clear()
        {
            if (!IsReadOnly)
            {
                _items.Clear();
            }
        }

        /// <inheritdoc cref="ICollection{T}.Contains" />
        public bool Contains(TItem item)
        {
            return _items.Contains(item);
        }

        /// <inheritdoc cref="ICollection{T}.CopyTo" />
        public void CopyTo(TItem[] array, int arrayIndex)
        {
            _items.CopyTo(array, arrayIndex);
        }

        /// <inheritdoc cref="ICollection{T}.Remove" />
        public bool Remove(TItem item)
        {
            if (!IsReadOnly && _items.Contains(item))
            {
                ElementRemoved?.Invoke(this, item, _items.IndexOf(item));
                return _items.Remove(item);
            }
            else
            {
                return false;
            }
        }

        /// <inheritdoc cref="IList{T}.IndexOf" />
        public int IndexOf(TItem item)
        {
            return _items.IndexOf(item);
        }

        /// <inheritdoc cref="IList{T}.RemoveAt" />
        public void Insert(int index, TItem item)
        {
            if (!IsReadOnly)
            {
                ElementInserted?.Invoke(this, item, index);
                _items.Insert(index, item);
            }
        }

        /// <inheritdoc cref="IList{T}.RemoveAt" />
        public void RemoveAt(int index)
        {
            if (!IsReadOnly)
            {
                ElementRemoved?.Invoke(this, _items[index], index);
                _items.RemoveAt(index);
            }
        }

        /// <inheritdoc cref="object.Equals(object?)" />
        public override bool Equals(object obj)
        {
            // TODO improve
            return base.Equals(obj);
        }

        /// <inheritdoc cref="object.GetHashCode" />
        public override int GetHashCode()
        {
            // TODO improve
            return base.GetHashCode();
        }

        /// <inheritdoc cref="object.ToString" />
        public override string ToString()
        {
            // TODO improve
            return base.ToString();
        }
    }
}
