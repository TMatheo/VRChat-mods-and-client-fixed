using System.Threading.Tasks;
using MelonLoader;
using UnhollowerRuntimeLib;
using VRCPlates.Patches;

namespace VRCPlates
{
	internal class Main : MelonMod
	{
		public override void OnInitializeMelon()
		{
			ClassInjector.RegisterTypeInIl2Cpp<CustomNameplate>();
			Task.Run(delegate()
			{
				VRCPlatesPatches.InitPatches();
			});
		}
	}
}
