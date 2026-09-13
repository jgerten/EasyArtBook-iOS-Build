# EasyArtBook iOS build

Build-only repository for the EasyArtBook iOS app. It exists so the macOS
build (AOT link, codesign, TestFlight upload) runs on GitHub's free public-repo
minutes.

It contains **no application source**: only the iOS host shell
(`AppDelegate.cs`, `Main.cs`, launch screen, icons, plists), a workflow, and
pre-built assemblies in `lib/` that are exported from the private source repo.
Those assemblies are the same ones shipped inside every `.ipa`.

## Release procedure

1. In the private source repo, run the **Export iOS assemblies** workflow.
2. `gh run download -R jgerten/EasyArtBook -n ios-assemblies -D lib/`
3. Commit and push `lib/`.
4. Run the **iOS TestFlight** workflow here.

Build number = 100 + run number (Apple already holds build 1).
