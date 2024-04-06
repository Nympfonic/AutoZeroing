using BepInEx;
using BepInEx.Logging;

namespace Arys.AutoZeroing
{
    [BepInPlugin("com.Arys.AutoZeroing", "Auto Zeroing", "1.0.0")]
    public class Plugin : BaseUnityPlugin
    {
        internal static ManualLogSource LogSource = BepInEx.Logging.Logger.CreateLogSource("Arys-AutoZeroing");

        private void Awake()
        {
            new OnGameStartedPatch().Enable();
        }
    }
}
