using CustomDataStructures.Library;
using NUnit.Framework;
using System;
using System.Linq;

namespace CustomLinkedList.Tests
{
    [TestFixture]
    public class CustomLinkedListTests
    {
        private CustomLinkedList<int> _list;

        [SetUp]
        public void SetUp()
        {
            _list = new CustomLinkedList<int>();
        }

        [Test]
        public void IndexerTest()
        {
            var data = 1;
            var data2 = 2;
            var data3 = 3;
            var data4 = 4;
            var data5 = 5;
            var data6 = 6;

            _list.AddLast(data);
            _list.AddLast(data2);
            _list.AddLast(data3);
            _list.AddLast(data4);
            _list.AddLast(data5);
            _list.AddLast(data6);

            var result = 0;
            for (int i = 0; i < _list.Count; i++)
            {
                result += _list[i];
            }
            Assert.AreEqual(_list.Sum(), result);

            _list[0] = _list[0] - 1;
            Assert.AreEqual(_list.First(), _list[0]);

        }

        [Test]
        public void CountTest()
        {
            Assert.AreEqual(0, _list.Count);

            var data = 5;
            _list.AddLast(data);
            Assert.AreEqual(1, _list.Count);
        }

        [Test]
        public void IsEmptyTest()
        {
            Assert.AreEqual(true, _list.IsEmpty);
            Assert.AreEqual(0, _list.Count);

            var data = 5;
            _list.AddLast(data);
            Assert.AreEqual(false, _list.IsEmpty);
        }

        [Test]
        public void AddTest()
        {
            var data = 8;

            _list.AddLast(data);
            Assert.AreEqual(data, _list.First());
            Assert.AreEqual(1, _list.Count);
        }

        [Test]
        public void AddFirstTest()
        {

            var data = 1;
            var testValue = 3;

            _list.AddLast(testValue);

            _list.AddFirst(data);
            Assert.AreEqual(data, _list.First());
            Assert.AreEqual(testValue, _list.Last());
            Assert.AreEqual(2, _list.Count);
        }

        [Test]
        public void AddAfterTest()
        {
            var data = 1;
            var data2 = 2;
            var data3 = 3;
            var testValue = 7;
   
            _list.AddLast(data);
            _list.AddLast(data2);
            _list.AddLast(data3);

            _list.AddAfter(data2, testValue);
            Assert.AreEqual(data2, _list[1]);
            Assert.AreEqual(testValue, _list[2]);
            Assert.AreEqual(data3, _list[3]);
            Assert.AreEqual(4, _list.Count);

            var nonExistentValue = 11;
            try
            {
                _list.AddAfter(nonExistentValue, testValue);
                Assert.Fail();
            }
            catch(Exception)
            {

            }
        }

        [Test]
        public void RemoveTest()
        {
            var data = 1;
            var data2 = 2;
            var data3 = 3;
            var testValue = 6;

            _list.AddLast(data);
            _list.AddLast(data2);
            _list.AddLast(data3);
            _list.AddLast(testValue);

            var deletedData = _list.Remove(data);
            Assert.AreEqual(true, deletedData);
            Assert.AreEqual(data2, _list.First());
            Assert.AreEqual(3, _list.Count);

            var deletedData2 = _list.Remove(testValue);
            Assert.AreEqual(true, deletedData2);
            Assert.AreEqual(data3, _list.Last());
            Assert.AreEqual(2, _list.Count);

            var nonExistentValue = 12;
            Assert.AreEqual(false, _list.Remove(nonExistentValue));
            Assert.AreEqual(2, _list.Count);

        }

        [Test]
        public void ClearTest()
        {
            var data = 1;
            var data2 = 2;

            _list.AddLast(data);
            _list.AddLast(data2);

            _list.Clear();
            Assert.AreEqual(0, _list.Count);
        }

        [Test]
        public void ContainsTest()
        {
            var data = 1;
            var data2 = 2;
            var testValue = 5;

            _list.AddLast(data);
            _list.AddLast(data2);
            _list.AddLast(testValue);

            Assert.AreEqual(true, _list.Contains(testValue));

            var nonExistentValue = 17;
            Assert.AreEqual(false, _list.Contains(nonExistentValue));
        }

        [Test]
        public void IndexOfTest()
        {
            var data = 2;
            var data2 = 3;

            _list.AddLast(data);
            _list.AddLast(data2);

            Assert.AreEqual(0, _list.IndexOf(data));
            Assert.AreEqual(1, _list.IndexOf(data2));
            Assert.AreEqual(2, _list.Count);

            var testValue = 5;
            _list.AddFirst(testValue);
            Assert.AreEqual(0, _list.IndexOf(testValue));
            Assert.AreEqual(1, _list.IndexOf(data));
            Assert.AreEqual(2, _list.IndexOf(data2));

            var nonExistentValue = 10;
            Assert.AreEqual(-1, _list.IndexOf(nonExistentValue));
        }

        [Test]
        public void IEnumerableTest()
        {
            var data = 1;
            var data2 = 2;
            var data3 = 3;
            var data4 = 4;
            var data5 = 5;
            var data6 = 6;
            var data7 = 7;

            _list.AddLast(data);
            _list.AddLast(data2);
            _list.AddLast(data3);
            _list.AddLast(data4);
            _list.AddLast(data5);
            _list.AddLast(data6);
            _list.AddLast(data7);

            var index = 0;
            foreach (var item in _list)
            {
                Assert.AreEqual(_list[index], item);
                index++;
            }
        }
    }
}