using UnityEngine;
using VRC;

namespace VRCPlates
{
	internal static class Misc
	{
		public static float GetFrames(this Player player)
		{
			return (player._playerNet.prop_Byte_0 != 0) ? Mathf.Floor(1000f / (float)player._playerNet.prop_Byte_0) : -1f;
		}
		public static short GetPing(this Player player)
		{
			return player._playerNet.field_Private_Int16_0;
		}
		public static string GetFramesColord(this Player player)
		{
			float frames = player.GetFrames();
			bool flag = frames > 80f;
			string result;
			if (flag)
			{
				result = "<color=green>" + frames.ToString() + "</color>";
			}
			else
			{
				bool flag2 = frames > 30f;
				if (flag2)
				{
					result = "<color=yellow>" + frames.ToString() + "</color>";
				}
				else
				{
					result = "<color=red>" + frames.ToString() + "</color>";
				}
			}
			return result;
		}
		public static string GetPingColord(this Player player)
		{
			short ping = player.GetPing();
			bool flag = ping > 150;
			string result;
			if (flag)
			{
				result = "<color=red>" + ping.ToString() + "</color>";
			}
			else
			{
				bool flag2 = ping > 75;
				if (flag2)
				{
					result = "<color=yellow>" + ping.ToString() + "</color>";
				}
				else
				{
					result = "<color=green>" + ping.ToString() + "</color>";
				}
			}
			return result;
		}
		public static string GetPlatform(this Player player)
		{
			bool isOnMobile = player.prop_APIUser_0.IsOnMobile;
			string result;
			if (isOnMobile)
			{
				result = "<color=green>Q</color>";
			}
			else
			{
				bool flag = player.prop_VRCPlayerApi_0.IsUserInVR();
				if (flag)
				{
					result = "<color=#CE00D5>VR</color>";
				}
				else
				{
					result = "<color=grey>PC</color>";
				}
			}
			return result;
		}
	}
}
