using EasyArtBook.Mobile.Services;
using UIKit;

namespace EasyArtBook.Mobile.iOS;

/// <summary>
/// Wires the shared <see cref="HapticFeedback"/> bridge to iOS's
/// UIImpactFeedbackGenerator. Called once at startup from the AppDelegate.
/// </summary>
internal static class IosHaptics
{
    // Kept alive and pre-prepared so taps have minimal latency.
    private static UIImpactFeedbackGenerator? _light;
    private static UIImpactFeedbackGenerator? _medium;
    private static UIImpactFeedbackGenerator? _heavy;

    public static void Register()
    {
        HapticFeedback.Handler = style =>
        {
            // UIKit must be touched on the main thread.
            UIApplication.SharedApplication.InvokeOnMainThread(() =>
            {
                var gen = style switch
                {
                    HapticStyle.Light  => _light  ??= new UIImpactFeedbackGenerator(UIImpactFeedbackStyle.Light),
                    HapticStyle.Heavy  => _heavy  ??= new UIImpactFeedbackGenerator(UIImpactFeedbackStyle.Heavy),
                    _                  => _medium ??= new UIImpactFeedbackGenerator(UIImpactFeedbackStyle.Medium),
                };
                gen.Prepare();
                gen.ImpactOccurred();
            });
        };
    }
}
