using CustomDataStructures.Library;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomQueue.Tests
{
    public class CustomQueueTests
    {
        private CustomQueue<int> _queue;

        [SetUp]
        public void SetUp()
        {
            _queue = new CustomQueue<int>();
        }

        [Test]
        public void CountTest()
        {
            Assert.AreEqual(0, _queue.Count);

            var item = 5;
            _queue.Enqueue(item);
            Assert.AreEqual(1, _queue.Count);
        }

        [Test]
        public void IsEmptyTest()
        {
            Assert.AreEqual(true, _queue.IsEmpty);
            Assert.AreEqual(0, _queue.Count);

            var data = 5;
            _queue.Enqueue(data);
            Assert.AreEqual(false, _queue.IsEmpty);
        }

        [Test]
        public void ClearTest()
        {
            var item = 1;
            var item2 = 2;

            _queue.Enqueue(item);
            _queue.Enqueue(item2);

            _queue.Clear();
            Assert.AreEqual(0, _queue.Count);
        }

        [Test]
        public void EnqueueTest()
        {
            var item = 8;

            _queue.Enqueue(item);
            Assert.AreEqual(item, _queue.First());
            Assert.AreEqual(1, _queue.Count);
        }

        [Test]
        public void DequeueTest()
        {
            var item = 1;
            var item2 = 2;
            var item3 = 3;
            var testItem = 6;

            _queue.Enqueue(testItem);
            _queue.Enqueue(item);
            _queue.Enqueue(item2);
            _queue.Enqueue(item3);

            var deletedItem = _queue.Dequeue();
            Assert.AreEqual(testItem, deletedItem);
            Assert.AreEqual(item, _queue.First());
            Assert.AreEqual(3, _queue.Count);

            _queue.Clear();
            try
            {
                _queue.Dequeue();
                Assert.Fail();
            }
            catch (Exception)
            {

            }
        }

        [Test]
        public void PeekTest()
        {
            var item = 1;
            var item2 = 2;
            var item3 = 3;
            var testItem = 6;

            _queue.Enqueue(testItem);
            _queue.Enqueue(item);
            _queue.Enqueue(item2);
            _queue.Enqueue(item3);

            var pickedItem = _queue.Peek();
            Assert.AreEqual(testItem, pickedItem);
            Assert.AreEqual(testItem, _queue.First());
            Assert.AreEqual(4, _queue.Count);

            _queue.Clear();
            try
            {
                _queue.Peek();
                Assert.Fail();
            }
            catch (Exception)
            {

            }
        }

        [Test]
        public void ContainsTest()
        {
            var data = 1;
            var data2 = 2;
            var testValue = 5;

            _queue.Enqueue(data);
            _queue.Enqueue(data2);
            _queue.Enqueue(testValue);

            Assert.AreEqual(true, _queue.Contains(testValue));

            var nonExistentValue = 17;
            Assert.AreEqual(false, _queue.Contains(nonExistentValue));
        }

        [Test]
        public void IEnumerableTest()
        {
            var item = 1;
            var item2 = 2;
            var item3 = 3;
            var item4 = 4;
            var item5 = 5;
            var item6 = 6;
            var item7 = 7;

            _queue.Enqueue(item);
            _queue.Enqueue(item2);
            _queue.Enqueue(item3);
            _queue.Enqueue(item4);
            _queue.Enqueue(item5);
            _queue.Enqueue(item6);
            _queue.Enqueue(item7);

            var index = 0;
            var testList = new List<int>();
            foreach (var testItem in _queue)
            {
                testList.Add(testItem);
                Assert.AreEqual(testList[index], testItem);
                index++;
            }

            Assert.AreEqual(testList.First(), item);
            Assert.AreEqual(testList.Last(), item7);
        }
    }
}
