using System;
using System.IO;
using System.IO.Pipes;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Ciris_V3
{
	// Token: 0x02000006 RID: 6
	internal class NamedPipes
	{
		// Token: 0x06000059 RID: 89
		[DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool WaitNamedPipe(string name, int timeout);

		// Token: 0x0600005A RID: 90 RVA: 0x0000731C File Offset: 0x0000551C
		public static bool NamedPipeExist(string pipeName)
		{
			bool result;
			try
			{
				int timeout = 0;
				if (!NamedPipes.WaitNamedPipe(Path.GetFullPath(string.Format("\\\\\\\\.\\\\pipe\\\\{0}", pipeName)), timeout))
				{
					int lastWin32Error = Marshal.GetLastWin32Error();
					if (lastWin32Error == 0)
					{
						result = false;
						return result;
					}
					if (lastWin32Error == 2)
					{
						result = false;
						return result;
					}
				}
				result = true;
			}
			catch (Exception)
			{
				result = false;
			}
			return result;
		}

		// Token: 0x0600005B RID: 91 RVA: 0x00007378 File Offset: 0x00005578
		public static void CommandPipe(string command)
		{
			if (NamedPipes.NamedPipeExist(NamedPipes.cmdpipe))
			{
				try
				{
					using (NamedPipeClientStream namedPipeClientStream = new NamedPipeClientStream(".", NamedPipes.cmdpipe, PipeDirection.Out))
					{
						namedPipeClientStream.Connect();
						using (StreamWriter streamWriter = new StreamWriter(namedPipeClientStream))
						{
							streamWriter.Write(command);
							streamWriter.Dispose();
						}
						namedPipeClientStream.Dispose();
					}
					return;
				}
				catch (IOException)
				{
					MessageBox.Show("Error occured connecting to the pipe.", "Connection Failed!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					return;
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message.ToString());
					return;
				}
			}
			MessageBox.Show("Inject " + Functions.exploitdll + " before Using this!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}

		// Token: 0x0600005C RID: 92 RVA: 0x0000745C File Offset: 0x0000565C
		public static void LuaCPipe(string script)
		{
			if (NamedPipes.NamedPipeExist(NamedPipes.scriptpipe))
			{
				try
				{
					using (NamedPipeClientStream namedPipeClientStream = new NamedPipeClientStream(".", NamedPipes.scriptpipe, PipeDirection.Out))
					{
						namedPipeClientStream.Connect();
						using (StreamWriter streamWriter = new StreamWriter(namedPipeClientStream))
						{
							streamWriter.Write(script);
							streamWriter.Dispose();
						}
						namedPipeClientStream.Dispose();
					}
					return;
				}
				catch (IOException)
				{
					MessageBox.Show("Error occured connecting to the pipe.", "Connection Failed!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					return;
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message.ToString());
					return;
				}
			}
			MessageBox.Show("Inject " + Functions.exploitdll + " before Using this!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}

		// Token: 0x0600005D RID: 93 RVA: 0x00007540 File Offset: 0x00005740
		public static void LuaPipe(string script)
		{
			if (NamedPipes.NamedPipeExist(NamedPipes.luapipe))
			{
				try
				{
					using (NamedPipeClientStream namedPipeClientStream = new NamedPipeClientStream(".", NamedPipes.luapipe, PipeDirection.Out))
					{
						namedPipeClientStream.Connect();
						using (StreamWriter streamWriter = new StreamWriter(namedPipeClientStream))
						{
							streamWriter.Write(script);
							streamWriter.Dispose();
						}
						namedPipeClientStream.Dispose();
					}
					return;
				}
				catch (IOException)
				{
					MessageBox.Show("Error occured connecting to the pipe.", "Connection Failed!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					return;
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message.ToString());
					return;
				}
			}
			MessageBox.Show("Inject " + Functions.exploitdll + " before Using this!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}

		// Token: 0x0400004B RID: 75
		public static string cmdpipe = "cobaltpipehax";

		// Token: 0x0400004C RID: 76
		public static string scriptpipe = "cobaltpipeehax";

		// Token: 0x0400004D RID: 77
		public static string luapipe = "cobaltpipeeehax";
	}
}
