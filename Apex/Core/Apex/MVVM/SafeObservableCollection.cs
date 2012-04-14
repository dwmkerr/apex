﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;
using System.Windows.Threading;
using System.Threading;
using System.Windows;

namespace Apex.MVVM
{
    public class SafeObservableCollection<T> : IList<T>, INotifyCollectionChanged
    {
        private IList<T> collection = new List<T>();
        private Dispatcher dispatcher;
        public event NotifyCollectionChangedEventHandler CollectionChanged;
        private ReaderWriterLock sync = new ReaderWriterLock();

        public SafeObservableCollection()
        {
            dispatcher = Application.Current.Dispatcher; 
        }

        public void Add(T item)
        {
            if (Thread.CurrentThread == dispatcher.Thread)
                DoAdd(item);
            else
                dispatcher.BeginInvoke((Action)(() => { DoAdd(item); }));
        }

        private void DoAdd(T item)
        {
            sync.AcquireWriterLock(Timeout.Infinite);
            collection.Add(item);
            if (CollectionChanged != null)
                CollectionChanged(this,
                    new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, item));
            sync.ReleaseWriterLock();
        }

        public void Clear()
        {
            if (Thread.CurrentThread == dispatcher.Thread)
                DoClear();
            else
                dispatcher.BeginInvoke((Action)(() => { DoClear(); }));
        }

        private void DoClear()
        {
            sync.AcquireWriterLock(Timeout.Infinite);
            collection.Clear();
            if (CollectionChanged != null)
                CollectionChanged(this,
                    new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
            sync.ReleaseWriterLock();
        }

        public bool Contains(T item)
        {
            sync.AcquireReaderLock(Timeout.Infinite);
            var result = collection.Contains(item);
            sync.ReleaseReaderLock();
            return result;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            sync.AcquireWriterLock(Timeout.Infinite);
            collection.CopyTo(array, arrayIndex);
            sync.ReleaseWriterLock();
        }

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

        public bool IsReadOnly
        {
            get { return collection.IsReadOnly; }
        }

        public bool Remove(T item)
        {
            if (Thread.CurrentThread == dispatcher.Thread)
                return DoRemove(item);
            else
            {
                var op = dispatcher.BeginInvoke(new Func<T, bool>(DoRemove), item);
                if (op == null || op.Result == null)
                    return false;
                return (bool)op.Result;
            }
        }

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

        public IEnumerator<T> GetEnumerator()
        {
            return collection.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return collection.GetEnumerator();
        }

        public int IndexOf(T item)
        {
            sync.AcquireReaderLock(Timeout.Infinite);
            var result = collection.IndexOf(item);
            sync.ReleaseReaderLock();
            return result;
        }

        public void Insert(int index, T item)
        {
            if (Thread.CurrentThread == dispatcher.Thread)
                DoInsert(index, item);
            else
                dispatcher.BeginInvoke((Action)(() => { DoInsert(index, item); }));
        }

        private void DoInsert(int index, T item)
        {
            sync.AcquireWriterLock(Timeout.Infinite);
            collection.Insert(index, item);
            if (CollectionChanged != null)
                CollectionChanged(this,
                    new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, item, index));
            sync.ReleaseWriterLock();
        }

        public void RemoveAt(int index)
        {
            if (Thread.CurrentThread == dispatcher.Thread)
                DoRemoveAt(index);
            else
                dispatcher.BeginInvoke((Action)(() => { DoRemoveAt(index); }));
        }

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
