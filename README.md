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

**VineClient** brings all the advantages of [:link:async programming](https://msdn.microsoft.com/en-us/library/hh191443.aspx). Which means there are only a couple of *non-async* methods and all the rest are *async*. So you need to `await` them.

### API Requests

#### Response object

Calling to the API will always result in `Response` object which describes the next data structure:

```csharp
public class Response<T>
    {
        // Field returned by the API.
        string Code,

        // Response data (if any).
        T Data,

        // Whether the request response is success.
        bool IsSuccess,

        // Response error (if any).
        string Error
    }
```

So, for example, retrieving followers list using `GetFollowers` method will result in `Response<RecordsList<User>>`, where `Data` property would be of type `RecordsList<User>`.

There are few *options* using which you can control how **VineClient** handles response errors.

```csharp
// If set to true, then an exception will be thrown in case of response error,
// instead of passing an error object to the Response object.
client.EnsureResponseSuccess = true;

// If set to true, then Response.Raw will be filled with raw JSON response string.
client.IncludeRawResponse  = true;

try
{
    var followers = await client.Users.GetFollowers(1);
}
catch (VineClientException ex)
{
    MessageBox.Show(ex.Message);
}
```

#### Parameters transmissiton in API

Some of the methods have its own *parameters*. Keep in mind, **VineClient** would throw an exception if not all **required** parameters filled with data. *Optional* parameters may be omitted.

#### Registration, authorization and logging out

In order to call most API methods, your application require user authorization.

Authorization may be performed using the Authorize method passing user credentials.

```csharp
string username = "yourusername",
    password = "yourpassword",
    optionalDeviceToken = null;

await client.Authenticate(username, password, optionalDeviceToken);
```

In case if a user has not Vine account so far then the one may be obtained using the `Signup` method.

```csharp
string username = "yourusername",
    password = "yourpassword1",
    email = "youremail@example.com";

await client.Signup(username, password, email);
```

To close the session you should use the `Logout` method.

```csharp
await client.Logout();
```

#### Custom API request

You may want to get full control on what you send through the request. **VineClient** exposes `Request` method to send Vine API requests. All the **VineClient** API methods are build on top of the one. The signature is next:

```csharp
async Task<Response<T>> Request<T>(string endpoint, string reqType = "get", MethodParams reqParams = null)
```

**Values:**

- **`endpoint`** - Method endpoint.
- **`reqType`** - Request type. Can be either `Post`, `Get` or `Delete`.
- **`reqParams`** - Request parameters.

The next example shows how to get a list of user's followers using the Request method:

```csharp
var followers = await client.Request<RecordsList<User>>($"users/{1}/followers");
```

### API methods

All the method grouped by corresponding categories e.g. `Timelines`, `Users`, `Posts` etc.

#### Channels methods

##### GetFeatured

Returns a list of featured channels.

```csharp
Response<RecordsList<Channel>> resp = await client.Channels.GetFeatured();
```

#### Posts methods

##### LikePost

Adds the post to the *Likes* list of the current user.

```csharp
Response<Like> res = await client.Posts.LikePost(postId: 125);
```

##### DeleteLike

Deletes the post from the *Likes* list of the current user.

```csharp
Response<Empty> res = await client.Posts.DeleteLike(postId: 125);
```

##### CreateComment

Adds a comment to a post.

```csharp
Response<Comment> res = await client.Posts.CreateComment(postId: 125, comment: "say what");
```

##### DeleteComment

Deletes a comment on a post.

```csharp
Response<Empty> res = await client.Posts.DeleteComment(postId: 125, commentId: 654);
```

##### Revine

Revines a post.

```csharp
Response<Repost> res = await client.Posts.Revine(postId: 125);
```

##### Unrevine

Unrevines a post.

```csharp
Response<Empty> res = await client.Posts.Unrevine(postId: 125, revineId: 369);
```

##### Report

Reports (submits a complaint about) a post.

```csharp
Response<Empty> res = await client.Posts.Report(postId: 125);
```

##### Post

Adds a new post.

```csharp
Response<Empty> res = await client.Posts.Post(videoUrl: "video_url", thumbnailUrl: "thumb_url", description: "My first vine");
```

##### Delete

Deletes a post by given post Id.

```csharp
Response<Empty> res = await client.Posts.Delete(postId: 125);
```

#### Tags methods

##### GetTrending

Gets a list of trending tags.

```csharp
Response<RecordsList<Tag>> res = await client.Tags.GetTrending();
```

##### Search

Returns a list of tags matching the search criteria.

```csharp
Response<RecordsList<Tag>> res = await client.Tags.Search(query: "UMF", size: 15, page: 1);
```

#### Timelines methods

##### GetPostById

Returns a post by its Id.

```csharp
Response<RecordsList<Post>> res = await client.Timelines.GetPostById(postId: 125);
```

##### GetUserTimeline

Returns a list of posts from user by user Id.

```csharp
Response<RecordsList<Post>> res = await client.Timelines.GetUserTimeline(userId: 1, size: 15, page: 1);
```

##### GetUserLikes

Returns a list of posts liked by user with specified user Id.

```csharp
Response<RecordsList<Post>> res = await client.Timelines.GetUserLikes(userId: 1, size: 15, page: 1);
```

##### GetTagTimeline

Returns a list of posts by specified tag name.

```csharp
Response<RecordsList<Post>> res = await client.Timelines.GetTagTimeline(tagName: "UMF", size: 15, page: 1);
```

##### GetMainTimeline

Returns a list of posts from the main timeline.

```csharp
Response<RecordsList<Post>> res = await client.Timelines.GetMainTimeline(size: 15, page: 1);
```

##### GetPopular

Returns a list of popular posts.

```csharp
Response<RecordsList<Post>> res = await client.Timelines.GetPopular(size: 15, page: 1);
```

##### GetTrending

Returns a list of trending posts.

```csharp
Response<RecordsList<Post>> res = await client.Timelines.GetTrending(size: 15, page: 1);
```

##### GetPromoted

Returns a list of promoted posts.

```csharp
Response<RecordsList<Post>> res = await client.Timelines.GetPromoted(size: 15, page: 1);
```

##### GetChannelPopular

Returns a list of recent posts from a channel.

```csharp
Response<RecordsList<Post>> res = await client.Timelines.GetChannelPopular(channelId: 258, size: 15, page: 1);
```

##### GetVenue

Returns a list of venues posts.

```csharp
Response<RecordsList<Post>> res = await client.Timelines.GetVenue(venueId: 159, size: 15, page: 1);
```

##### GetSimilar

Returns a list of similar posts by given post Id.

```csharp
Response<RecordsList<Post>> res = await client.Timelines.GetSimilar(postId: 125, size: 15, page: 1);
```

#### Users methods

##### GetMe

Returns detailed information on the current user.

```csharp
Response<User> res = await client.Users.GetMe();
```

##### GetUserById

Returns detailed information on the user with specified Id.

```csharp
Response<User> res = await client.Users.GetUserById(userId: 1);
```

##### UpdateProfile

Allows to edit the current account info.

```csharp
Response<User> res = await client.Users.UpdateProfile(userId: 1, description: "Bohdan Shtepan", location: "US", locale: "EN", privateProfile: false, phoneNumber: null);
```

##### SetExplicit

Sets explicit profile to true.

```csharp
Response<Empty> res = await client.Users.SetExplicit(userId: 1);
```

##### UnsetExplicit

Sets explicit profile to false.

```csharp
Response<Empty> res = await client.Users.UnsetExplicit(userId: 1);
```

##### Follow

Follows the user with given Id.

```csharp
Response<Empty> res = await client.Users.Follow(userId: 1);
```

##### Unollow

Unfollows the user with given Id.

```csharp
Response<Empty> res = await client.Users.Unollow(userId: 1);
```

##### Block

Blocks the user with given Id.

```csharp
Response<Empty> res = await client.Users.Block(userId: 1);
```

##### Unblock

Unblocks the user with given Id.

```csharp
Response<Empty> res = await client.Users.Unblock(userId: 1);
```

##### GetPendingNotificationsCount

Returns the number of pending notifications.

```csharp
Response<int> res = await client.Users.GetPendingNotificationsCount(userId: 1);
```

##### GetNotifications

Returns a list of notifications.

```csharp
Response<RecordsList<Notification>> res = await client.Users.GetNotifications(userId: 1);
```

##### GetFollowers

Returns a list of followers of the user with given Id.

```csharp
Response<RecordsList<User>> res = await client.Users.GetFollowers(userId: 1);
```

##### GetFollowing

Returns a list of users following by the user with given Id.

```csharp
Response<RecordsList<User>> res = await client.Users.GetFollowing(userId: 1);
```

##### Search

Returns a list of users matching the search criteria.

```csharp
Response<RecordsList<User>> res = await client.Users.Search(query: "virtyaluk": size: 15, page: 1);
```

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

Based on the Vine API documentation by [**@neuegram**](https://github.com/neuegram) and [starlock](https://github.com/starlock/vino/wiki/API-Reference).

[Licensed under the GPLv3 license.](https://github.com/modern-dev/vine-client-dotnet/blob/master/LICENSE)

Copyright (c) 2016 Bohdan Shtepan

---

> [modern-dev.com](http://modern-dev.com) &nbsp;&middot;&nbsp;
> GitHub [@virtyaluk](https://github.com/virtyaluk) &nbsp;&middot;&nbsp;
> Twitter [@virtyaluk](https://twitter.com/virtyaluk)