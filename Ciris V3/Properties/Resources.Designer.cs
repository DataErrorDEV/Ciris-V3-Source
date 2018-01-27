using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace Ciris_V3.Properties
{
	// Token: 0x02000008 RID: 8
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
	[DebuggerNonUserCode]
	[CompilerGenerated]
	internal class Resources
	{
		// Token: 0x06000061 RID: 97 RVA: 0x00002C3A File Offset: 0x00000E3A
		internal Resources()
		{
		}

		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000062 RID: 98 RVA: 0x0000765B File Offset: 0x0000585B
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				if (Resources.resourceMan == null)
				{
					Resources.resourceMan = new ResourceManager("Ciris_V3.Properties.Resources", typeof(Resources).Assembly);
				}
				return Resources.resourceMan;
			}
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000063 RID: 99 RVA: 0x00007687 File Offset: 0x00005887
		// (set) Token: 0x06000064 RID: 100 RVA: 0x0000768E File Offset: 0x0000588E
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static CultureInfo Culture
		{
			get
			{
				return Resources.resourceCulture;
			}
			set
			{
				Resources.resourceCulture = value;
			}
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000065 RID: 101 RVA: 0x00007696 File Offset: 0x00005896
		internal static Bitmap Ciris_Logo
		{
			get
			{
				return (Bitmap)Resources.ResourceManager.GetObject("Ciris Logo", Resources.resourceCulture);
			}
		}

		// Token: 0x0400004E RID: 78
		private static ResourceManager resourceMan;

		// Token: 0x0400004F RID: 79
		private static CultureInfo resourceCulture;
	}
}
