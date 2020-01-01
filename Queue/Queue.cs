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
    public class Queue<T>
    {
        private Node<T> first;
        private Node<T> last;

        /// <summary>
        /// Initializes an empty FIFO queue instance
        /// </summary>
        public Queue()
        {
            first = last = null;
        }

        /// <summary>
        /// Checks whether the queue is empty or not.
        /// </summary>
        /// <returns>true if the queue is empty and false otherwise</returns>
        public bool IsEmpty()
        {
            return first == null;
        }

        /// <summary>
        /// Insert a value into the queue
        /// </summary>
        /// <param name="value">the inserted value</param>
        public void Insert(T value)
        {
            Node<T> node = new Node<T>(value);
            if (first == null)
                first = node;
            else
                last.SetNext(node);
            last = node;
        }

        /// <summary>
        /// Removes a value from the queue and returns it.
        /// </summary>
        /// <returns>the removed value</returns>
        public T Remove()
        {
            T temp = first.GetValue();
            first = first.GetNext();
            if (first == null)
                last = null;
            return temp;
        }

        /// <summary>
        /// Brings the value of the first element in the queue
        /// </summary>
        /// <returns>the first element value</returns>
        public T Head()
        {
            return first.GetValue();
        }

        /// <summary>
        /// Provides queue content description
        /// </summary>
        /// <returns>string with queue content</returns>
        public override string ToString()
        {
            String s = "<- ";
            for (Node<T> node = first; node != null; node = node.GetNext())
                s += node.GetValue() + " ";
            s += "<-";
            return s;
        }
    }
}
