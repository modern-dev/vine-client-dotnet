<h1 align="center"><img width="200" src="media/logo.png" alt="InTouch logo" style="clear: right;"><br/><br/></h1>

[![Build status](https://ci.appveyor.com/api/projects/status/kwhrau8wsj59hy99?svg=true)](https://ci.appveyor.com/project/virtyaluk/vine-client-dotnet) [![NuGet](https://img.shields.io/nuget/v/VineClient.svg?maxAge=7200)](https://www.nuget.org/packages/VineClient/) [![Join the chat at https://gitter.im/modern-dev/vine-client-dotnet](https://badges.gitter.im/modern-dev/vine-client-dotnet.svg)](https://gitter.im/modern-dev/vine-client-dotnet?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)

# VineClient for .NET

**VineClient** - is an unofficial C# library for the [:link:Vine](https://vine.com/).

## :dvd: NuGet

```bash
PM> Install-Package VineClient
```

## :clipboard: Usage

```csharp
var username = "user@some.com";
var password = "superpass1";
var client = new VineClient();

await client.Authenticate(username, password);

// Gets a list of trending posts.
var resp = await client.Timelines.GetTrending();

if (resp.IsSuccess)
{
    ShowVines(resp.Data);
}

client.Dispose();
```

or even simpler:

```csharp
using (var client = new VineClient())
{
    await client.Authenticate("user@some.com", "superpass1");

    var resp = await client.Timelines.GetTrending();
    // ...
}
```

## :mortar_board: API Reference

**TODO:**

## :green_book: Platform Support

**InTouch** is compiled for .NET 4.5, as well a Portable Class Library (Profile 111) supporting:
 - .NET 4.5
 - ASP.NET Core 1.0
 - Windows 8
 - Windows Phone 8.1
 - Xamarin.Android
 - Xamarin.iOS
 - Xamarin.iOS (Classic)

## :green_book: License

[Licensed under the GPLv3 license.](https://github.com/modern-dev/vine-client-dotnet/blob/master/LICENSE)

Copyright (c) 2016 Bohdan Shtepan

---

> [modern-dev.com](http://modern-dev.com) &nbsp;&middot;&nbsp;
> GitHub [@virtyaluk](https://github.com/virtyaluk) &nbsp;&middot;&nbsp;
> Twitter [@virtyaluk](https://twitter.com/virtyaluk)