using ConsoleTester.Queue;
using NUnit.Framework;

namespace DataStructures.UnitTest
{
    [TestFixture]
    public class PriorityTests
    {
        [Test]
        public void EnqueueAndDequeue_TheSamePriority_Success()
        {
            var queue = new PriorityQueue<int>();
            queue.Enqueue(1, 1);
            queue.Enqueue(1, 2);
            queue.Enqueue(1, 3);

            Assert.AreEqual(1, queue.Dequeue());
            Assert.AreEqual(2, queue.Dequeue());
            Assert.AreEqual(3, queue.Dequeue());
            Assert.AreEqual(default(int), queue.Dequeue());
        }
        
        [Test]
        public void EnqueueAndDequeue_DiffPriority_Success()
        {
            var queue = new PriorityQueue<int>();
            queue.Enqueue(1, 1);
            queue.Enqueue(2, 2);
            queue.Enqueue(1, 3);

            Assert.AreEqual(2, queue.Dequeue());
            Assert.AreEqual(1, queue.Dequeue());
            Assert.AreEqual(3, queue.Dequeue());
            Assert.AreEqual(default(int), queue.Dequeue());
        }

    }
}