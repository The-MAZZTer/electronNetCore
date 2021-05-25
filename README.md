# ElectronNetCore

Sorry, I can't think of a better name.

## What is it?

This is designed as a replacement for Electron.NET with a focus on improving the development experience for .NET applications leveraging Electron for UI, as well as filling in some of the blind spots Electron.NET has.

## Hoes does this compare to Electron.NET?

Electron.NET appears to have been designed from the Electron point of view, while ElectronNetCore was designed from the .NET point of view.

In Eelctron.NET, electron serves as the root process, launching your application as a child process. This means all electron APIs that assume electron is running the main application process will work successfully as-is, mostly APIs which cause effects outside of the electron UI (jump lists, notifications, shortcuts, auto-updates, etc).

However there are some downfalls to this approach. Because your .NET application does not start until after electron initializes, some APIs cannot be used at all (such as changing the UserPath).

The development experience is greatly degrated. Your .NET application must be published before each application run. If you are using Angular or similar frameworks, this may take quite some time.

Furthermore Visual Studio cannot hook into your application automatically for debugging. Official guidance from the Electron.NET team is to manually attach the debugger, but this does not help if your application is crashing on startup.

Electron.NET, as of release 11, only supported .NET 5. If you wanted to develop for the latest .NET LTS release, .NET Core 3.1, you had to use Electron.NET release 9.

After sitting waiting 10 minutes for my Electron.NET application to run, only to have it immedaitely crash without any idea why, I decided something needed to be done.

ElectronNetCore runs electron as a subprocess of your .NET application, immediately giving your code full control over everything that happens.

This also means there is no change to the development process, since Visual Studio sees a normal .NET application. Debugging works as expected, and SPA frameworks can run in their normal development modes without a costly production build every run.

Some APIs can be tricky to get working compared to Electron.NET, such as middle clicking a window button to open a new window (by default Windows will just run electron instead of your app). Notification application titles can also require a bit of work to show up properly, but they can be done.

Currently there has been no focus on optimization, just functionality, so using a more mature product like Electron.NET may still be desired if performance is a concern. However for making a small number of API calls can still ElectronNetCore perform adequately.

## Features

The latest version of ElectronNetCore will always support the latest Microsoft-supported .NET LTS release (as of now that is .NET Core 3.1).

ElectronNetCore will invoke any of the small number of APIs that must be invoked on startup if you require it, for example to change the electron profile folder to an arbitrary location.

All non-deprecated electron APIs are implemented asyncronously and can be used with C# await/async coding.

ElectronNetCore can track and remote proxy electron objects so you can use them much like any IDisposable objects. You will receive the same object from different API calls if they return the same object on the electron side.

All API calls match the electron calls as closely as possible for ease-of-transation, though they now use the .NET naming convention (CamelCase and Async suffix on async function calls).

A custom JS script file can be specified to handle any syncronous event handling or anything else that can't be done on the .NET side.

## License

MIT license. See LICENSE file for more details.

I would appreciate a link back to this github and a credit in any products that use code from this repository or derived from it.

## TODO

* Electron needs to be adjusted to start up as early as possible, so second-instance functtonality can work as quickly as possible. Currently we start when ASP.NET Core starts our process, which can be slow. This affects things like middle clicking the window button and the Windows jump list which launch a new instance of the application.
* The interface to the API is built on top of SignalR, as that is what I am familiar with. To optimize for performance alternatives should be considered. StdIn/Out would probably work but electron does not support it in Windows, even if you hex edit the binary so Windows allows it. Currently the electron team has no plans to fix this.
* Lots of APIs have yet to be properly tested to ensure they work properly through ElectronNetCore. Especially macOS/Linux specific APIs that don't work on Windows.
* Instantiated objects use the same namespacing as electron(none), while singletons are all put under an "Electron" object on the .NET side. Possibly they should all be on their own to match electron naming convention.
* Some events allow syncronous actions to be taken. This is not possible in an asyncronous environment. ElectronNetCore allows for default actions to be overridden before the event happens, but no decision making can be done during the event. Improvements should be investiaged. For example, url matching based on a regex to specify an action, if this would cover a lot of possible use cases during an event.
* Custom JS script interface should be improved to allow free communication between the script and .NET side. Currently none of the ElectronNetCore APIs are exposed to the JS script.
