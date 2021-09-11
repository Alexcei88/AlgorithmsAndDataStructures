using System;
using ConsoleTester.Arrays;
using NUnit.Framework;

namespace DataStructures.UnitTest
{
    [TestFixture(typeof(SingleArray<int>))]
    [TestFixture(typeof(VectorArray<int>))]
    [TestFixture(typeof(FactorArray<int>))]
    [TestFixture(typeof(MatrixArray<int>))]
    [TestFixture(typeof(ListArray<int>))]
    public class ArrayTests
    {
        private readonly Type _arrayType;

        public ArrayTests(Type arrayType)
        {
            _arrayType = arrayType;
        }
        
        [Test]
        public void Add_Success()
        {
            var array = (IArray<int>)Activator.CreateInstance(_arrayType);
            array.Add(1);
            array.Add((2));
            array.Add(3);

            Assert.AreEqual("123", array.ToString());
        }
        
        [Test]
        public void Add_ToSpecificIndex_Success()
        {
            var array = (IArray<int>)Activator.CreateInstance(_arrayType);
            array.Add(1);
            array.Add((2));
            array.Add(3);

            Assert.AreEqual("123", array.ToString());
            
            array.Add(4, 2);
            Assert.AreEqual("1243", array.ToString());

            array.Add(5, 0);
            Assert.AreEqual("51243", array.ToString());

            array.Add(6, 5);
            Assert.AreEqual("512436", array.ToString());
        }
        
        [Test]
        public void AddToSpecificIndex_EmptyArray_Success()
        {
            var array = (IArray<int>)Activator.CreateInstance(_arrayType);
            array.Add(1, 0);
            Assert.AreEqual("1", array.ToString());
            
            array.Add(2, 0);
            Assert.AreEqual("21", array.ToString());

            array.Add(3, 0);
            Assert.AreEqual("321", array.ToString());
        }
        
        [Test]
        public void Get_Success()
        {
            var array = (IArray<int>)Activator.CreateInstance(_arrayType);
            array.Add(1);
            array.Add((2));
            array.Add(3);

            Assert.AreEqual(2, array.Get(1));
        }
        
        [Test]
        public void Remove_Success()
        {
            var array = (IArray<int>)Activator.CreateInstance(_arrayType);
            array.Add(1);
            array.Add((2));
            array.Add(3);
            array.Add(4);
            array.Add(5);
            array.Add(6);

            Assert.AreEqual("123456", array.ToString());

            int res = array.Remove(4);
            Assert.AreEqual(5, res);
            Assert.AreEqual("12346", array.ToString());
            
            res = array.Remove(0);
            Assert.AreEqual(1, res);
            Assert.AreEqual("2346", array.ToString());
            
            res = array.Remove(3);
            Assert.AreEqual(6, res);
            Assert.AreEqual("234", array.ToString());
        }
    }
}