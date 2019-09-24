using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puzzle
{
    class PriorityQueue<TPriority, TItem>
    {
        readonly SortedDictionary<TPriority, Queue<TItem>> _subqueues;
        public PriorityQueue(IComparer<TPriority> priorityComparer)
        {
            _subqueues = new SortedDictionary<TPriority, Queue<TItem>>(priorityComparer);
        }

        public PriorityQueue() : this(Comparer<TPriority>.Default) { }

        public bool HasItems
        {
            get { return _subqueues.Any(); }
        }

        public int Count
        {
            get { return _subqueues.Sum(q => q.Value.Count); }
        }

        private void AddQueueOfPriority(TPriority priority)
        {
            _subqueues.Add(priority, new Queue<TItem>());
        }

        public void Enqueue(TPriority priority, TItem item)
        {
            if (!_subqueues.ContainsKey(priority))
            {
                AddQueueOfPriority(priority);
            }

            _subqueues[priority].Enqueue(item);
        }

        private TItem DequeueFromHighPriorityQueue()
        {
            KeyValuePair<TPriority, Queue<TItem>> first = _subqueues.First();
            TItem nextItem = first.Value.Dequeue();
            if (!first.Value.Any())
            {
                _subqueues.Remove(first.Key);
            }
            return nextItem;
        }

        public TItem Dequeue()
        {
            if (_subqueues.Any())
                return DequeueFromHighPriorityQueue();
            else
                throw new InvalidOperationException("The queue is empty");
        }

        public TItem Peek()
        {
            if (HasItems)
                return _subqueues.First().Value.Peek();
            else
                throw new InvalidOperationException("The queue is empty");
        }

        public void Clear()
        {
            _subqueues.Clear();
        }
    }
}
