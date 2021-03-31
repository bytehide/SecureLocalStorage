using System;
using SecureLocalStorage;

namespace Simple.Example
{
    class Program
    {
        static void Main(string[] args)
        {

            #region For default configuration

            ISecureLocalStorageConfig config = new DefaultLocalStorageConfig();

            #endregion

            #region For custom configuration

            //Default key builder prevents switch data between different machines.

            /*
             * config = new CustomLocalStorageConfig(null, "DotnetsaferTesting").WithDefaultKeyBuilder();
             * config = new CustomLocalStorageConfig(null, "DotnetsaferTesting", "test1234");
             * config = new CustomLocalStorageConfig(@"current/default", "DotnetsaferTesting", "test1234");
             * config.BuildLocalSecureKey = () => Guid.NewGuid().ToString();
             */

            #endregion

            //Instance secure local storage
            var storage = new SecureLocalStorage.SecureLocalStorage(config);

            #region Simple String Example

            storage.Set("Example", "Hello world.");

            var example = storage.Get("Example");

            Console.WriteLine(example);

            storage.Remove("Example");

            #endregion

            #region Custom Class Example

            var userExample = new UserExample {Name = "Juan",Verified = true};

            storage.Set("User", userExample);

            if (storage.Exists("User"))
            {
                var user = storage.Get<UserExample>("User");
                Console.WriteLine(user.Name);
            }
            else Console.WriteLine("User not exists on storage.");

            #endregion

            Console.ReadKey();
        }
    }
}
