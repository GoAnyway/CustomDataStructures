using CustomDataStructures.Library;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomStack.Tests
{
    public class CustomStackTests
    {
        private CustomStack<int> _stack;

        [SetUp]
        public void SetUp()
        {
            _stack = new CustomStack<int>();
        }

        [Test]
        public void CountTest()
        {
            Assert.AreEqual(0, _stack.Count);

            var item = 5;
            _stack.Push(item);
            Assert.AreEqual(1, _stack.Count);
        }

        [Test]
        public void IsEmptyTest()
        {
            Assert.AreEqual(true, _stack.IsEmpty);
            Assert.AreEqual(0, _stack.Count);

            var data = 5;
            _stack.Push(data);
            Assert.AreEqual(false, _stack.IsEmpty);
        }

        [Test]
        public void ClearTest()
        {
            var item = 1;
            var item2 = 2;

            _stack.Push(item);
            _stack.Push(item2);

            _stack.Clear();
            Assert.AreEqual(0, _stack.Count);
        }

        [Test]
        public void PushTest()
        {
            var item = 8;

            _stack.Push(item);
            Assert.AreEqual(item, _stack.First());
            Assert.AreEqual(1, _stack.Count);
        }

        [Test]
        public void PopTest()
        {
            var item = 1;
            var item2 = 2;
            var item3 = 3;
            var testItem = 6;

            _stack.Push(item);
            _stack.Push(item2);
            _stack.Push(item3);
            _stack.Push(testItem);

            var deletedItem = _stack.Pop();
            Assert.AreEqual(testItem, deletedItem);
            Assert.AreEqual(item3, _stack.First());
            Assert.AreEqual(3, _stack.Count);

            _stack.Clear();
            try
            {
                _stack.Pop();
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

            _stack.Push(item);
            _stack.Push(item2);
            _stack.Push(item3);
            _stack.Push(testItem);

            var pickedItem = _stack.Peek();
            Assert.AreEqual(testItem, pickedItem);
            Assert.AreEqual(testItem, _stack.First());
            Assert.AreEqual(4, _stack.Count);

            _stack.Clear();
            try
            {
                _stack.Peek();
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

            _stack.Push(data);
            _stack.Push(data2);
            _stack.Push(testValue);

            Assert.AreEqual(true, _stack.Contains(testValue));

            var nonExistentValue = 17;
            Assert.AreEqual(false, _stack.Contains(nonExistentValue));
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

            _stack.Push(item);
            _stack.Push(item2);
            _stack.Push(item3);
            _stack.Push(item4);
            _stack.Push(item5);
            _stack.Push(item6);
            _stack.Push(item7);

            var index = 0;
            var testList = new List<int>();
            foreach (var testItem in _stack)
            {
                testList.Add(testItem);
                Assert.AreEqual(testList[index], testItem);
                index++;
            }

            Assert.AreEqual(testList.First(), item7);
            Assert.AreEqual(testList.Last(), item);
        }
    }
}
