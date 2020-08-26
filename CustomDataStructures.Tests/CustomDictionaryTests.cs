using CustomDataStructures.Library;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace CustomDictionary.Tests
{
    public class CustomDictionaryTests
    {
        private CustomDictionary<int, string> _dictionary;

        [SetUp]
        public void Setup()
        {
            _dictionary = new CustomDictionary<int, string>();
        }

        [Test]
        public void CountTest()
        {
            Assert.AreEqual(0, _dictionary.Count);

            _dictionary.Add(1, "test");
            Assert.AreEqual(1, _dictionary.Count);
        }

        [Test]
        public void IsEmptyTest()
        {
            Assert.AreEqual(true, _dictionary.IsEmpty);
            Assert.AreEqual(0, _dictionary.Count);

            _dictionary.Add(1, "test");
            Assert.AreEqual(false, _dictionary.IsEmpty);
        }

        [Test]
        public void AddTest()
        {
            _dictionary.Add(1, "test");
            Assert.AreEqual("test", _dictionary.First());
            Assert.AreEqual(1, _dictionary.Count);

            try
            {
                _dictionary.Add(1, "test2");
                Assert.Fail();
            }
            catch
            {

            }
        }

        [Test]
        public void RemoveTest()
        {
            _dictionary.Add(1, "test");
            _dictionary.Add(2, "test2");
            _dictionary.Add(3, "test3");
            _dictionary.Add(4, "test4");

            var deletedData = _dictionary.Remove(1);
            Assert.AreEqual(true, deletedData);
            Assert.AreEqual("test2", _dictionary.First());
            Assert.AreEqual(3, _dictionary.Count);

            var deletedData2 = _dictionary.Remove(4);
            Assert.AreEqual(true, deletedData2);
            Assert.AreEqual("test3", _dictionary.Last());
            Assert.AreEqual(2, _dictionary.Count);

            var nonExistentKey = 10;
            Assert.AreEqual(false, _dictionary.Remove(nonExistentKey));
            Assert.AreEqual(2, _dictionary.Count);
        }

        [Test]
        public void ContainsTest()
        {
            _dictionary.Add(1, "test");
            _dictionary.Add(2, "test2");
            _dictionary.Add(3, "test3");

            Assert.AreEqual(true, _dictionary.Contains(1));

            var nonExistentKey = 17;
            Assert.AreEqual(false, _dictionary.Contains(nonExistentKey));
        }

        [Test]
        public void ClearTest()
        {
            _dictionary.Add(1, "test");
            _dictionary.Add(2, "test2");

            _dictionary.Clear();
            Assert.AreEqual(0, _dictionary.Count);
        }

        [Test]
        public void IEnumerableTest()
        {
            _dictionary.Add(1, "test");
            _dictionary.Add(2, "test2");
            _dictionary.Add(3, "test3");
            _dictionary.Add(4, "test4");
            _dictionary.Add(5, "test5");
            _dictionary.Add(6, "test6");
            _dictionary.Add(7, "test7");

            var index = 0;
            var testList = new List<string>();
            foreach (var testItem in _dictionary)
            {
                testList.Add(testItem);
                Assert.AreEqual(testList[index], testItem);
                index++;
            }

            Assert.AreEqual(testList.First(), "test");
            Assert.AreEqual(testList.Last(), "test7");
        }
    }
}