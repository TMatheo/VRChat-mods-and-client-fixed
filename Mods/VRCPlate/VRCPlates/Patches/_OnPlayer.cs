using System;
using HarmonyLib;
using MelonLoader;
using VRC;

namespace VRCPlates.Patches
{
	internal class _OnPlayer
	{
		public static void InitOnPlayer()
		{
			try
			{
				VRCPlatesPatches.Instance.Patch(typeof(NetworkManager).GetMethod("Method_Public_Void_Player_0"), new HarmonyMethod(AccessTools.Method(typeof(_OnPlayer), "OnPlayerJoin", null, null)), null, null, null, null);
				VRCPlatesPatches.Instance.Patch(typeof(NetworkManager).GetMethod("Method_Public_Void_Player_1"), new HarmonyMethod(AccessTools.Method(typeof(_OnPlayer), "OnPlayerLeave", null, null)), null, null, null, null);
				MelonLogger.Msg("[Patch] OnPlayer Patched!");
			}
			catch (Exception ex)
			{
				string str = "[Patch] Patching OnPlayer Failed!\n";
				Exception ex2 = ex;
				MelonLogger.Msg(str + ((ex2 != null) ? ex2.ToString() : null));
			}
		}
		public static void OnPlayerJoin(ref Player __0)
		{
			bool flag = __0.prop_APIUser_0 == null;
			if (!flag)
			{
				VRCPlateNameplates.UpdatePlayerNameplates(__0);
			}
		}
		public static void OnPlayerLeave(ref Player __0)
		{
			bool flag = __0.prop_APIUser_0 == null;
			if (!flag)
			{
				VRCPlateNameplates.UpdatePlayerNameplates(__0);
			}
		}
	}
}
