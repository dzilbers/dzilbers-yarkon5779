using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chains;

/// <summary>
/// Allows using FIFO queues. This generic class is implemented using a chain
/// and holds references to the first and to the last node in the chain.
/// </summary>
namespace Queue
{
    public class QueueArray<T>
    {
        private const int BLOCK = 10;
        private int capacity;
        private T[] array;
        private int first;
        private int next;

        /// <summary>
        /// Initializes an empty FIFO queue instance
        /// </summary>
        public QueueArray()
        {
            array = new T[BLOCK];
            capacity = BLOCK;
            first = next = 0;
        }

        private int increment(int index)
        {
            return (index + 1) % capacity;
        }
        /// <summary>
        /// Checks whether the queue is empty or not.
        /// </summary>
        /// <returns>true if the queue is empty and false otherwise</returns>
        public bool IsEmpty()
        {
            return first == next;
        }

        /// <summary>
        /// Insert a value into the queue
        /// </summary>
        /// <param name="value">the inserted value</param>
        public void Insert(T value)
        {
            if (increment(next) == first)
            {   // Overflow - need to expand the array
                T[] temp = new T[capacity + BLOCK];
                if (next < first)
                {
                    int j = 0;
                    for (int i = first; i < capacity; ++i, ++j)
                        temp[j] = array[i];
                    for (int i = 0; i < next; ++i, ++j)
                        temp[j] = array[i];
                }
                else
                {
                    for (int i = first, j = 0; i < next; ++i, ++j)
                        temp[j] = array[i];
                }
                first = 0;
                next = capacity - 1;
                array = temp;
                capacity += BLOCK;
            }
            array[next] = value;
            next = increment(next);
        }

        /// <summary>
        /// Removes a value from the queue and returns it.
        /// </summary>
        /// <returns>the removed value</returns>
        public T Remove()
        {
            if (first == next) throw new InvalidOperationException("The queue is empty");
            T temp = array[first];
            first = increment(first);
            return temp;
        }

        /// <summary>
        /// Brings the value of the first element in the queue
        /// </summary>
        /// <returns>the first element value</returns>
        public T Head()
        {
            if (first == next) throw new InvalidOperationException("The queue is empty");
            return array[first];
        }

        /// <summary>
        /// Provides queue content description
        /// </summary>
        /// <returns>string with queue content</returns>
        public override string ToString()
        {
            String s = "<- ";
            if (next < first)
            {
                for (int i = first; i < capacity; ++i)
                    s += array[i] + " ";
                if (next < first)
                    for (int i = 0; i < next; ++i)
                        s += array[i] + " ";
            }
            else
            {
                for (int i = first; i < next; ++i)
                    s += array[i] + " ";
            }   
            s += "<-";
            return s;
        }
    }
}
