
//#define DEBUG


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
			string text, osLang;
			if (stringsRes == null)
			{
				#if (DEBUG)
				Console.Error.WriteLine("== GetString FIRST CALL ==");
				#endif
				osLang = System.Globalization.CultureInfo.InstalledUICulture.TwoLetterISOLanguageName;
				#if (DEBUG)
				Console.Error.WriteLine("\tosLang = " + osLang);
				#endif
				switch (osLang)
				{
					case "pt":
						stringsRes = Strings.pt.ResourceManager;
						break;
					case "en":
					default:
						stringsRes = Strings.en.ResourceManager;
					break;
				}
				#if (DEBUG)
				Console.Error.WriteLine("LANG = " + stringsRes.BaseName);
				#endif
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

			#if (DEBUG)
			Console.Error.WriteLine("Path = " + appsDir);
			#endif

			return appsDir;
		}

		public static string GetInstallPath()
		{
			string appsDir;

			appsDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
			appsDir = Path.Combine(appsDir, "MinecraftInstaller", "Launcher.exe");

			#if (DEBUG)
			Console.Error.WriteLine("InstallPath = " + appsDir);
			#endif

			return appsDir;
		}

		public static string GetAppPath()
		{
			string appsDir;

			appsDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
			appsDir = Path.Combine(appsDir, "MinecraftInstaller", "App.jar");

			#if (DEBUG)
			Console.Error.WriteLine("AppPath = " + appsDir);
			#endif

			return appsDir;
		}

		public static string GetAppFolder()
		{
			string appsDir;

			appsDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
			appsDir = Path.Combine(appsDir, ".minecraft");

			#if (DEBUG)
			Console.Error.WriteLine("AppFolder = " + appsDir);
			#endif

			return appsDir;
		}

		public static string GetTempFile()
		{
			string tempFile;

			tempFile = Path.GetTempFileName();

			#if (DEBUG)
			Console.Error.WriteLine("TempFile = " + tempFile);
			#endif

			return tempFile;
		}

		public static bool IsInstalled()
		{
			FileVersionInfo installedAppVersion, myAppVersion;
			string appPath, runningPath;

			try
			{
				#if (DEBUG)
				Console.Error.WriteLine("== IsInstalled ==");
				#endif
				appPath = GetInstallPath();
				runningPath = System.Reflection.Assembly.GetExecutingAssembly().Location;
				#if (DEBUG)
				Console.Error.WriteLine("\tappPath = " + appPath);
				Console.Error.WriteLine("\trunningPath = " + runningPath);
				#endif

				if (!File.Exists(appPath))
				{
					#if (DEBUG)
					Console.Error.WriteLine("FALSE: appPath doesn't exist.");
					#endif
					return false;
				}

				if (appPath.Equals(runningPath))
				{
					#if (DEBUG)
					Console.Error.WriteLine("TRUE: appPath == runningPath.");
					#endif
					return true;
				}

				installedAppVersion = FileVersionInfo.GetVersionInfo(appPath);
				myAppVersion = FileVersionInfo.GetVersionInfo(runningPath);
				#if (DEBUG)
				Console.Error.WriteLine("\tinstalledAppVersion = " + installedAppVersion.FileVersion);
				Console.Error.WriteLine("\trunningAppVersion = " + myAppVersion.FileVersion);
				#endif

				if (installedAppVersion != null && installedAppVersion.FileVersion.Equals(myAppVersion.FileVersion))
				{
					#if (DEBUG)
					Console.Error.WriteLine("TRUE: installedAppVersion == runningAppVersion.");
					#endif
					return true;
				}
				#if (DEBUG)
				Console.Error.WriteLine("FALSE: installedAppVersion == null OR installedAppVersion != runningAppVersion.");
				#endif
			}
			catch (Exception exc)
			{
				#if (DEBUG)
				Console.Error.WriteLine("Could not check whether is installed: " + exc.ToString());
				#endif
			}

			return false;
		}

		public static bool Install(string userName, bool desktopIcon = false, string lang = "en")
		{
			string myAppPath, appPath, appFolder, installAppPath, desktopIconPath;
			StreamWriter desktopIconStream;

			try
			{
				#if (DEBUG)
				Console.Error.WriteLine("== Install ==");
				#endif
				myAppPath = System.Reflection.Assembly.GetExecutingAssembly().Location;
				installAppPath = GetInstallPath();
				appPath = GetPath();
				#if (DEBUG)
				Console.Error.WriteLine("\tpath = " + appPath);
				Console.Error.WriteLine("\tinstallPath = " + installAppPath);
				Console.Error.WriteLine("\trunningPath = " + myAppPath);
				#endif

				if (Directory.Exists(appPath))
				{
					#if (DEBUG)
					Console.Error.WriteLine("\tpath exists: removing it...");
					#endif
					try
					{
						Directory.Delete(appPath, true);
					} catch(Exception dirExc)
					{
						Console.Error.WriteLine("Could not remove install directory: " + dirExc.ToString());
					}
				}
				#if (DEBUG)
				Console.Error.WriteLine("\tCreating path directory...");
				#endif
				Directory.CreateDirectory(appPath);

				if (!myAppPath.Equals(installAppPath))
				{
					#if (DEBUG)
					Console.Error.WriteLine("\tinstallPath != runningPath: copying this runningPath program to installPath...");
					#endif
					File.Copy(myAppPath, installAppPath, true);
				}

				appFolder = GetAppFolder();
				#if (DEBUG)
				Console.Error.WriteLine("\tappFolder = " + appFolder);
				Console.Error.WriteLine("\tCreating appFolder directory...");
				#endif
				Directory.CreateDirectory(appFolder);
				#if (DEBUG)
				Console.Error.WriteLine("\tWriting game program...");
				#endif
				File.WriteAllBytes(GetAppPath(), Utils.installApp);
				#if (DEBUG)
				Console.Error.WriteLine("\tWriting game settings file...");
				#endif
				File.WriteAllBytes(Path.Combine(appFolder, Utils.appSettingsPath), Utils.appSettings);
				#if (DEBUG)
				Console.Error.WriteLine("\tWriting game definitions file...");
				#endif
				File.WriteAllBytes(Path.Combine(appFolder, Utils.appDefinitionsPath), Encoding.Default.GetBytes(String.Format(Encoding.Default.GetString(Utils.appDefinitions), userName, lang)));

				if (desktopIcon)
				{
					#if (DEBUG)
					Console.Error.WriteLine("\tCreating desktop icon...");
					#endif
					try
					{
						desktopIconPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), "Minecraft.url");
						#if (DEBUG)
						Console.Error.WriteLine("\tdesktopIconPath = " + desktopIconPath);
						Console.Error.WriteLine("\tWriting URL icon...");
						#endif
						desktopIconStream = new StreamWriter(desktopIconPath);
						desktopIconStream.WriteLine("[InternetShortcut]");
						desktopIconStream.WriteLine("URL=file:///" + installAppPath);
						desktopIconStream.WriteLine("IconIndex=0");
						desktopIconStream.WriteLine("IconFile=" + installAppPath.Replace('\\', '/'));
						desktopIconStream.Close();
					}
					catch (Exception iconExc)
					{
						#if (DEBUG)
						Console.Error.WriteLine("Could not create desktop URL icon: " + iconExc.ToString());
						#endif
						desktopIconPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), "Minecraft.exe");
						#if (DEBUG)
						Console.Error.WriteLine("\tCopying program EXE instead...");
						Console.Error.WriteLine("\tdesktopIconPath = " + desktopIconPath);
						#endif
						if (!myAppPath.Equals(desktopIconPath))
						{
							#if (DEBUG)
							Console.Error.WriteLine("\tdesktopIconPath != runningPath: copying...");
							#endif
							File.Copy(myAppPath, desktopIconPath, true);
						}
					}
				}
				#if (DEBUG)
				Console.Error.WriteLine("\tTRUE: success.");
				#endif
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
				#if (DEBUG)
				Console.Error.WriteLine("== Uninstall ==");
				#endif
				appPath = GetPath();
				#if (DEBUG)
				Console.Error.WriteLine("\tpath = " + appPath);
				#endif
				if (Directory.Exists(appPath))
				{
					#if (DEBUG)
					Console.Error.WriteLine("\tpath exists: removing it...");
					#endif
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
				#if (DEBUG)
				Console.Error.WriteLine("\tappFolder = " + appFolder);
				#endif
				if (Directory.Exists(appFolder))
				{
					#if (DEBUG)
					Console.Error.WriteLine("\tappFolder exists: removing it...");
					#endif
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
					#if (DEBUG)
					Console.Error.WriteLine("\tdesktopIconPath = " + desktopIconPath);
					#endif
					if (File.Exists(desktopIconPath))
					{
						#if (DEBUG)
						Console.Error.WriteLine("\tdesktopIconPath exists: removing it...");
						#endif
						File.Delete(desktopIconPath);
					}
					try
					{
						desktopIconPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), "Minecraft.exe");
						#if (DEBUG)
						Console.Error.WriteLine("\tdesktopIconPath = " + desktopIconPath);
						#endif
						if (File.Exists(desktopIconPath))
						{
							#if (DEBUG)
							Console.Error.WriteLine("\tdesktopIconPath exists: removing it...");
							#endif
							File.Delete(desktopIconPath);
						}
					} catch(Exception iconExc)
					{
						Console.Error.WriteLine("Could not remove desktop program EXE icon: " + iconExc.ToString());
					}
				}
				#if (DEBUG)
				Console.Error.WriteLine("TRUE: success.");
				#endif
			}
			catch (Exception exc)
			{
				Console.Error.WriteLine("Could not uninstall: " + exc.ToString());
				return false;
			}
			return true;
		}

		public static bool ImportProgress(string file)
		{
			string appFolder, tempFolder;
			Random rnd;

			try
			{
				#if (DEBUG)
				Console.Error.WriteLine("== ImportProgress ==");
				#endif
				rnd = new Random();
				appFolder = GetAppFolder();
				tempFolder = Path.Combine(Path.GetTempPath(), "MinecraftInstaller_" + rnd.Next());
				#if (DEBUG)
				Console.Error.WriteLine("\tappFolder = " + appFolder);
				Console.Error.WriteLine("\ttempFolder = " + tempFolder);
				#endif

				if (Directory.Exists(tempFolder))
				{
					#if (DEBUG)
					Console.Error.WriteLine("\ttempFolder exists: removing it...");
					#endif
					Directory.Delete(tempFolder, true);
				}

				#if (DEBUG)
				Console.Error.WriteLine("\tCreating tempFolder directory...");
				#endif
				Directory.CreateDirectory(tempFolder);
				#if (DEBUG)
				Console.Error.WriteLine("\tExtracting selected file into tempFolder...");
				#endif
				System.IO.Compression.ZipFile.ExtractToDirectory(file, tempFolder);
				#if (DEBUG)
				Console.Error.WriteLine("\tCreating appFolder...");
				#endif
				Directory.CreateDirectory(appFolder);
				#if (DEBUG)
				Console.Error.WriteLine("\tMerging files from tempFolder into appFolder...");
				#endif
				MergeDirectory(new DirectoryInfo(tempFolder), new DirectoryInfo(appFolder));
				#if (DEBUG)
				Console.Error.WriteLine("\tRemoving tempFolder...");
				#endif
				Directory.Delete(tempFolder, true);
				#if (DEBUG)
				Console.Error.WriteLine("TRUE: success.");
				#endif
			}
			catch (Exception exc)
			{
				Console.Error.WriteLine("Could not import progress: " + exc.ToString());
				return false;
			}

			return true;
		}

		public static bool ExportProgress(string file)
		{
			string appFolder, tempFile;

			try
			{
				#if (DEBUG)
				Console.Error.WriteLine("== ExportProgress ==");
				#endif
				appFolder = GetAppFolder();
				tempFile = GetTempFile();
				#if (DEBUG)
				Console.Error.WriteLine("\tappFolder = " + appFolder);
				Console.Error.WriteLine("\ttempFile = " + tempFile);
				#endif
				if(File.Exists(tempFile))
				{
					#if (DEBUG)
					Console.Error.WriteLine("\ttempFile exists: removing it...");
					#endif
					File.Delete(tempFile);
				}

				#if (DEBUG)
				Console.Error.WriteLine("\tCreating appFolder...");
				#endif
				Directory.CreateDirectory(appFolder);
				#if (DEBUG)
				Console.Error.WriteLine("\tCompressing from appFolder into tempFile...");
				#endif
				System.IO.Compression.ZipFile.CreateFromDirectory(appFolder, tempFile, System.IO.Compression.CompressionLevel.Optimal, false);
				#if (DEBUG)
				Console.Error.WriteLine("\tCopying tempFile into selected file...");
				#endif
				File.Copy(tempFile, file, true);
				#if (DEBUG)
				Console.Error.WriteLine("\tRemoving tempFile...");
				#endif
				File.Delete(tempFile);
				#if (DEBUG)
				Console.Error.WriteLine("TRUE: success.");
				#endif
			}
			catch (Exception exc)
			{
				Console.Error.WriteLine("Could not export progress: " + exc.ToString());
				return false;
			}

			return true;
		}

		public static void MergeDirectory(DirectoryInfo source, DirectoryInfo dest)
		{
			if(source.FullName.Equals(dest.FullName) || source.FullName.ToLower().Equals(dest.FullName.ToLower()))
			{
				return;
			}

			Directory.CreateDirectory(dest.FullName);

			foreach(FileInfo fi in source.GetFiles())
			{
				fi.CopyTo(Path.Combine(dest.ToString(), fi.Name), true);
			}

			foreach(DirectoryInfo di in source.GetDirectories())
			{
				MergeDirectory(di, dest.CreateSubdirectory(di.Name));
			}
		}

	}
}
