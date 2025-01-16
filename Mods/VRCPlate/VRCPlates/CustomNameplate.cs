using System;
using TMPro;
using UnityEngine;
using VRC;

namespace VRCPlates
{
	internal class CustomNameplate : MonoBehaviour
	{
		public CustomNameplate(IntPtr ptr) : base(ptr)
		{
		}
		private void Start()
		{
			PlayerNameplate field_Public_PlayerNameplate_ = this.player._vrcplayer.field_Public_PlayerNameplate_0;
			Transform transform = field_Public_PlayerNameplate_.field_Public_GameObject_5.transform;
			this.PlateObg = UnityEngine.Object.Instantiate<Transform>(transform, transform);
			this.PlateObg.parent = field_Public_PlayerNameplate_.transform;
			this.PlateObg.parent = base.gameObject.transform.Find("Contents");
			this.PlateObg.name = "LethalPlates";
			this.PlateObg.gameObject.SetActive(true);
			this.PlateObg.localPosition = new Vector3(0f, 140f, 0f);
			this.PlateObg.localScale = new Vector3(1f, 1f, 2f);
			this.Nameplatext = this.PlateObg.Find("Trust Text").GetComponent<TextMeshProUGUI>();
			this.Nameplatext.color = Color.white;
			this.Nameplatext.fontStyle = FontStyles.Subscript;
			this.Nameplatext.isOverlay = true;
			this.PlateObg.Find("Trust Icon").gameObject.SetActive(false);
			this.PlateObg.Find("Performance Icon").gameObject.SetActive(false);
			this.PlateObg.Find("Performance Text").gameObject.SetActive(false);
			this.PlateObg.Find("Friend Anchor Stats").gameObject.SetActive(false);
			this.frames = this.player._playerNet.field_Private_Byte_0;
			this.ping = this.player._playerNet.field_Private_Byte_1;
			this.Nameplatext.text = "";
		}
		private void Update()
		{
			bool flag = this.frames == this.player._playerNet.field_Private_Byte_0 && this.ping == this.player._playerNet.field_Private_Byte_1;
			if (flag)
			{
				this.noUpdateCount++;
			}
			else
			{
				this.noUpdateCount = 0;
			}
			this.frames = this.player._playerNet.field_Private_Byte_0;
			this.ping = this.player._playerNet.field_Private_Byte_1;
			string text = "<color=green>Stable</color>";
			bool flag2 = this.noUpdateCount > 35;
			if (flag2)
			{
				text = "<color=yellow>Lagging</color>";
			}
			bool flag3 = this.noUpdateCount > 375;
			if (flag3)
			{
				text = "<color=red>Crashed</color>";
			}
			try
			{
				this.Nameplatext.text = string.Concat(new string[]
				{
					"[<color=green>",
					this.player.GetPlatform(),
					"</color>] | [",
					text,
					"]  |<color=white> FPS:</color> ",
					this.player.GetFramesColord(),
					" |<color=white> Ping</color>: ",
					this.player.GetPingColord()
				});
			}
			catch
			{
			}
		}
		public static bool PlateToggle;
		public Player player = new Player();
		private Transform PlateObg;
		private TextMeshProUGUI Nameplatext;
		private byte frames;
		private byte ping;
		private int noUpdateCount = 0;
	}
}
