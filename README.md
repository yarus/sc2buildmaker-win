# sc2buildmaker-win
Hi to all of you who interested in programming and like StarCraft 2 :)!.

This repository is a part of codebase which I was working on thru several years in order to implement SC2 Build Maker android application:
https://play.google.com/store/apps/details?id=com.sc2toolslab.sc2bmfree
https://play.google.com/store/apps/details?id=com.sc2toolslab.sc2bmfull

https://youtu.be/Y4cYK_L-Q1k
(The video was recorder for outdated version but it still allows to see how the app works).

***

sc2buildmaker-Win - is .NET 4.5 C# codebase which I used to implement Starcraft2 economy model simulator. It also contains simple WinForms application which has similar functionality to SC2BuildMaker android app - it allows to create build orders. I also used this app to  generate SC2BuildMaker version config file which contains all required infromation regarding each unit/building/upgrade and build requirements for each item.

The major purpose of this codebase is to generate new SC2BuildMaker version configuration file to implement adjustments from the recent patch (like unit/building/upgrade costs and requirements). In addition to that this codebase contains simple WinForms application which allows to work with build orders.

***

Ideas for future improvements:
1. Isolate build order engine into separate NuGet package to allow its reusage.
2. Migrate codebase to .NET Core which would allow to implement mobile application using Xamarin - this will allow to publish the app to Apple Store.
3. Implement visual version file configuration editor: currently you have to modify code in order to produce new SC2BuildMaker version file but it shouldn't be that hard to create WinForms/WPF/Xamarin application to do the same using UI.

***

SC2.Win.UI - .NET 4.5 C# WinForms application which I used to generate SC2BuildMaker version config files and to test build orders.

![SC2.Win.UI Solution](readme-assets/SC2-Win-UI-Solution.png)

The application was implemented using M-V-P-VM pattern aka Model-View-Presenter-ViewModel. I added Presenter into MVVM common pattern just because it is WinForms app and not WPF which contains VM bindings. By implementing this pattern I tried to isolate actual UI library from functionality implementation. So using the same libraries it should be pretty easy to implement the same app using WPF/Xamarin.

SC2.Win.Presentation project abstracting UI interactions into a concept called UIWorkflow.

SC2.PublicData project contains serializable data contracts which are used to generate json files.

SC2.Entities project contains Starcraft 2 economy simulation classes and SC2 Build Maker build order engine.

SC2.DataManagers project contains facade classes which allows to save/get/update build orders and version files.

SC2.DataAccess - XML, Json serialization classes.

***

SC2BuildMaker version configuration file is a core of both android and win applications. This file contains serialized data which define economy simulation settings for specific SC2 patch and all details regarding each build order item (aka unit, building, upgrade). This data includes build times, mineral/gas cost for each unit and requirements which has to be met in order to allow to add build item into the build order.

```csharp
[Serializable]
public class SC2VersionInfo
{
  public string AddonID { get; set; }
  public string VersionID { get; set; }
  public GlobalConstantsInfo GlobalSettings { get; set; }
  public List<RaceSettingsInfo> RaceSettingsList { get; set; }

  public SC2VersionInfo()
  {
    this.RaceSettingsList = new List<RaceSettingsInfo>();
  }
}
```

AddonID - WOL,HOTS,LOTV.
VersionID - actual SC2 patch version, i.e. the current LOTV VersionID is 4.11.3.
GlobalSettings - contains settings which are used as a part of SC2 economy simulation.
RaceSettingsList - all details related to specific game race/faction in the specified VersionID.

This data is serialized into JSON file with txt extension.
