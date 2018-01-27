using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace Ciris_V3
{
	// Token: 0x02000005 RID: 5
	internal class Injector
	{
		// Token: 0x0200000E RID: 14
		public enum DllInjectionResult
		{
			// Token: 0x0400005C RID: 92
			DllNotFound,
			// Token: 0x0400005D RID: 93
			GameProcessNotFound,
			// Token: 0x0400005E RID: 94
			InjectionFailed,
			// Token: 0x0400005F RID: 95
			Success
		}

		// Token: 0x0200000F RID: 15
		public sealed class DllInjector
		{
			// Token: 0x0600006D RID: 109
			[DllImport("kernel32.dll", SetLastError = true)]
			private static extern IntPtr OpenProcess(uint dwDesiredAccess, int bInheritHandle, uint dwProcessId);

			// Token: 0x0600006E RID: 110
			[DllImport("kernel32.dll", SetLastError = true)]
			private static extern int CloseHandle(IntPtr hObject);

			// Token: 0x0600006F RID: 111
			[DllImport("kernel32.dll", SetLastError = true)]
			private static extern IntPtr GetProcAddress(IntPtr hModule, string lpProcName);

			// Token: 0x06000070 RID: 112
			[DllImport("kernel32.dll", SetLastError = true)]
			private static extern IntPtr GetModuleHandle(string lpModuleName);

			// Token: 0x06000071 RID: 113
			[DllImport("kernel32.dll", SetLastError = true)]
			private static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress, IntPtr dwSize, uint flAllocationType, uint flProtect);

			// Token: 0x06000072 RID: 114
			[DllImport("kernel32.dll", SetLastError = true)]
			private static extern int WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] buffer, uint size, int lpNumberOfBytesWritten);

			// Token: 0x06000073 RID: 115
			[DllImport("kernel32.dll", SetLastError = true)]
			private static extern IntPtr CreateRemoteThread(IntPtr hProcess, IntPtr lpThreadAttribute, IntPtr dwStackSize, IntPtr lpStartAddress, IntPtr lpParameter, uint dwCreationFlags, IntPtr lpThreadId);

			// Token: 0x17000005 RID: 5
			// (get) Token: 0x06000074 RID: 116 RVA: 0x00007B4A File Offset: 0x00005D4A
			public static Injector.DllInjector GetInstance
			{
				get
				{
					if (Injector.DllInjector._instance == null)
					{
						Injector.DllInjector._instance = new Injector.DllInjector();
					}
					return Injector.DllInjector._instance;
				}
			}

			// Token: 0x06000075 RID: 117 RVA: 0x00002C3A File Offset: 0x00000E3A
			private DllInjector()
			{
			}

			// Token: 0x06000076 RID: 118 RVA: 0x00007B64 File Offset: 0x00005D64
			public Injector.DllInjectionResult Inject(string sProcName, string sDllPath)
			{
				if (!File.Exists(sDllPath))
				{
					return Injector.DllInjectionResult.DllNotFound;
				}
				uint num = 0u;
				Process[] processes = Process.GetProcesses();
				for (int i = 0; i < processes.Length; i++)
				{
					if (processes[i].ProcessName == sProcName)
					{
						num = (uint)processes[i].Id;
						break;
					}
				}
				if (num == 0u)
				{
					return Injector.DllInjectionResult.GameProcessNotFound;
				}
				if (!this.bInject(num, sDllPath))
				{
					return Injector.DllInjectionResult.InjectionFailed;
				}
				return Injector.DllInjectionResult.Success;
			}

			// Token: 0x06000077 RID: 119 RVA: 0x00007BC0 File Offset: 0x00005DC0
			private bool bInject(uint pToBeInjected, string sDllPath)
			{
				IntPtr intPtr = Injector.DllInjector.OpenProcess(1082u, 1, pToBeInjected);
				if (intPtr == Injector.DllInjector.INTPTR_ZERO)
				{
					return false;
				}
				IntPtr procAddress = Injector.DllInjector.GetProcAddress(Injector.DllInjector.GetModuleHandle("kernel32.dll"), "LoadLibraryA");
				if (procAddress == Injector.DllInjector.INTPTR_ZERO)
				{
					return false;
				}
				IntPtr intPtr2 = Injector.DllInjector.VirtualAllocEx(intPtr, (IntPtr)null, (IntPtr)sDllPath.Length, 12288u, 64u);
				if (intPtr2 == Injector.DllInjector.INTPTR_ZERO)
				{
					return false;
				}
				byte[] bytes = Encoding.ASCII.GetBytes(sDllPath);
				if (Injector.DllInjector.WriteProcessMemory(intPtr, intPtr2, bytes, (uint)bytes.Length, 0) == 0)
				{
					return false;
				}
				if (Injector.DllInjector.CreateRemoteThread(intPtr, (IntPtr)null, Injector.DllInjector.INTPTR_ZERO, procAddress, intPtr2, 0u, (IntPtr)null) == Injector.DllInjector.INTPTR_ZERO)
				{
					return false;
				}
				Injector.DllInjector.CloseHandle(intPtr);
				return true;
			}

			// Token: 0x04000060 RID: 96
			private static readonly IntPtr INTPTR_ZERO = (IntPtr)0;

			// Token: 0x04000061 RID: 97
			private static Injector.DllInjector _instance;
		}
	}
}
