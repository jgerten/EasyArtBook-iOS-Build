using Avalonia;
using Avalonia.iOS;
using Foundation;

namespace EasyArtBook.Mobile.iOS;

// The UIApplicationDelegate for the application. Launches the Avalonia UI and
// listens (and optionally responds) to application events from iOS.
[Register("AppDelegate")]
#pragma warning disable CA1711 // Identifiers should not have incorrect suffix
public partial class AppDelegate : AvaloniaAppDelegate<App>
#pragma warning restore CA1711 // Identifiers should not have incorrect suffix
{
    protected override AppBuilder CustomizeAppBuilder(AppBuilder builder)
    {
        // Wire iOS haptics into the shared HapticFeedback bridge (used by drag-to-reorder).
        IosHaptics.Register();

        return base.CustomizeAppBuilder(builder)
            .WithInterFont();
    }
}
