using System;
using System.Reflection;
using HarmonyLib;
using MelonLoader;
using VRC.Core;

namespace Astrum
{
    public class AstralClone : MelonMod
    {
        public override void OnApplicationStart()
        {
            MelonLogger.Msg("Patching AllowAvatarCopying...");
            base.HarmonyInstance.Patch(typeof(APIUser).GetProperty("allowAvatarCopying").GetSetMethod(), new HarmonyMethod(typeof(AstralClone).GetMethod("Hook", BindingFlags.Static | BindingFlags.NonPublic)), null, null, null, null);
            MelonLogger.Msg("AllowAvatarCopying Patched !");
        }

        private static void Hook(ref bool __0)
        {
            __0 = true;
        }
    }
}