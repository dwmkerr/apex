using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Windows.Threading;
using System.Threading;
using System.Windows;

namespace Apex.MVVM
{
    /// <summary>
    /// Represents a thread safe observable collection.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SafeObservableCollection<T> : IList<T>, INotifyCollectionChanged
    {
        private readonly IList<T> collection = new List<T>();
        private readonly Dispatcher dispatcher;
        private readonly ReaderWriterLock sync = new ReaderWriterLock();

        /// <summary>
        /// Occurs when the collection changes.
        /// </summary>
        public event NotifyCollectionChangedEventHandler CollectionChanged;

        /// <summary>
        /// Initializes a new instance of the <see cref="SafeObservableCollection&lt;T&gt;"/> class.
        /// </summary>
        public SafeObservableCollection()
        {
            dispatcher = Application.Current.Dispatcher; 
        }

        /// <summary>
        /// Adds an item to the <see cref="T:System.Collections.Generic.ICollection`1"/>.
        /// </summary>
        /// <param name="item">The object to add to the <see cref="T:System.Collections.Generic.ICollection`1"/>.</param>
        /// <exception cref="T:System.NotSupportedException">
        /// The <see cref="T:System.Collections.Generic.ICollection`1"/> is read-only.
        ///   </exception>
        public void Add(T item)
        {
            if (Thread.CurrentThread == dispatcher.Thread)
                DoAdd(item);
            else
                dispatcher.BeginInvoke((Action)(() => DoAdd(item)));
        }

        /// <summary>
        /// Does the add.
        /// </summary>
        /// <param name="item">The item.</param>
        private void DoAdd(T item)
        {
            sync.AcquireWriterLock(Timeout.Infinite);
            collection.Add(item);
            if (CollectionChanged != null)
                CollectionChanged(this,
                    new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, item));
            sync.ReleaseWriterLock();
        }

        /// <summary>
        /// Removes all items from the <see cref="T:System.Collections.Generic.ICollection`1"/>.
        /// </summary>
        /// <exception cref="T:System.NotSupportedException">
        /// The <see cref="T:System.Collections.Generic.ICollection`1"/> is read-only.
        ///   </exception>
        public void Clear()
        {
            if (Thread.CurrentThread == dispatcher.Thread)
                DoClear();
            else
                dispatcher.BeginInvoke((Action)(DoClear));
        }

        /// <summary>
        /// Does the clear.
        /// </summary>
        private void DoClear()
        {
            sync.AcquireWriterLock(Timeout.Infinite);
            collection.Clear();
            if (CollectionChanged != null)
                CollectionChanged(this,
                    new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
            sync.ReleaseWriterLock();
        }

        /// <summary>
        /// Determines whether the <see cref="T:System.Collections.Generic.ICollection`1"/> contains a specific value.
        /// </summary>
        /// <param name="item">The object to locate in the <see cref="T:System.Collections.Generic.ICollection`1"/>.</param>
        /// <returns>
        /// true if <paramref name="item"/> is found in the <see cref="T:System.Collections.Generic.ICollection`1"/>; otherwise, false.
        /// </returns>
        public bool Contains(T item)
        {
            sync.AcquireReaderLock(Timeout.Infinite);
            var result = collection.Contains(item);
            sync.ReleaseReaderLock();
            return result;
        }

        /// <summary>
        /// Copies to.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <param name="arrayIndex">Index of the array.</param>
        public void CopyTo(T[] array, int arrayIndex)
        {
            sync.AcquireWriterLock(Timeout.Infinite);
            collection.CopyTo(array, arrayIndex);
            sync.ReleaseWriterLock();
        }

        /// <summary>
        /// Gets the number of elements contained in the <see cref="T:System.Collections.Generic.ICollection`1"/>.
        /// </summary>
        /// <returns>
        /// The number of elements contained in the <see cref="T:System.Collections.Generic.ICollection`1"/>.
        ///   </returns>
        public int Count
        {
            get
            {
                sync.AcquireReaderLock(Timeout.Infinite);
                var result = collection.Count;
                sync.ReleaseReaderLock();
                return result;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the <see cref="T:System.Collections.Generic.ICollection`1"/> is read-only.
        /// </summary>
        /// <returns>true if the <see cref="T:System.Collections.Generic.ICollection`1"/> is read-only; otherwise, false.
        ///   </returns>
        public bool IsReadOnly
        {
            get { return collection.IsReadOnly; }
        }

        /// <summary>
        /// Removes the first occurrence of a specific object from the <see cref="T:System.Collections.Generic.ICollection`1"/>.
        /// </summary>
        /// <param name="item">The object to remove from the <see cref="T:System.Collections.Generic.ICollection`1"/>.</param>
        /// <returns>
        /// true if <paramref name="item"/> was successfully removed from the <see cref="T:System.Collections.Generic.ICollection`1"/>; otherwise, false. This method also returns false if <paramref name="item"/> is not found in the original <see cref="T:System.Collections.Generic.ICollection`1"/>.
        /// </returns>
        /// <exception cref="T:System.NotSupportedException">
        /// The <see cref="T:System.Collections.Generic.ICollection`1"/> is read-only.
        ///   </exception>
        public bool Remove(T item)
        {
            if (Thread.CurrentThread == dispatcher.Thread)
                return DoRemove(item);

            var op = dispatcher.BeginInvoke(new Func<T, bool>(DoRemove), item);
            if (op.Result == null)
                return false;
            return (bool)op.Result;
        }

        /// <summary>
        /// Does the remove.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        private bool DoRemove(T item)
        {
            sync.AcquireWriterLock(Timeout.Infinite);
            var index = collection.IndexOf(item);
            if (index == -1)
            {
                sync.ReleaseWriterLock();
                return false;
            }
            var result = collection.Remove(item);
            if (result && CollectionChanged != null)
                CollectionChanged(this, new
                    NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
            sync.ReleaseWriterLock();
            return result;
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Collections.Generic.IEnumerator`1"/> that can be used to iterate through the collection.
        /// </returns>
        public IEnumerator<T> GetEnumerator()
        {
            return collection.GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Collections.IEnumerator"/> object that can be used to iterate through the collection.
        /// </returns>
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return collection.GetEnumerator();
        }

        /// <summary>
        /// Determines the index of a specific item in the <see cref="T:System.Collections.Generic.IList`1"/>.
        /// </summary>
        /// <param name="item">The object to locate in the <see cref="T:System.Collections.Generic.IList`1"/>.</param>
        /// <returns>
        /// The index of <paramref name="item"/> if found in the list; otherwise, -1.
        /// </returns>
        public int IndexOf(T item)
        {
            sync.AcquireReaderLock(Timeout.Infinite);
            var result = collection.IndexOf(item);
            sync.ReleaseReaderLock();
            return result;
        }

        /// <summary>
        /// Inserts an item to the <see cref="T:System.Collections.Generic.IList`1"/> at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index at which <paramref name="item"/> should be inserted.</param>
        /// <param name="item">The object to insert into the <see cref="T:System.Collections.Generic.IList`1"/>.</param>
        /// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="index"/> is not a valid index in the <see cref="T:System.Collections.Generic.IList`1"/>.
        ///   </exception>
        ///   
        /// <exception cref="T:System.NotSupportedException">
        /// The <see cref="T:System.Collections.Generic.IList`1"/> is read-only.
        ///   </exception>
        public void Insert(int index, T item)
        {
            if (Thread.CurrentThread == dispatcher.Thread)
                DoInsert(index, item);
            else
                dispatcher.BeginInvoke((Action)(() => DoInsert(index, item)));
        }

        /// <summary>
        /// Does the insert.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="item">The item.</param>
        private void DoInsert(int index, T item)
        {
            sync.AcquireWriterLock(Timeout.Infinite);
            collection.Insert(index, item);
            if (CollectionChanged != null)
                CollectionChanged(this,
                    new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, item, index));
            sync.ReleaseWriterLock();
        }

        /// <summary>
        /// Removes the <see cref="T:System.Collections.Generic.IList`1"/> item at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index of the item to remove.</param>
        /// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="index"/> is not a valid index in the <see cref="T:System.Collections.Generic.IList`1"/>.
        ///   </exception>
        ///   
        /// <exception cref="T:System.NotSupportedException">
        /// The <see cref="T:System.Collections.Generic.IList`1"/> is read-only.
        ///   </exception>
        public void RemoveAt(int index)
        {
            if (Thread.CurrentThread == dispatcher.Thread)
                DoRemoveAt(index);
            else
                dispatcher.BeginInvoke((Action)(() => DoRemoveAt(index)));
        }

        /// <summary>
        /// Does the remove at.
        /// </summary>
        /// <param name="index">The index.</param>
        private void DoRemoveAt(int index)
        {
            sync.AcquireWriterLock(Timeout.Infinite);
            if (collection.Count == 0 || collection.Count <= index)
            {
                sync.ReleaseWriterLock();
                return;
            }
            collection.RemoveAt(index);
            if (CollectionChanged != null)
                CollectionChanged(this,
                    new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
            sync.ReleaseWriterLock();

        }

        /// <summary>
        /// Gets or sets the element at the specified index.
        /// </summary>
        /// <returns>
        /// The element at the specified index.
        ///   </returns>
        ///   
        /// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="index"/> is not a valid index in the <see cref="T:System.Collections.Generic.IList`1"/>.
        ///   </exception>
        ///   
        /// <exception cref="T:System.NotSupportedException">
        /// The property is set and the <see cref="T:System.Collections.Generic.IList`1"/> is read-only.
        ///   </exception>
        public T this[int index]
        {
            get
            {
                sync.AcquireReaderLock(Timeout.Infinite);
                var result = collection[index];
                sync.ReleaseReaderLock();
                return result;
            }
            set
            {
                sync.AcquireWriterLock(Timeout.Infinite);
                if (collection.Count == 0 || collection.Count <= index)
                {
                    sync.ReleaseWriterLock();
                    return;
                }
                collection[index] = value;
                sync.ReleaseWriterLock();
            }

        }
    }
}
