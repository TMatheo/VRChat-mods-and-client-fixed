using System;
using System.Reflection;
using Harmony;
using HarmonyLib;
using MelonLoader;
using VRCPlates.SDK;

namespace VRCPlates.Patches
{
	internal class VRCPlatesPatches
	{
		[Obsolete]
		public static Harmony.HarmonyMethod GetLocalPatch(Type type, string methodName)
		{
			return new Harmony.HarmonyMethod(type.GetMethod(methodName, BindingFlags.Static | BindingFlags.NonPublic));
		}
		public static void InitPatches()
		{
			try
			{
				MelonLogger.Msg("[Patch] Starting Patches....");
				_Hwid.InitHwidPatch();
				_OnPlayer.InitOnPlayer();
			}
			catch (Exception ex)
			{
				MelonLogger.Msg(ex.Message);
			}
		}
		public static Harmony.HarmonyInstance Instance = new Harmony.HarmonyInstance("VRCPlates");
	}
}
