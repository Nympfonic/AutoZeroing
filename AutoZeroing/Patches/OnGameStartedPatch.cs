using Aki.Reflection.Patching;
using Arys.AutoZeroing.Helpers;
using EFT;
using HarmonyLib;
using System.Reflection;

namespace Arys.AutoZeroing.Patches
{
    internal class OnGameStartedPatch : ModulePatch
    {
        protected override MethodBase GetTargetMethod()
        {
            return AccessTools.Method(typeof(GameWorld), nameof(GameWorld.OnGameStarted));
        }

        [PatchPostfix]
        private static void PatchPostfix(GameWorld __instance)
        {
            var player = __instance.MainPlayer;
            player.gameObject.AddComponent<AutoZeroingController>();
#if DEBUG
            LoggingHelper.LogInfo("Adding AutoZeroingController component to player");
#endif
        }
    }
}
