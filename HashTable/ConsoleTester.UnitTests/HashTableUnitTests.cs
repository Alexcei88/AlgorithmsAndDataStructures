using NUnit.Framework;

namespace ConsoleTester.UnitTests
{
    [TestFixture]
    public class HashTableUnitTests
    {
        [Test]
        public void ContainsKey()
        {
            var hashtable = new HashTable<string, string>(4);
            FillTable(hashtable);
            Assert.AreEqual(22, hashtable.Size());
            
            Assert.IsTrue(hashtable.ContainsKey("Hendrix"));
            Assert.IsTrue(hashtable.ContainsKey("Lawson"));
            Assert.IsTrue(hashtable.ContainsKey("Mekhi"));
            Assert.IsTrue(hashtable.ContainsKey("Gerald"));
            Assert.IsFalse(hashtable.ContainsKey("Hendrix1"));
            Assert.IsFalse(hashtable.ContainsKey("Hendrix2"));
        }
        
        [Test]
        public void Contains()
        {
            var hashtable = new HashTable<string, string>(4);
            FillTable(hashtable);
            Assert.AreEqual(22, hashtable.Size());
            
            Assert.IsTrue(hashtable.Contains("Heath"));
            Assert.IsTrue(hashtable.Contains("Cristiano"));
            Assert.IsTrue(hashtable.Contains("Wade"));
            Assert.IsFalse(hashtable.Contains("Heath1"));
            Assert.IsFalse(hashtable.Contains("Heath2"));
        }
        
        [Test]
        public void Get()
        {
            var hashtable = new HashTable<string, string>(8);
            FillTable(hashtable);
            
            Assert.AreEqual("Cyrus", hashtable.Get("Hendrix"));
            Assert.AreEqual("Dillon", hashtable.Get("Lawson"));
            Assert.AreEqual("Makai", hashtable.Get("Mekhi"));
            Assert.AreEqual("Allan", hashtable.Get("Gerald"));
            Assert.AreNotEqual("Cyrus1", hashtable.Get("Hendrix"));
            Assert.AreNotEqual("Cyrus2", hashtable.Get("Hendrix2"));
        }
        
        [Test]
        public void Remove()
        {
            var hashtable = new HashTable<string, string>(8);
            FillTable(hashtable);

            Assert.AreEqual(22, hashtable.Size());
            
            Assert.IsTrue(hashtable.ContainsKey("Hendrix"));
            Assert.IsTrue(hashtable.ContainsKey("Lawson"));
            
            hashtable.Remove("Hendrix");
            hashtable.Remove("Lawson");
            Assert.AreEqual(20, hashtable.Size());
            Assert.IsFalse(hashtable.ContainsKey("Hendrix"));
            Assert.IsFalse(hashtable.ContainsKey("Lawson"));
            
            hashtable.Remove("Hendrix");
            Assert.AreEqual(20, hashtable.Size());
        }
        
        [Test]
        public void Clear()
        {
            var hashtable = new HashTable<string, string>(8);
            FillTable(hashtable);

            Assert.AreEqual(22, hashtable.Size());
            
            Assert.IsTrue(hashtable.ContainsKey("Hendrix"));
            Assert.IsTrue(hashtable.ContainsKey("Lawson"));
            
            hashtable.Clear();
            Assert.AreEqual(0, hashtable.Size());
            Assert.IsFalse(hashtable.ContainsKey("Hendrix"));
            Assert.IsFalse(hashtable.ContainsKey("Lawson"));
        }
        
        private void FillTable(HashTable<string, string> hashtable)
        {
            hashtable.Put("Brock", "Jamison");
            hashtable.Put("John", "Cyrus");
            hashtable.Put("Augustus", "Royal");
            hashtable.Put("Hendrix", "Cyrus");
            hashtable.Put("Lawson", "Dillon");
            hashtable.Put("Moses", "Wade");
            hashtable.Put("Aarav", "Asa");
            hashtable.Put("Marvin", "Ahmad");
            hashtable.Put("Ezequiel", "Emmitt");
            hashtable.Put("Aldo", "Abdullah");
            hashtable.Put("Samson", "Jaxen");
            hashtable.Put("Mekhi", "Makai");
            hashtable.Put("Sage", "Allan");
            hashtable.Put("Ezequiel", "Rohan");
            hashtable.Put("Zain", "Valentino");
            hashtable.Put("Layne", "Makai");
            hashtable.Put("Sonny", "Allan");
            hashtable.Put("Samir", "Rohan");
            hashtable.Put("Wayne", "Valentino");
            hashtable.Put("Gerald", "Allan");
            hashtable.Put("Leandro", "Heath");
            hashtable.Put("Fisher", "Cristiano");
        }
    }
}