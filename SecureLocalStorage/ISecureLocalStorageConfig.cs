using System;
using System.Collections.Generic;
using System.Text;

namespace SecureLocalStorage
{
    public interface ISecureLocalStorageConfig
    {
        string DefaultPath { get; }
        string ApplicationName { get; }
        string StoragePath { get; }
        Func<string> BuildLocalSecureKey { get; set;  }
    }
}
