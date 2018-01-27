using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bunifu.Framework.UI;
using Ciris_V3.Properties;
using FastColoredTextBoxNS;
using Teen;
using WeAreDevs_API;

namespace Ciris_V3
{
	// Token: 0x02000003 RID: 3
	public partial class Form1 : Form
	{
		// Token: 0x06000004 RID: 4 RVA: 0x00002C44 File Offset: 0x00000E44
		public Form1()
		{
			this.InitializeComponent();
			this.components = new Container();
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(Form1));
			this.fastColoredTextBox1.AutoIndentCharsPatterns = "\r\n^\\s*[\\w\\.]+(\\s\\w+)?\\s*(?<range>=)\\s*(?<range>.+)\r\n";
			this.fastColoredTextBox1.BackBrush = null;
			this.fastColoredTextBox1.BackColor = Color.FromArgb(35, 35, 35);
			this.fastColoredTextBox1.BookmarkColor = Color.FromArgb(35, 35, 35);
			this.fastColoredTextBox1.BracketsHighlightStrategy = BracketsHighlightStrategy.Strategy2;
			this.fastColoredTextBox1.CaretColor = Color.Fuchsia;
			this.fastColoredTextBox1.CharHeight = 14;
			this.fastColoredTextBox1.CharWidth = 8;
			this.fastColoredTextBox1.CommentPrefix = "--";
			this.fastColoredTextBox1.Cursor = Cursors.IBeam;
			this.fastColoredTextBox1.DisabledColor = Color.FromArgb(100, 180, 180, 180);
			this.fastColoredTextBox1.FoldingIndicatorColor = Color.Fuchsia;
			this.fastColoredTextBox1.Font = new Font("Courier New", 9.75f);
			this.fastColoredTextBox1.ForeColor = Color.Fuchsia;
			this.fastColoredTextBox1.IndentBackColor = Color.FromArgb(35, 35, 40);
			this.fastColoredTextBox1.IsReplaceMode = false;
			this.fastColoredTextBox1.Language = Language.Lua;
			this.fastColoredTextBox1.LeftBracket = '(';
			this.fastColoredTextBox1.LeftBracket2 = '{';
			this.fastColoredTextBox1.LineNumberColor = Color.Fuchsia;
			this.fastColoredTextBox1.Name = "fastColoredTextBox1";
			this.fastColoredTextBox1.Paddings = new Padding(0);
			this.fastColoredTextBox1.RightBracket = ')';
			this.fastColoredTextBox1.RightBracket2 = '}';
			this.fastColoredTextBox1.SelectionColor = Color.FromArgb(60, 255, 0, 255);
			this.fastColoredTextBox1.ServiceColors = (ServiceColors)componentResourceManager.GetObject("fastColoredTextBox1.ServiceColors");
			this.OnStart();
		}

		// Token: 0x06000005 RID: 5
		[DllImport("user32.dll")]
		public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

		// Token: 0x06000006 RID: 6
		[DllImport("user32.dll")]
		public static extern bool ReleaseCapture();

		// Token: 0x06000007 RID: 7 RVA: 0x00002E4C File Offset: 0x0000104C
		private void button1_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x06000008 RID: 8 RVA: 0x00002E54 File Offset: 0x00001054
		private void button2_Click(object sender, EventArgs e)
		{
			base.WindowState = FormWindowState.Minimized;
		}

		// Token: 0x06000009 RID: 9 RVA: 0x00002E5D File Offset: 0x0000105D
		private void button3_Click(object sender, EventArgs e)
		{
			this.tabControl1.SelectedIndex = 0;
		}

		// Token: 0x0600000A RID: 10 RVA: 0x00002E6B File Offset: 0x0000106B
		private void button4_Click(object sender, EventArgs e)
		{
			this.tabControl1.SelectedIndex = 1;
		}

		// Token: 0x0600000B RID: 11 RVA: 0x00002E5D File Offset: 0x0000105D
		private void button8_Click(object sender, EventArgs e)
		{
			this.tabControl1.SelectedIndex = 0;
		}

		// Token: 0x0600000C RID: 12 RVA: 0x00002E6B File Offset: 0x0000106B
		private void button9_Click(object sender, EventArgs e)
		{
			this.tabControl1.SelectedIndex = 1;
		}

		// Token: 0x0600000D RID: 13 RVA: 0x00002E79 File Offset: 0x00001079
		private void tabPage2_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x0600000E RID: 14 RVA: 0x00002E7B File Offset: 0x0000107B
		private void tabPage2_MouseDown(object sender, MouseEventArgs e)
		{
			Form1.ReleaseCapture();
			Form1.SendMessage(base.Handle, 161, 2, 0);
		}

		// Token: 0x0600000F RID: 15 RVA: 0x00002E7B File Offset: 0x0000107B
		private void tabControl1_MouseDown(object sender, MouseEventArgs e)
		{
			Form1.ReleaseCapture();
			Form1.SendMessage(base.Handle, 161, 2, 0);
		}

		// Token: 0x06000010 RID: 16 RVA: 0x00002E7B File Offset: 0x0000107B
		private void tabPage1_MouseDown(object sender, MouseEventArgs e)
		{
			Form1.ReleaseCapture();
			Form1.SendMessage(base.Handle, 161, 2, 0);
		}

		// Token: 0x06000011 RID: 17 RVA: 0x00002E7B File Offset: 0x0000107B
		private void panel1_MouseDown(object sender, MouseEventArgs e)
		{
			Form1.ReleaseCapture();
			Form1.SendMessage(base.Handle, 161, 2, 0);
		}

		// Token: 0x06000012 RID: 18 RVA: 0x00002E7B File Offset: 0x0000107B
		private void panel2_MouseDown(object sender, MouseEventArgs e)
		{
			Form1.ReleaseCapture();
			Form1.SendMessage(base.Handle, 161, 2, 0);
		}

		// Token: 0x06000013 RID: 19 RVA: 0x00002E98 File Offset: 0x00001098
		private void button5_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Filter = "Text files (*.txt)|*.txt|Lua files (*.lua)|*.lua|All files (*.*)|*.*";
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				this.fastColoredTextBox1.Text = File.ReadAllText(openFileDialog.FileName);
			}
			openFileDialog.FileName = "";
		}

		// Token: 0x06000014 RID: 20 RVA: 0x00002EE0 File Offset: 0x000010E0
		private void button7_Click(object sender, EventArgs e)
		{
			this.fastColoredTextBox1.Text = "";
		}

		// Token: 0x06000015 RID: 21 RVA: 0x00002EF2 File Offset: 0x000010F2
		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{
			base.TopMost = !base.TopMost;
		}

		// Token: 0x06000016 RID: 22 RVA: 0x00002F04 File Offset: 0x00001104
		private void Form1_Load(object sender, EventArgs e)
		{
			Process.Start("https://discord.gg/55hjYgY");
			Process.Start("https://WeAreDevs.net");
			if (!new WebClient().DownloadString("https://pastebin.com/xrTCJXpw").Contains("v4.0.1"))
			{
				MessageBox.Show("Update Found!", "Ciris Rewrite");
				MessageBox.Show("Click OK to download the latest version!", "Ciris Rewrite");
				Process.Start("https://wearedevs.net/download.php?softwareName=Ciris");
				Thread.Sleep(200);
				base.Close();
			}
		}

		// Token: 0x06000017 RID: 23 RVA: 0x00002F80 File Offset: 0x00001180
		private async void button20_Click(object sender, EventArgs e)
		{
			if (NamedPipes.NamedPipeExist(NamedPipes.scriptpipe))
			{
				this.label9.Text = "Already Injected!";
				await Task.Delay(3000);
				this.label9.Text = "Injected!";
			}
			else if (!NamedPipes.NamedPipeExist(NamedPipes.scriptpipe))
			{
				switch (Injector.DllInjector.GetInstance.Inject("RobloxPlayerBeta", AppDomain.CurrentDomain.BaseDirectory + Functions.exploitdll))
				{
				case Injector.DllInjectionResult.DllNotFound:
					this.label9.Text = "DLL Not Found!";
					await Task.Delay(3000);
					this.label9.Text = "Injection Failed!";
					break;
				case Injector.DllInjectionResult.GameProcessNotFound:
					this.label9.Text = "Roblox Process not Found!";
					await Task.Delay(3000);
					this.label9.Text = "Injection Failed!";
					break;
				case Injector.DllInjectionResult.InjectionFailed:
					this.label9.Text = "Injection Failed!";
					break;
				default:
					this.label9.Text = "Injecting...";
					await Task.Delay(4000);
					if (NamedPipes.NamedPipeExist(NamedPipes.scriptpipe))
					{
						this.label9.Text = "Injected!";
					}
					else
					{
						this.label9.Text = "Injection Failed!";
					}
					break;
				}
			}
		}

		// Token: 0x06000018 RID: 24 RVA: 0x00002E79 File Offset: 0x00001079
		private void button21_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x06000019 RID: 25 RVA: 0x00002E79 File Offset: 0x00001079
		private void pictureBox2_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x0600001A RID: 26 RVA: 0x00002EF2 File Offset: 0x000010F2
		private void checkBox2_CheckedChanged(object sender, EventArgs e)
		{
			base.TopMost = !base.TopMost;
		}

		// Token: 0x0600001B RID: 27 RVA: 0x00002E79 File Offset: 0x00001079
		private void button22_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x0600001C RID: 28 RVA: 0x00002E79 File Offset: 0x00001079
		private void fastColoredTextBox1_Load(object sender, EventArgs e)
		{
		}

		// Token: 0x0600001D RID: 29 RVA: 0x00002FBC File Offset: 0x000011BC
		private void button6_Click(object sender, EventArgs e)
		{
			if (!NamedPipes.NamedPipeExist(NamedPipes.luapipe))
			{
				this.fastColoredTextBox1.Text = "";
				MessageBox.Show(" Fam Did you even Inject " + Functions.exploitdll + " ??", "Nop!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			NamedPipes.LuaPipe(this.fastColoredTextBox1.Text);
		}

		// Token: 0x0600001E RID: 30 RVA: 0x00002E54 File Offset: 0x00001054
		private void button25_Click(object sender, EventArgs e)
		{
			base.WindowState = FormWindowState.Minimized;
		}

		// Token: 0x0600001F RID: 31 RVA: 0x00002E4C File Offset: 0x0000104C
		private void button24_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x06000020 RID: 32 RVA: 0x00002E4C File Offset: 0x0000104C
		private void button27_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x06000021 RID: 33 RVA: 0x00002E54 File Offset: 0x00001054
		private void button28_Click(object sender, EventArgs e)
		{
			base.WindowState = FormWindowState.Minimized;
		}

		// Token: 0x06000022 RID: 34 RVA: 0x00003018 File Offset: 0x00001218
		private void button29_Click(object sender, EventArgs e)
		{
			this.tabControl1.SelectedIndex = 2;
		}

		// Token: 0x06000023 RID: 35 RVA: 0x00002E79 File Offset: 0x00001079
		private void tabPage3_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x06000024 RID: 36 RVA: 0x00002EF2 File Offset: 0x000010F2
		private void checkBox3_CheckedChanged(object sender, EventArgs e)
		{
			base.TopMost = !base.TopMost;
		}

		// Token: 0x06000025 RID: 37 RVA: 0x00002E79 File Offset: 0x00001079
		private void button23_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x06000026 RID: 38 RVA: 0x00003018 File Offset: 0x00001218
		private void button34_Click(object sender, EventArgs e)
		{
			this.tabControl1.SelectedIndex = 2;
		}

		// Token: 0x06000027 RID: 39 RVA: 0x00003028 File Offset: 0x00001228
		private void button26_Click(object sender, EventArgs e)
		{
			if (NamedPipes.NamedPipeExist(NamedPipes.scriptpipe))
			{
				foreach (string script in this.fastColoredTextBox1.Text.Split("\r\n".ToCharArray()))
				{
					try
					{
						NamedPipes.LuaCPipe(script);
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message.ToString());
					}
				}
				return;
			}
			MessageBox.Show("Fam Cmon you know you need to inject " + Functions.exploitdll + " Because then I will not work ok?! Or end me if i don't work and try me again", "Nop", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}

		// Token: 0x06000028 RID: 40 RVA: 0x000030BC File Offset: 0x000012BC
		private void button33_Click(object sender, EventArgs e)
		{
			if (!NamedPipes.NamedPipeExist(NamedPipes.scriptpipe))
			{
				this.thirteenTextBox2.Text = "";
				MessageBox.Show(" Fam Did you even Inject " + Functions.exploitdll + " ??", "Nop!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			if (this.thirteenTextBox2.Text == "cmds")
			{
				this.fastColoredTextBox2.AppendText(Functions.TextToBox[0]);
				return;
			}
			NamedPipes.CommandPipe(this.thirteenTextBox2.Text);
		}

		// Token: 0x06000029 RID: 41 RVA: 0x00002E5D File Offset: 0x0000105D
		private void button30_Click(object sender, EventArgs e)
		{
			this.tabControl1.SelectedIndex = 0;
		}

		// Token: 0x0600002A RID: 42 RVA: 0x00002E6B File Offset: 0x0000106B
		private void button31_Click(object sender, EventArgs e)
		{
			this.tabControl1.SelectedIndex = 1;
		}

		// Token: 0x0600002B RID: 43 RVA: 0x00003018 File Offset: 0x00001218
		private void button32_Click(object sender, EventArgs e)
		{
			this.tabControl1.SelectedIndex = 2;
		}

		// Token: 0x0600002C RID: 44 RVA: 0x00002E79 File Offset: 0x00001079
		private void fastColoredTextBox2_Load(object sender, EventArgs e)
		{
		}

		// Token: 0x0600002D RID: 45 RVA: 0x00002E79 File Offset: 0x00001079
		private void checkBox4_CheckedChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x0600002E RID: 46 RVA: 0x00002E79 File Offset: 0x00001079
		private void button10_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x0600002F RID: 47 RVA: 0x00002E79 File Offset: 0x00001079
		private void button15_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x06000030 RID: 48 RVA: 0x00002E79 File Offset: 0x00001079
		private void button11_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x06000031 RID: 49 RVA: 0x00002E79 File Offset: 0x00001079
		private void button16_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x06000032 RID: 50 RVA: 0x00002E79 File Offset: 0x00001079
		private void button19_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x06000033 RID: 51 RVA: 0x00002E79 File Offset: 0x00001079
		private void button12_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x06000034 RID: 52 RVA: 0x00002E79 File Offset: 0x00001079
		private void button17_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x06000035 RID: 53 RVA: 0x00002E79 File Offset: 0x00001079
		private void button14_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x06000036 RID: 54 RVA: 0x00003142 File Offset: 0x00001342
		private void button13_Click(object sender, EventArgs e)
		{
			NamedPipes.CommandPipe("sparkles " + this.thirteenTextBox1.Text);
		}

		// Token: 0x06000037 RID: 55 RVA: 0x00002E79 File Offset: 0x00001079
		private void button18_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x06000038 RID: 56 RVA: 0x00002E79 File Offset: 0x00001079
		private void button35_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x06000039 RID: 57 RVA: 0x00002E79 File Offset: 0x00001079
		private void button36_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x0600003A RID: 58 RVA: 0x00002E79 File Offset: 0x00001079
		private void button37_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x0600003B RID: 59 RVA: 0x00002E79 File Offset: 0x00001079
		private void button38_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x0600003C RID: 60 RVA: 0x00002E79 File Offset: 0x00001079
		private void button39_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x0600003D RID: 61 RVA: 0x00002E79 File Offset: 0x00001079
		private void button40_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x0600003E RID: 62 RVA: 0x0000315E File Offset: 0x0000135E
		private void button40_Click_1(object sender, EventArgs e)
		{
			this.tabControl1.SelectedIndex = 3;
		}

		// Token: 0x0600003F RID: 63 RVA: 0x00002E79 File Offset: 0x00001079
		private void button42_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x06000040 RID: 64 RVA: 0x0000316C File Offset: 0x0000136C
		private void button21_Click_1(object sender, EventArgs e)
		{
			foreach (Process process in Process.GetProcesses())
			{
				if (process.ProcessName == "RobloxPlayerBeta")
				{
					process.Kill();
				}
			}
		}

		// Token: 0x06000041 RID: 65 RVA: 0x00002E4C File Offset: 0x0000104C
		private void button43_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x06000042 RID: 66 RVA: 0x00002E54 File Offset: 0x00001054
		private void button41_Click(object sender, EventArgs e)
		{
			base.WindowState = FormWindowState.Minimized;
		}

		// Token: 0x06000043 RID: 67 RVA: 0x00002E5D File Offset: 0x0000105D
		private void button42_Click_1(object sender, EventArgs e)
		{
			this.tabControl1.SelectedIndex = 0;
		}

		// Token: 0x06000044 RID: 68 RVA: 0x000031A9 File Offset: 0x000013A9
		public static bool IsRunning(string name)
		{
			return Process.GetProcessesByName(name).Length != 0;
		}

		// Token: 0x06000045 RID: 69 RVA: 0x000031B8 File Offset: 0x000013B8
		public async void OnStart()
		{
			this.label9.Text = "Waiting For ROBLOX";
			for (;;)
			{
				await Task.Delay(200);
				if (!NamedPipes.NamedPipeExist(NamedPipes.scriptpipe) || Form1.IsRunning("RobloxPlayerBeta"))
				{
					if (Form1.IsRunning("RobloxPlayerBeta"))
					{
						if (NamedPipes.NamedPipeExist(NamedPipes.scriptpipe) && Form1.IsRunning("RobloxPlayerBeta"))
						{
							break;
						}
						this.label9.Text = "Ready to Inject!";
					}
					else
					{
						this.label9.Text = "Waiting For ROBLOX";
					}
				}
			}
		}

		// Token: 0x06000046 RID: 70 RVA: 0x00002E79 File Offset: 0x00001079
		private void button44_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x06000047 RID: 71 RVA: 0x00002E79 File Offset: 0x00001079
		private void panel1_Paint(object sender, PaintEventArgs e)
		{
		}

		// Token: 0x06000048 RID: 72 RVA: 0x00002E79 File Offset: 0x00001079
		private void thirteenTextBox1_TextChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x06000049 RID: 73 RVA: 0x00002E79 File Offset: 0x00001079
		private void thirteenTextBox3_TextChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x0600004A RID: 74 RVA: 0x000031F4 File Offset: 0x000013F4
		private void button10_Click_1(object sender, EventArgs e)
		{
			int num = this.a;
			if (num != 0)
			{
				if (num == 1)
				{
					NamedPipes.CommandPipe("clicktpon");
					this.button10.Text = "ClickTP Currently ON!";
					this.a--;
					return;
				}
			}
			else
			{
				NamedPipes.CommandPipe("clicktpoff");
				this.button10.Text = "ClickTP Currently OFF!";
				this.a++;
			}
		}

		// Token: 0x0600004B RID: 75 RVA: 0x00003260 File Offset: 0x00001460
		private void button11_Click_1(object sender, EventArgs e)
		{
			this.fastColoredTextBox1.Text = Conversion.ConvertString(this.fastColoredTextBox1.Text);
		}

		// Token: 0x0600004C RID: 76 RVA: 0x0000327D File Offset: 0x0000147D
		private void button12_Click_1(object sender, EventArgs e)
		{
			NamedPipes.CommandPipe("smoke " + this.thirteenTextBox1.Text);
		}

		// Token: 0x0600004D RID: 77 RVA: 0x00003299 File Offset: 0x00001499
		private void button14_Click_1(object sender, EventArgs e)
		{
			NamedPipes.CommandPipe("fire " + this.thirteenTextBox1.Text);
		}

		// Token: 0x0600004E RID: 78 RVA: 0x000032B5 File Offset: 0x000014B5
		private void button15_Click_1(object sender, EventArgs e)
		{
			NamedPipes.CommandPipe("kill " + this.thirteenTextBox1.Text);
		}

		// Token: 0x0600004F RID: 79 RVA: 0x000032D1 File Offset: 0x000014D1
		private void button16_Click_1(object sender, EventArgs e)
		{
			NamedPipes.CommandPipe("jp " + this.thirteenTextBox1.Text + " " + this.thirteenTextBox3.Text);
		}

		// Token: 0x06000050 RID: 80 RVA: 0x000032FD File Offset: 0x000014FD
		private void button17_Click_1(object sender, EventArgs e)
		{
			NamedPipes.CommandPipe("ws " + this.thirteenTextBox1.Text + " " + this.thirteenTextBox3.Text);
		}

		// Token: 0x06000051 RID: 81 RVA: 0x00003329 File Offset: 0x00001529
		private void button18_Click_1(object sender, EventArgs e)
		{
			NamedPipes.CommandPipe("bigfire " + this.thirteenTextBox1.Text);
		}

		// Token: 0x06000052 RID: 82 RVA: 0x00003345 File Offset: 0x00001545
		private void button19_Click_1(object sender, EventArgs e)
		{
			NamedPipes.CommandPipe("btools " + this.thirteenTextBox1.Text);
		}

		// Token: 0x04000001 RID: 1
		private ExploitAPI api = new ExploitAPI();

		// Token: 0x04000002 RID: 2
		public const int WM_NCLBUTTONDOWN = 161;

		// Token: 0x04000003 RID: 3
		public const int HT_CAPTION = 2;

		// Token: 0x04000004 RID: 4
		private int a;
	}
}
