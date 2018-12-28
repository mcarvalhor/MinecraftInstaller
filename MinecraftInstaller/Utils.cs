using System;
using System.IO;
using System.Text;
using System.Diagnostics;

namespace MinecraftInstaller
{
	class Utils
	{

		public static string checkUpdateURL = "http://isc.mcarvalhor.com/MinecraftInstaller/CheckUpdates?v=" + FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).FileVersion, // check update URL
			website = "http://isc.mcarvalhor.com/MinecraftInstaller", // official website
			devWebsite = "http://mcarvalhor.com/", // developer official website
			appWebsite = "http://minecraft.net/"; // app official website

		public const int maxCheckUpdateBytes = 1024 * 1024 * 5, // 5 MiB to check updates
			maxUpdateBytes = 1024 * 1024 * 100; // 100 MiB to download updates

		public static byte[] installApp = Properties.Resources.Shiginima_Launcher_SE, // app binary
			appSettings = Properties.Resources.launcher_profiles, // app setings
			appDefinitions = Properties.Resources.shig_inima; // app user definition

		public const string appSettingsPath = "launcher_profiles.json", // app settings file
			appDefinitionsPath = "shig.inima"; // app user definition file



		private static System.Resources.ResourceManager stringsRes = null;

		public static string GetString(string name)
		{
			string text;
			if (stringsRes == null)
			{
				switch(System.Globalization.CultureInfo.InstalledUICulture.TwoLetterISOLanguageName)
				{
					//case "en":
					case "pt":
						stringsRes = Strings.pt.ResourceManager ;
					break;
					//case "en":
					default:
						stringsRes = Strings.en.ResourceManager;
					break;
				}
			}
			text = stringsRes.GetString(name);
			if(text == null)
			{
				text = Strings.en.ResourceManager.GetString(name);
			}
			return text;
		}

		public static string GetPath()
		{
			string appsDir;

			appsDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
			appsDir = Path.Combine(appsDir, "MinecraftInstaller");

			return appsDir;
		}

		public static string GetInstallPath()
		{
			string appsDir;

			appsDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
			appsDir = Path.Combine(appsDir, "MinecraftInstaller", "Launcher.exe");

			return appsDir;
		}

		public static string GetAppPath()
		{
			string appsDir;

			appsDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
			appsDir = Path.Combine(appsDir, "MinecraftInstaller", "App.jar");

			return appsDir;
		}

		public static string GetAppFolder()
		{
			string appsDir;

			appsDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
			appsDir = Path.Combine(appsDir, ".minecraft");

			return appsDir;
		}

		public static string GetTempFile()
		{
			string tempDir;

			tempDir = Path.GetTempFileName();

			return tempDir;
		}

		public static bool IsInstalled()
		{
			FileVersionInfo installedAppVersion, myAppVersion;
			string appPath, runningPath;

			try
			{
				appPath = GetInstallPath();
				runningPath = System.Reflection.Assembly.GetExecutingAssembly().Location;
				if (!File.Exists(appPath))
				{
					Console.WriteLine("Já deu que não existe.");
					return false;
				}

				if (appPath.Equals(runningPath))
				{
					return true;
				}

				installedAppVersion = FileVersionInfo.GetVersionInfo(appPath);
				myAppVersion = FileVersionInfo.GetVersionInfo(runningPath);

				if (installedAppVersion != null && installedAppVersion.FileVersion.Equals(myAppVersion.FileVersion))
				{
					return true;
				}
			}
			catch (Exception exc)
			{
				Console.Error.WriteLine("Could not check whether is installed: " + exc.ToString());
			}

			return false;
		}

		public static bool Install(string userName, bool desktopIcon = false, string lang = "en")
		{
			string myAppPath, appPath, appFolder, installAppPath, desktopIconPath;
			StreamWriter desktopIconStream;

			try
			{
				myAppPath = System.Reflection.Assembly.GetExecutingAssembly().Location;
				installAppPath = GetInstallPath();
				appPath = GetPath();

				if(Directory.Exists(appPath))
				{
					try
					{
						Directory.Delete(appPath, true);
					} catch(Exception dirExc)
					{
						Console.Error.WriteLine("Could not remove install directory: " + dirExc.ToString());
					}
				}
				Directory.CreateDirectory(appPath);

				if (!myAppPath.Equals(installAppPath))
				{
					File.Copy(myAppPath, installAppPath, true);
				}

				appFolder = GetAppFolder();
				Directory.CreateDirectory(appFolder);
				File.WriteAllBytes(GetAppPath(), Utils.installApp);
				File.WriteAllBytes(Path.Combine(appFolder, Utils.appSettingsPath), Utils.appSettings);
				File.WriteAllBytes(Path.Combine(appFolder, Utils.appDefinitionsPath), Encoding.Default.GetBytes(String.Format(Encoding.Default.GetString(Utils.appDefinitions), userName, lang)));

				try
				{
					desktopIconPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), "Minecraft.url");
					desktopIconStream = new StreamWriter(desktopIconPath);
					desktopIconStream.WriteLine("[InternetShortcut]");
					desktopIconStream.WriteLine("URL=file:///" + installAppPath);
					desktopIconStream.WriteLine("IconIndex=0");
					desktopIconStream.WriteLine("IconFile=" + installAppPath.Replace('\\', '/'));
					desktopIconStream.Close();
				} catch(Exception iconExc)
				{
					Console.Error.WriteLine("Could not create desktop URL icon, copying EXE instead: " + iconExc.ToString());
					desktopIconPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), "Minecraft.exe");
					if(!myAppPath.Equals(desktopIconPath))
					{
						File.Copy(myAppPath, desktopIconPath, true);
					}
				}
			} catch (Exception exc)
			{
				Console.Error.WriteLine("Could not install: " + exc.ToString());
				return false;
			}

			return true;
		}

		public static bool Uninstall(bool desktopIcon = false)
		{
			string appPath, appFolder, desktopIconPath;

			try
			{
				appPath = GetPath();
				if (Directory.Exists(appPath))
				{
					try
					{
						Directory.Delete(appPath, true);
					}
					catch (Exception dirExc)
					{
						Console.Error.WriteLine("Could not remove install directory: " + dirExc.ToString());
					}
				}

				appFolder = GetAppFolder();
				if (Directory.Exists(appFolder))
				{
					try
					{
						Directory.Delete(appFolder, true);
					}
					catch (Exception dirExc)
					{
						Console.Error.WriteLine("Could not remove app folder: " + dirExc.ToString());
					}
				}

				if (desktopIcon)
				{
					desktopIconPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), "Minecraft.url");
					if (File.Exists(desktopIconPath))
					{
						File.Delete(desktopIconPath);
					}
					try
					{
						desktopIconPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), "Minecraft.exe");
						if (File.Exists(desktopIconPath))
						{
							File.Delete(desktopIconPath);
						}
					} catch(Exception iconExc)
					{
						Console.Error.WriteLine("Could not remove desktop EXE icon: " + iconExc.ToString());
					}
				}
			} catch(Exception exc)
			{
				Console.Error.WriteLine("Could not uninstall: " + exc.ToString());
				return false;
			}
			return true;
		}

	}
}
