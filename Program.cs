using System;
using System.Windows.Forms;

namespace Ciris_V3
{
	// Token: 0x02000007 RID: 7
	internal static class Program
	{
		// Token: 0x06000060 RID: 96 RVA: 0x00007644 File Offset: 0x00005844
		[STAThread]
		private static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Form1());
		}
	}
}
