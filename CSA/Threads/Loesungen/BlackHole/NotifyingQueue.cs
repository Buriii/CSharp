using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace BlackHole {

    class NotifyingQueue<T> {

        private const int SIZE = 10;
        private T[] queue = new T[SIZE];
        private int head = 0;
        private int tail = 0;
        private object locker = new object();

        public void enqueue(T item) {
            lock (locker) {
                head++;
                head %= SIZE;
                queue[head] = item;
                Monitor.Pulse(locker);
            }
        }

        public T dequeue() {
            lock (locker) {
                while (head == tail) {
                    Monitor.Wait(locker);
                }
                tail++;
                tail %= SIZE;
                return queue[tail];
            }
        }
    }
}
