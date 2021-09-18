using ConsoleTester.Trees;
using NUnit.Framework;

namespace ConsoleTester.UnitTests
{
    public class BTreeUnitTests
    {
        const int Degree = 2;
        
        [Test]
        public void ManyInsert_RandomNumber_Success()
        {
            var tree = new BTree(Degree);
            
            tree.Insert(4);
            tree.Insert(5);
            tree.Insert(6);
            
            tree.Insert(7);
            tree.Insert(3);
            tree.Insert(1);
            tree.Insert(8);

            tree.Insert(2);

            tree.Insert(11);
            tree.Insert(12);
            tree.Insert(18);
            tree.Insert(17);
            tree.Insert(15);
            tree.Insert(14);
            
            Assert.AreEqual("1 2 3 4 5 6 7 8 11 12 14 15 17 18", tree.ToString());
        }
        
        [Test]
        public void Search_AnyNumber_Success()
        {
            var tree = new BTree(Degree);
            
            tree.Insert(4);
            tree.Insert(5);
            tree.Insert(6);
            
            tree.Insert(7);
            tree.Insert(3);
            tree.Insert(1);

            tree.Insert(2);

            tree.Insert(11);
            tree.Insert(12);
            tree.Insert(18);
            tree.Insert(17);
            tree.Insert(15);
            tree.Insert(14);
            
            Assert.AreEqual(tree.Search(4), true);
            Assert.AreEqual(tree.Search(1), true);
            Assert.AreEqual(tree.Search(7), true);
            Assert.AreEqual(tree.Search(18), true);
            Assert.AreEqual(tree.Search(12), true);

            Assert.AreEqual(tree.Search(0), false);
            Assert.AreEqual(tree.Search(8), false);

        }
        
        [Test]
        public void Remove_AnyNumber_Success()
        {
            var tree = new BTree(Degree);
            
            tree.Insert(4);
            tree.Insert(5);
            tree.Insert(6);
            tree.Insert(7);
            tree.Insert(3);
            tree.Insert(1);
            tree.Insert(10);
            tree.Insert(11);
            tree.Insert(8);
            tree.Insert(9);
            tree.Insert(2);
            tree.Insert(15);
            tree.Insert(12);
            tree.Insert(13);
            tree.Insert(16);

            Assert.AreEqual("1 2 3 4 5 6 7 8 9 10 11 12 13 15 16", tree.ToString());

            tree.Remove(11);
            Assert.AreEqual("1 2 3 4 5 6 7 8 9 10 12 13 15 16", tree.ToString());
            
            tree.Remove(4);
            Assert.AreEqual("1 2 3 5 6 7 8 9 10 12 13 15 16", tree.ToString());
            
            tree.Remove(9);
            Assert.AreEqual("1 2 3 5 6 7 8 10 12 13 15 16", tree.ToString());

            tree.Remove(2);
            Assert.AreEqual("1 3 5 6 7 8 10 12 13 15 16", tree.ToString());

            tree.Remove(6);
            Assert.AreEqual("1 3 5 7 8 10 12 13 15 16", tree.ToString());
            
            tree.Remove(1);
            Assert.AreEqual("3 5 7 8 10 12 13 15 16", tree.ToString());
            
            tree.Remove(100);
            Assert.AreEqual("3 5 7 8 10 12 13 15 16", tree.ToString());

            tree.Remove(8);
            Assert.AreEqual("3 5 7 10 12 13 15 16", tree.ToString());
            
            tree.Remove(10);
            Assert.AreEqual("3 5 7 12 13 15 16", tree.ToString());
        }
    }
}