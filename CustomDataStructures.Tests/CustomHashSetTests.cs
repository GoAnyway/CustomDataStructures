using CustomDataStructures.Library;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace CustomHashSet.Tests
{
    [TestFixture]
    public class CustomHashSetTests
    {
        private CustomHashSet<int> _hashSet;

        [SetUp]
        public void Setup()
        {
            _hashSet = new CustomHashSet<int>();
        }

        [Test]
        public void CountTest()
        {
            Assert.AreEqual(0, _hashSet.Count);

            var data = 1;
            _hashSet.Add(data);
            Assert.AreEqual(1, _hashSet.Count);
        }

        [Test]
        public void IsEmptyTest()
        {
            Assert.AreEqual(true, _hashSet.IsEmpty);
            Assert.AreEqual(0, _hashSet.Count);

            var data = 5;
            _hashSet.Add(data);
            Assert.AreEqual(false, _hashSet.IsEmpty);
        }

        [Test]
        public void AddTest()
        {
            var data = 8;

            _hashSet.Add(data);
            Assert.AreEqual(data, _hashSet.First());
            Assert.AreEqual(1, _hashSet.Count);
        }

        [Test]
        public void RemoveTest()
        {
            var data = 1;
            var data2 = 2;
            var data3 = 3;
            var testValue = 6;

            _hashSet.Add(data);
            _hashSet.Add(data2);
            _hashSet.Add(data3);
            _hashSet.Add(testValue);

            var deletedData = _hashSet.Remove(data);
            Assert.AreEqual(true, deletedData);
            Assert.AreEqual(data2, _hashSet.First());
            Assert.AreEqual(3, _hashSet.Count);

            var deletedData2 = _hashSet.Remove(testValue);
            Assert.AreEqual(true, deletedData2);
            Assert.AreEqual(data3, _hashSet.Last());
            Assert.AreEqual(2, _hashSet.Count);

            var nonExistentValue = 12;
            Assert.AreEqual(false, _hashSet.Remove(nonExistentValue));
            Assert.AreEqual(2, _hashSet.Count);
        }

        [Test]
        public void ContainsTest()
        {
            var data = 1;
            var data2 = 2;
            var testValue = 5;

            _hashSet.Add(data);
            _hashSet.Add(data2);
            _hashSet.Add(testValue);

            Assert.AreEqual(true, _hashSet.Contains(testValue));

            var nonExistentValue = 17;
            Assert.AreEqual(false, _hashSet.Contains(nonExistentValue));
        }

        [Test]
        public void ClearTest()
        {
            var data = 1;
            var data2 = 2;

            _hashSet.Add(data);
            _hashSet.Add(data2);

            _hashSet.Clear();
            Assert.AreEqual(0, _hashSet.Count);
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

            _hashSet.Add(data);
            _hashSet.Add(data2);
            _hashSet.Add(data3);
            _hashSet.Add(data4);
            _hashSet.Add(data5);
            _hashSet.Add(data6);
            _hashSet.Add(data7);

            var index = 0;
            var testList = new List<int>();
            foreach (var testItem in _hashSet)
            {
                testList.Add(testItem);
                Assert.AreEqual(testList[index], testItem);
                index++;
            }

            Assert.AreEqual(testList.First(), data);
            Assert.AreEqual(testList.Last(), data7);
        }
    }
}