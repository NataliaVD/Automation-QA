using Collections;
using NUnit.Framework;
using System;

namespace Collection.Tests
{
    public class Tests
    {
       private Collection<int> collection;

        [SetUp]
        public void Setup()
        {
            collection = new Collection<int>();
        }

        [Test]
        public void TestCollectionWithEmptyConstructor()
        {
            collection = new Collection<int>();
                Assert.That(collection.ToString, Is.EqualTo("[]"));
        }

        [Test]
        public void TestConstructorWithSingleItem()
        {
            collection = new Collection<int>(1);
            Assert.That(collection.ToString, Is.EqualTo("[1]"));
        }

        [Test]
        public void TestConstructorWithMultipleItems()
        {
            collection = new Collection<int>(1, 2, 3, 4);
            Assert.AreEqual(collection.ToString(), "[1, 2, 3, 4]");
        }

        [Test]
        public void TestCollectionAdd()
        {
            collection.Add(1);
            Assert.That(collection.ToString, Is.EqualTo("[1]"));
        }

        [Test]
        public void TestCollectionAddWithGrow()
        {
            int oldCapacity = collection.Capacity;
            int[] newCollection = new int[]{ 1, 2, 3, 4, 5, 6 };
            collection.AddRange(newCollection);

            Assert.That(collection.ToString, Is.EqualTo("[1, 2, 3, 4, 5, 6]"));
            Assert.That(collection.Capacity, Is.GreaterThanOrEqualTo(oldCapacity));
            Assert.That(collection.Capacity, Is.GreaterThanOrEqualTo(collection.Count));
        }

        [Test]
        public void TestCollectionGetByIndex()
        {
            collection.Add(7);
            collection.Add(15);

            Assert.That(collection[0], Is.EqualTo(7));
            Assert.That(collection[1], Is.EqualTo(15));
        }
        [Test]
        public void TestCollectionGetByInvalidIndex()
        {
            collection.Add(7);
            collection.Add(15);

            Assert.That(()=> { int num = collection[-1]; }, Throws.InstanceOf<System.ArgumentOutOfRangeException>());

        }

        [Test]
        public void TestCollectionSetByInvalidIndex()
        {
        }

        [Test]
        public void TestCollectionSetByIndex()
        {
            collection = new Collection<int>(7, 5, 4, 6, 2);
            collection[1] = 3;
            collection[4] = 9;

            Assert.That(collection.ToString, Is.EqualTo("[7, 3, 4, 6, 9]"));
        }

        [Test]
        public void TestCollectionInsertAtStart()
        {
            collection.Add(1);
            collection.Add(2);
            collection.Add(3);
            collection.InsertAt(0, 0);

            Assert.That(collection.ToString(), Is.EqualTo("[0, 1, 2, 3]"));
        }

        [Test]
        public void TestCollectionInsertAtEnd()
        {
            collection.Add(1);
            collection.Add(2);
            collection.Add(3);
            collection.InsertAt(3, 4);

            Assert.That(collection.ToString(), Is.EqualTo("[1, 2, 3, 4]"));
        }

        [Test]
        public void TestCollectionInsertAtMiddle()
        {
            collection.Add(1);
            collection.Add(2);
            collection.Add(3);
            collection.InsertAt(1, 5);

            Assert.That(collection.ToString(), Is.EqualTo("[1, 5, 2, 3]"));
        }

        [Test]
        public void TestCollectionInsertWithGrow()
        {
            collection.AddRange(new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8});
            int oldCapacity = collection.Capacity;
            collection.InsertAt(0, 1);
            collection.InsertAt(1, 2);
            collection.InsertAt(2, 3);
            collection.InsertAt(3, 4);
            collection.InsertAt(4, 5);
            collection.InsertAt(5, 6);
            collection.InsertAt(6, 7);
            collection.InsertAt(7, 8);

            Assert.That(collection.ToString(), Is.EqualTo("[1, 2, 3, 4, 5, 6, 7, 8, 0, 1, 2, 3, 4, 5, 6, 7, 8]"));
            Assert.That(collection.Capacity, Is.GreaterThanOrEqualTo(oldCapacity));
            Assert.That(collection.Capacity, Is.GreaterThanOrEqualTo(collection.Count));
        }

        [Test]
        public void TestCollectionInsertAtInvalidIndex()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => collection[10] = 200);
        }

        [Test]
        public void TestExchangeMiddle()
        {
            collection.AddRange(1, 2, 3, 4, 5, 6, 7);
            collection.Exchange(3, 4);
            Assert.That(collection.ToString, Is.EqualTo("[1, 2, 3, 5, 4, 6, 7]"));
        }

        [Test]
        public void TestExchangeFirstLast()
        {
            collection.AddRange(1, 2, 3, 4, 5, 6, 7);
            collection.Exchange(0, 6);
            Assert.That(collection.ToString, Is.EqualTo("[7, 2, 3, 4, 5, 6, 1]"));
        }

        [Test]
        public void TestExchangeInvalidIndexes()
        {

        }

        [Test]
        public void TestRemoveAtStart()
        {
            collection.AddRange(1, 2, 3);
            collection.RemoveAt(0);
            Assert.That(collection[0], Is.EqualTo(2));
            Assert.That(collection.Count == 2);
        }

        [Test]
        public void TestRemoveAtEnd()
        {
            collection.AddRange(1, 2, 3);
            collection.RemoveAt(2);
            Assert.That(collection.ToString, Is.EqualTo("[1, 2]"));
            Assert.That(collection.Count == 2);
        }

        [Test]
        public void TestRemoveAtMiddle()
        {
            collection.AddRange(1, 2, 3);
            collection.RemoveAt(1);
            Assert.That(collection.ToString, Is.EqualTo("[1, 3]"));
        }

        [Test]
        public void TestRemoveAtInvalidIndex()
        {

        }

        [Test]
        public void TestRemoveAll()
        {
            collection.AddRange( 1, 2, 3 );
            collection.Clear();
            Assert.That( collection.ToString, Is.EqualTo("[]") );
        }
    }
}