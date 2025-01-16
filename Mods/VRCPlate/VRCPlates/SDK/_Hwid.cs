using System.Linq;
using System.Reflection;
using MelonLoader;
using UnhollowerBaseLib;
using UnityEngine;

namespace VRCPlates.SDK
{
	internal class _Hwid
	{
		public unsafe static void InitHwidPatch()
		{
			try
			{
				MelonPreferences_Category melonPreferences_Category = MelonPreferences.CreateCategory("LethalHWID", "HWID Patch");
				MelonPreferences_Entry<string> melonPreferences_Entry = melonPreferences_Category.CreateEntry<string>("HWID", "", null, null, true, false, null, null);
				string text = melonPreferences_Entry.Value;
				bool flag = text.Length != SystemInfo.deviceUniqueIdentifier.Length;
				if (flag)
				{
					System.Random random = new System.Random(System.Environment.TickCount);
					byte[] array = new byte[SystemInfo.deviceUniqueIdentifier.Length / 2];
					random.NextBytes(array);
					text = string.Join("", from it in array
					select it.ToString("x2"));
					MelonLogger.Msg("Generated and saved a new HWID");
					melonPreferences_Entry.Value = text;
					melonPreferences_Category.SaveToFile(false);
				}
				_Hwid.ourGeneratedHwidString = new Il2CppSystem.Object(IL2CPP.ManagedStringToIl2Cpp(text));
				string name = "UnityEngine.SystemInfo::GetDeviceUniqueIdentifier";
				System.IntPtr value = IL2CPP.il2cpp_resolve_icall(name);
				bool flag2 = value == System.IntPtr.Zero;
				if (flag2)
				{
					MelonLogger.Error("Can't resolve the icall, not patching");
				}
				else
				{
					MelonUtils.NativeHookAttach((System.IntPtr)((void*)(&value)), typeof(_Hwid).GetMethod("GetDeviceIdPatch", BindingFlags.Static | BindingFlags.NonPublic).MethodHandle.GetFunctionPointer());
					MelonLogger.Msg("[Patch] HWID Patched!; below Id's should match:");
					MelonLogger.Msg("[Patch] Current: " + SystemInfo.deviceUniqueIdentifier);
					MelonLogger.Msg("[Patch] Target:  " + text);
				}
			}
			catch (System.Exception ex)
			{
				MelonLogger.Error(ex.ToString());
			}
		}
		private static System.IntPtr GetDeviceIdPatch()
		{
			return _Hwid.ourGeneratedHwidString.Pointer;
		}
		private static Il2CppSystem.Object ourGeneratedHwidString;
	}
}
