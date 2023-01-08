# Secure Local Storage

![alt text](https://github.com/dotnetsafer/SecureLocalStorage/blob/master/Blobs/SecureLocalSmall.png?raw=true)

Secure Local Storage is a simple package for .NET that allows you to safely store information locally, allowing you to select whether the information will only be decryptable on the computer where it was created, or if it can be shared between several computers.

Mainly it offers you the option of storing information or sensitive settings and obtaining it from the same or another application.

## Installation

Use the nuget package manager to install [SecureLocalStorage.](https://www.nuget.org/packages/SecureLocalStorage/)

_Package Manager:_
```csharp
Install-Package SecureLocalStorage -Version 2.0.0
```
_.NET CLI:_
```csharp
dotnet add package SecureLocalStorage --version 2.0.0
```


**Caveat:**

Version 1 does not support MacOs and Linux, so please upgrade to version 2 if you are encrypting local data in a cross-platform project.

Since version 2, both Mac and Linux and Windows have the ability to store fully encrypted local files and data on the machine where your software runs.

## Simple Usage


### Instantiate the class with the default settings:

```csharp
var config = new DefaultLocalStorageConfig();
var storage = new SecureLocalStorage.SecureLocalStorage(config);
```
### Add data to storage:
```csharp
storage.Set("Example", "Hello world.");
//If key exists content will replaced.
```
### Add custom data to storage:
```csharp
var userExample = new UserExample {Name = "Juan", Verified = true};
storage.Set("User", userExample);
```
### Get data from storage:
```csharp
string data = storage.Get("Example"); //Hello world
```
### Get custom data from storage:
```csharp
var data = storage.Get<UserExample>("User"); //{Name = "Juan", Verified = true}
```
### Remove data from storage:
```csharp
storage.Remove("User");
```
### Check if data exists on storage
```csharp
var exists = storage.Exists("User");
```

## Advanced Usage

By default, the information is encrypted with the values of the machine that runs the application and it is only possible to manipulate the data in the same environment, that is, information stored between devices cannot be stolen.

Optionally you can configure where that information is stored and how it is encrypted.

### Custom configuration

The information is stored by default in `Environment.SpecialFolder.ApplicationData`.

and its hierarchy is as follows:

`%SpecialFolder% / Your_App_Name / default.`

#### Change default app name:

```csharp
config = new CustomLocalStorageConfig(null, "DotnetsaferTesting").WithDefaultKeyBuilder();
```
Make sure the name is unique to your application, or it could create conflicts with other applications.

#### Change default path:

```csharp
config = new CustomLocalStorageConfig(@"current/default", "DotnetsaferTesting").WithDefaultKeyBuilder();
```

#### Change default encryption key:

If you don't want the encryption key to be unique values of the device, you can set one yourself.
```csharp
config = new CustomLocalStorageConfig(@"current/default", "DotnetsaferTesting", "secret1234");
```
**If you want to add a dynamic key you can override the `BuildLocalSecureKey` method:**

```csharp
config.BuildLocalSecureKey = () => Guid.NewGuid().ToString();
```

## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

Please make sure to update tests as appropriate.
