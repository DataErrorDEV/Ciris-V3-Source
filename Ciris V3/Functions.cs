using System;
using System.Threading;
using System.Windows.Forms;

namespace Ciris_V3
{
	// Token: 0x02000004 RID: 4
	internal class Functions
	{
		// Token: 0x06000055 RID: 85 RVA: 0x000071CC File Offset: 0x000053CC
		public static void Inject()
		{
			if (NamedPipes.NamedPipeExist(NamedPipes.scriptpipe))
			{
				MessageBox.Show("Already injected!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				return;
			}
			if (!NamedPipes.NamedPipeExist(NamedPipes.scriptpipe))
			{
				switch (Injector.DllInjector.GetInstance.Inject("RobloxPlayerBeta", AppDomain.CurrentDomain.BaseDirectory + Functions.exploitdll))
				{
				case Injector.DllInjectionResult.DllNotFound:
					MessageBox.Show("Couldn't find " + Functions.exploitdll, "Dll was not found!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					return;
				case Injector.DllInjectionResult.GameProcessNotFound:
					MessageBox.Show("Couldn't find RobloxPlayerBeta.exe!", "Target process was not found!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					return;
				case Injector.DllInjectionResult.InjectionFailed:
					MessageBox.Show("Injection Failed!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					return;
				default:
					Thread.Sleep(2000);
					if (NamedPipes.NamedPipeExist(NamedPipes.scriptpipe))
					{
						MessageBox.Show("Injected!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						return;
					}
					MessageBox.Show("Injection Failed!\nMaybe you are Missing something\nor took more time to check if was ready", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					break;
				}
			}
		}

		// Token: 0x04000048 RID: 72
		public static string exploitdll = "Ciris.dll";

		// Token: 0x04000049 RID: 73
		public static string[] TextToBox = new string[]
		{
			"\nCommands:\nff [p]\nheaven [p]\nghost [p]\nstatchange [p] [stat] [#]\nkeemstar [p]\nilluminati [p]\nduck [p]\nmlg [p]\npussy [p]\nfog [#]\nrfog\nrhat [p]\nws [p] [#]\nsit [p]\nhipheight [p] [#]\njp [p] [#]\nkill [p]\ndrivebloxmoney [p]\ngravity [#]\nbtools [p]\ngod [p]\nbigfire [p]\ntime [#]\nselect [p]\nfencingr\nforcechat [p] [blue/red/green]\ncharapp [p] [#]\nnoob [p]\nfire [p]\nsmoke [p]\nsethealth [p] [#]\naddhealth [p] [#]\nsparkles [p]\ncriminal\ngarage\nbank\nprison\nnodoors\nbanklazers\njewelrycameras\njewelrylazers\njewelryflazers\njewelry\nrickroll\nppap\nbillnye\nilluminati\nrage\ncringe\nclearws\nunanchorall\nfecheck\nplay [#]\nstopmusic\nSome Commands may not work",
			"\nCredits;\nrakion99\nRoblox\nEternal for RetCheck\nAutisticBobby\nJosh()"
		};

		// Token: 0x0400004A RID: 74
		public static OpenFileDialog openfiledialog = new OpenFileDialog
		{
			Filter = "Lua C Script Txt (*.txt)|*.txt|All files (*.*)|*.*",
			FilterIndex = 1,
			RestoreDirectory = true
		};
	}
}
