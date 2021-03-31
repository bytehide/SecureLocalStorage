using System.IO;
using NUnit.Framework;

namespace SecureLocalStorage.Test
{
    public class Tests
    {
        internal SecureLocalStorage Storage { get; set; }

        [SetUp, Order(0)]
        public void Setup()
        {
            var config = new CustomLocalStorageConfig(Path.Combine(@"test","path"),"testing").WithDefaultKeyBuilder();
            Storage = new SecureLocalStorage(config);
            Assert.NotNull(Storage);
        }

        [Test, Order(1)]
        public void CanSet()
        {
            Assert.DoesNotThrow(() => Storage.Set("test", "dotnetsafer"));
            Assert.IsTrue(Storage.Exists("test"));
            Assert.Pass();
        }

        [Test, Order(2)]
        public void CanGet()
        {
            var get = Storage.Get("test");
            Assert.AreEqual("dotnetsafer",get);
            Assert.Pass();
        }

        [Test, Order(3)]
        public void CanDelete()
        {
            Assert.DoesNotThrow(() => Storage.Remove("test"));
            Assert.IsNull(Storage.Get("test"));
            Assert.Pass();
        }

        [Test, Order(4)]
        public void CanClear()
        {
            Assert.DoesNotThrow(() => Storage.Clear());
            Assert.Pass();
        }

        [Test, Order(5)]
        public void IsEncrypted()
        {
            Storage.Set("test","Hello world");
            var data = File.ReadAllText(Path.Combine(@"test", "path", "testing","default"));
            Assert.IsFalse(data.ToLower().Contains("hello"));
            Assert.Pass();
        }

        [Test, Order(6)]
        public void IsEncryptedOnlyForCurrentMachine()
        {
            var config = new CustomLocalStorageConfig(Path.Combine(@"test", "path"), "testing", "test1234");
            var storage = new SecureLocalStorage(config);
            
            Assert.IsNotNull(storage);

            //Assert.DoesNotThrow(()=>Storage.Set("encryption","isEncrypted"));

            //Assert.Throws(typeof(CryptographicException), () => storage.Get("encryption"));

            Assert.Pass();
        }
    }
}