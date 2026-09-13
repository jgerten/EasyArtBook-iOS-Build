# EasyArtBook iOS build

Build-only repository for the EasyArtBook iOS app. It exists so the macOS
build (AOT link, codesign, TestFlight upload) runs on GitHub's free public-repo
minutes.

It contains **no application source**: only the iOS host shell
(`AppDelegate.cs`, `Main.cs`, launch screen, icons, plists), a workflow, and
pre-built assemblies in `lib/` that are exported from the private source repo.
Those assemblies are the same ones shipped inside every `.ipa`.

## Release procedure

From the private source repo on a machine with the .NET 10 SDK and the `ios`
workload (no Xcode needed):

```powershell
.\publish-ios.ps1                      # build from the working tree
.\publish-ios.ps1 -Source <worktree>   # build exactly one commit
```

The script builds the assemblies, commits them to `lib/` here, pushes, and
dispatches the **iOS TestFlight** workflow, verifying the run picked up the
pushed commit. Build number = 100 + run number (Apple already holds build 1).

Fallback without a local SDK: run the source repo's **Export iOS assemblies**
workflow, `gh run download -n ios-assemblies -D lib/`, commit, push, dispatch.
