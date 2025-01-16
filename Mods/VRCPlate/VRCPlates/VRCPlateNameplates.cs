using System;
using VRC;

namespace VRCPlates
{
	public class VRCPlateNameplates
	{
		public static void InitPlayerNameplates()
		{
			for (int i = 0; i < PlayerManager.prop_PlayerManager_0.field_Private_List_1_Player_0.ToArray().Length; i++)
			{
				Player player = PlayerManager.prop_PlayerManager_0.field_Private_List_1_Player_0.ToArray()[i];
				CustomNameplate customNameplate = player._vrcplayer.field_Public_PlayerNameplate_0.gameObject.AddComponent<CustomNameplate>();
				customNameplate.player = player;
				bool flag = i >= PlayerManager.prop_PlayerManager_0.field_Private_List_1_Player_0.ToArray().Length;
				if (flag)
				{
					break;
				}
			}
		}
		public static void UpdatePlayerNameplates(Player player)
		{
			bool flag = player == null;
			if (flag)
			{
				throw new ArgumentNullException("player");
			}
			for (int i = 0; i < PlayerManager.prop_PlayerManager_0.field_Private_List_1_Player_0.ToArray().Length; i++)
			{
				player = PlayerManager.prop_PlayerManager_0.field_Private_List_1_Player_0.ToArray()[i];
				CustomNameplate customNameplate = player._vrcplayer.field_Public_PlayerNameplate_0.gameObject.AddComponent<CustomNameplate>();
				customNameplate.player = player;
				bool flag2 = i >= PlayerManager.prop_PlayerManager_0.field_Private_List_1_Player_0.ToArray().Length;
				if (flag2)
				{
					break;
				}
			}
		}
		public static bool toggled;
	}
}
