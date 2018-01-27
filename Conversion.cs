using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Ciris_V3
{
	// Token: 0x02000002 RID: 2
	internal class Conversion
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		public static string ConvertArgs(string argstring)
		{
			string[] array = argstring.Replace("(", "").Replace(")", "").Split(new char[]
			{
				','
			});
			string text = "";
			string[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				string text2 = array2[i].Trim();
				if (new Regex("\".+\"").IsMatch(text2))
				{
					string arg = text2.Replace("\"", "");
					text += string.Format("pushstring {0}\r\n", arg);
				}
				else if (double.TryParse(text2, out Conversion.Ignored<double>.Ignore))
				{
					string arg2 = text2.Replace("\"", "");
					text += string.Format("pushnumber {0}\r\n", arg2);
				}
				else if (bool.TryParse(text2, out Conversion.Ignored<bool>.Ignore))
				{
					string arg3 = text2.Replace("\"", "");
					text += string.Format("pushboolean {0}\r\n", arg3);
				}
			}
			return text;
		}

		// Token: 0x06000002 RID: 2 RVA: 0x00002150 File Offset: 0x00000350
		public static string ConvertString(string input)
		{
			string[] array = input.Split("\r\n".ToCharArray());
			string text = "";
			foreach (string text2 in array)
			{
				string[] array3 = text2.Split(new char[]
				{
					'.'
				});
				if (text2.Contains("="))
				{
					string[] array4 = text2.Split(new char[]
					{
						'='
					})[0].Trim().Split(new char[]
					{
						'.'
					});
					string[] array5 = text2.Split(new char[]
					{
						'='
					})[1].Trim().Split(new char[]
					{
						'.'
					});
					bool flag = false;
					string argstring = "";
					foreach (string text3 in array5)
					{
						if (array5.Length == 1)
						{
							flag = true;
							argstring = text3;
							break;
						}
						if (text3 == "")
						{
							text += "\b\r\n";
						}
						else if (text3.Contains(':') && text3 == array5.First<string>())
						{
							string[] array7 = text3.Split(new char[]
							{
								':'
							});
							foreach (string text4 in array7)
							{
								text = ((!(text4 == array7.First<string>())) ? (text + string.Format("getfield -1, {0}\r\n", Regex.Replace(text4, "\\(([^)]*)\\)", ""))) : (text + string.Format("getglobal {0}\r\n", Regex.Replace(text4, "\\(([^)]*)\\)", ""))));
								if (text4.Contains("()"))
								{
									text += "pushvalue -2\r\npcall 1 1 0\r\n";
								}
								else if (Regex.IsMatch(text4, "\\(([^)]*)\\)"))
								{
									text = text + "pushvalue -2\r\n" + Conversion.ConvertArgs(Regex.Match(text4, "\\(([^)]*)\\)").ToString()) + string.Format("pcall {0} 1 0\r\n", Regex.Match(text4, "\\(([^)]*)\\)").ToString().Split(new char[]
									{
										','
									}).Length + 1);
								}
							}
						}
						else if (text3.Contains(':'))
						{
							string text5 = text3;
							char[] separator = new char[]
							{
								':'
							};
							foreach (string text6 in text5.Split(separator))
							{
								text += string.Format("getfield -1 {0}\r\n", Regex.Replace(text6, "\\(([^)]*)\\)", ""));
								if (text6.Contains("()"))
								{
									text += "pushvalue -2\r\npcall 1 1 0\r\n";
								}
								else if (Regex.IsMatch(text6, "\\(([^)]*)\\)"))
								{
									text = text + "pushvalue -2\r\n" + Conversion.ConvertArgs(Regex.Match(text6, "\\(([^)]*)\\)").ToString()) + string.Format("pcall {0} 1 0\r\n", Regex.Match(text6, "\\(([^)]*)\\)").ToString().Split(new char[]
									{
										','
									}).Length + 1);
								}
							}
						}
						else
						{
							text = ((!(text3 == array5.First<string>())) ? (text + string.Format("getfield -1 {0}\r\n", Regex.Replace(text3, "\\(([^)]*)\\)", ""))) : (text + string.Format("getglobal {0}\r\n", Regex.Replace(text3, "\\(([^)]*)\\)", ""))));
							if (text3.Contains("()"))
							{
								text += "pcall 1 1 0\r\n";
							}
							else if (Regex.IsMatch(text3, "\\(([^)]*)\\)"))
							{
								text = text + Conversion.ConvertArgs(Regex.Match(text3, "\\(([^)]*)\\)").ToString()) + string.Format("pcall {0} 1 0\r\n", Regex.Match(text3, "\\(([^)]*)\\)").ToString().Split(new char[]
								{
									','
								}).Length);
							}
						}
					}
					int num = 0;
					foreach (string text7 in array4)
					{
						if (text7 == "")
						{
							text += "\b\r\n";
						}
						else
						{
							num++;
							if (text7 == array4.Last<string>())
							{
								text = ((!flag) ? (text + string.Format("pushvalue -{0}\r\n", num) + string.Format("setfield -2 {0}\r\n", array4.Last<string>().Trim())) : (text + Conversion.ConvertArgs(argstring) + string.Format("setfield -2 {0}\r\n", array4.Last<string>().Trim())));
							}
							else if (text7.Contains(':') && text7 == array4.First<string>())
							{
								string[] array9 = text7.Split(new char[]
								{
									':'
								});
								foreach (string text8 in array9)
								{
									text = ((!(text8 == array9.First<string>())) ? (text + string.Format("getfield -1 {0}\r\n", Regex.Replace(text8, "\\(([^)]*)\\)", ""))) : (text + string.Format("getglobal {0}\r\n", Regex.Replace(text8, "\\(([^)]*)\\)", ""))));
									if (text8.Contains("()"))
									{
										text += "pushvalue -2\r\npcall 1 1 0\r\n";
									}
									else if (Regex.IsMatch(text8, "\\(([^)]*)\\)"))
									{
										text = text + "pushvalue -2 \r\n" + Conversion.ConvertArgs(Regex.Match(text8, "\\(([^)]*)\\)").ToString()) + string.Format("pcall {0} 1 0)\r\n", Regex.Match(text8, "\\(([^)]*)\\)").ToString().Split(new char[]
										{
											','
										}).Length + 1);
									}
								}
							}
							else if (text7.Contains(':'))
							{
								string text9 = text7;
								char[] separator2 = new char[]
								{
									':'
								};
								foreach (string text10 in text9.Split(separator2))
								{
									text += string.Format("getfield -1 {0}\r\n", Regex.Replace(text10, "\\(([^)]*)\\)", ""));
									if (text10.Contains("()"))
									{
										text += "pushvalue -2\r\npcall 1 1 0\r\n";
									}
									else if (Regex.IsMatch(text10, "\\(([^)]*)\\)"))
									{
										text = text + "pushvalue -2 \r\n" + Conversion.ConvertArgs(Regex.Match(text10, "\\(([^)]*)\\)").ToString()) + string.Format("pcall {0} 1 0\r\n", Regex.Match(text10, "\\(([^)]*)\\)").ToString().Split(new char[]
										{
											','
										}).Length + 1);
									}
								}
							}
							else
							{
								text = ((!(text7 == array4.First<string>())) ? (text + string.Format("getfield -1 {0}\r\n", Regex.Replace(text7, "\\(([^)]*)\\)", ""))) : (text + string.Format("getglobal {0}\r\n", Regex.Replace(text7, "\\(([^)]*)\\)", ""))));
								if (text7.Contains("()"))
								{
									text += "pcall 1 1 0\r\n";
								}
								else if (Regex.IsMatch(text7, "\\(([^)]*)\\)"))
								{
									text = text + Conversion.ConvertArgs(Regex.Match(text7, "\\(([^)]*)\\)").ToString()) + string.Format("pcall {0} 1 0\r\n", Regex.Match(text7, "\\(([^)]*)\\)").ToString().Split(new char[]
									{
										','
									}).Length);
								}
							}
						}
					}
				}
				else
				{
					foreach (string text11 in array3)
					{
						if (text11 == "")
						{
							text += "\b\r\n";
						}
						else if (text11.Contains(':') && text11 == array3.First<string>())
						{
							string[] array10 = text11.Split(new char[]
							{
								':'
							});
							foreach (string text12 in array10)
							{
								text = ((!(text12 == array10.First<string>())) ? (text + string.Format("getfield -1 {0}\r\n", Regex.Replace(text12, "\\(([^)]*)\\)", ""))) : (text + string.Format("getglobal {0}\r\n", Regex.Replace(text12, "\\(([^)]*)\\)", ""))));
								if (text12.Contains("()"))
								{
									text += "pushvalue -2\r\npcall 1 1 0)\r\n";
								}
								else if (Regex.IsMatch(text12, "\\(([^)]*)\\)"))
								{
									text = text + "pushvalue -2\r\n" + Conversion.ConvertArgs(Regex.Match(text12, "\\(([^)]*)\\)").ToString()) + string.Format("pcall {0} 1 0\r\n", Regex.Match(text12, "\\(([^)]*)\\)").ToString().Split(new char[]
									{
										','
									}).Length + 1);
								}
							}
						}
						else if (text11.Contains(':'))
						{
							string text13 = text11;
							char[] separator3 = new char[]
							{
								':'
							};
							foreach (string text14 in text13.Split(separator3))
							{
								text += string.Format("getfield -1 {0}\r\n", Regex.Replace(text14, "\\(([^)]*)\\)", ""));
								if (text14.Contains("()"))
								{
									text += "pushvalue -2\r\npcall 1 1 0\r\n";
								}
								else if (Regex.IsMatch(text14, "\\(([^)]*)\\)"))
								{
									text = text + "pushvalue -2\r\n" + Conversion.ConvertArgs(Regex.Match(text14, "\\(([^)]*)\\)").ToString()) + string.Format("pcall {0} 1 0\r\n", Regex.Match(text14, "\\(([^)]*)\\)").ToString().Split(new char[]
									{
										','
									}).Length + 1);
								}
							}
						}
						else
						{
							text = ((!(text11 == array3.First<string>())) ? (text + string.Format("getfield -1 {0}\r\n", Regex.Replace(text11, "\\(([^)]*)\\)", ""))) : (text + string.Format("getglobal {0}\r\n", Regex.Replace(text11, "\\(([^)]*)\\)", ""))));
							if (text11.Contains("()"))
							{
								text += "pcall 1 1 0 \r\n";
							}
							else if (Regex.IsMatch(text11, "\\(([^)]*)\\)"))
							{
								text = text + Conversion.ConvertArgs(Regex.Match(text11, "\\(([^)]*)\\)").ToString()) + string.Format("pcall {0} 1 0\r\n", Regex.Match(text11, "\\(([^)]*)\\)").ToString().Split(new char[]
								{
									','
								}).Length);
							}
						}
					}
				}
			}
			return text;
		}

		// Token: 0x0200000B RID: 11
		public static class Ignored<T>
		{
			// Token: 0x04000052 RID: 82
			[ThreadStatic]
			public static T Ignore;
		}
	}
}
