﻿using System;
using System.Windows.Forms;
using Tao.Sdl;

namespace OpenBve {
	/// <summary>Provides methods for starting the program, including the Main procedure.</summary>
	internal static partial class Program {

		// --- members ---

		/// <summary>Whether the program is currently running on Mono. This is of interest for the Windows Forms main menu which behaves differently on Mono than on Microsoft .NET.</summary>
		internal static bool CurrentlyRunningOnMono = false;
		
		/// <summary>Whether the program is currently running on Microsoft Windows or compatible. This is of interest for whether running Win32 plugins is possible.</summary>
		internal static bool CurrentlyRunningOnWindows = false;

		/// <summary>The host API used by this program.</summary>
		internal static Host CurrentHost = null;

		/// <summary>Information about the file system organization.</summary>
		internal static FileSystem FileSystem = null;
		
		/// <summary>If the program is to be restarted, this contains the command-line arguments that should be passed to the process, or a null reference otherwise.</summary>
		internal static string RestartArguments = null;

		
		// --- functions ---
		
		/// <summary>Is executed when the program starts.</summary>
		/// <param name="args">The command-line arguments.</param>
		[STAThread]
		private static void Main(string[] args) {
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			// --- determine the running environment and initialize the members ---
			CurrentlyRunningOnMono = Type.GetType("Mono.Runtime") != null;
			CurrentlyRunningOnWindows = Environment.OSVersion.Platform == PlatformID.Win32S | Environment.OSVersion.Platform == PlatformID.Win32Windows | Environment.OSVersion.Platform == PlatformID.Win32NT;
			CurrentHost = new Host();
			try {
				FileSystem = FileSystem.FromCommandLineArgs(args);
				FileSystem.CreateFileSystem();
			} catch (Exception ex) {
				MessageBox.Show("The file system configuration could not be accessed or is invalid due to the following reason:\n\n" + ex.Message, "openBVE", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return;
			}
			// --- check the command-line arguments for route and train ---
			formMain.MainDialogResult result = new formMain.MainDialogResult();
			for (int i = 0; i < args.Length; i++) {
				if (args[i].StartsWith("/route=", StringComparison.OrdinalIgnoreCase)) {
					result.RouteFile = args[i].Substring(7);
					result.RouteEncoding = System.Text.Encoding.UTF8;
					for (int j = 0; j < Interface.CurrentOptions.RouteEncodings.Length; j++) {
						if (string.Compare(Interface.CurrentOptions.RouteEncodings[j].Value, result.RouteFile, StringComparison.InvariantCultureIgnoreCase) == 0) {
							result.RouteEncoding = System.Text.Encoding.GetEncoding(Interface.CurrentOptions.RouteEncodings[j].Codepage);
							break;
						}
					}
				} else if (args[i].StartsWith("/train=", StringComparison.OrdinalIgnoreCase)) {
					result.TrainFolder = args[i].Substring(7);
					result.TrainEncoding = System.Text.Encoding.UTF8;
					for (int j = 0; j < Interface.CurrentOptions.TrainEncodings.Length; j++) {
						if (string.Compare(Interface.CurrentOptions.TrainEncodings[j].Value, result.TrainFolder, StringComparison.InvariantCultureIgnoreCase) == 0) {
							result.TrainEncoding = System.Text.Encoding.GetEncoding(Interface.CurrentOptions.TrainEncodings[j].Codepage);
							break;
						}
					}
				}
			}
			// --- check whether route and train exist ---
			if (result.RouteFile != null) {
				if (!System.IO.File.Exists(result.RouteFile)) {
					result.RouteFile = null;
				}
			}
			if (result.TrainFolder != null) {
				if (!System.IO.Directory.Exists(result.TrainFolder)) {
					result.TrainFolder = null;
				}
			}
			// --- if a route was provided but no train, try to use the route default ---
			if (result.RouteFile != null & result.TrainFolder == null) {
				bool isRW = string.Equals(System.IO.Path.GetExtension(result.RouteFile), ".rw", StringComparison.OrdinalIgnoreCase);
				CsvRwRouteParser.ParseRoute(result.RouteFile, isRW, result.RouteEncoding, null, null, null, true);
				if (Game.TrainName != null && Game.TrainName.Length != 0) {
					string folder = System.IO.Path.GetDirectoryName(result.RouteFile);
					while (true) {
						string trainFolder = OpenBveApi.Path.CombineDirectory(folder, "Train");
						if (System.IO.Directory.Exists(trainFolder)) {
							folder = OpenBveApi.Path.CombineDirectory(trainFolder, Game.TrainName);
							if (System.IO.Directory.Exists(folder)) {
								string file = OpenBveApi.Path.CombineFile(folder, "train.dat");
								if (System.IO.File.Exists(file)) {
									result.TrainFolder = folder;
									result.TrainEncoding = System.Text.Encoding.UTF8;
									for (int j = 0; j < Interface.CurrentOptions.TrainEncodings.Length; j++) {
										if (string.Compare(Interface.CurrentOptions.TrainEncodings[j].Value, result.TrainFolder, StringComparison.InvariantCultureIgnoreCase) == 0) {
											result.TrainEncoding = System.Text.Encoding.GetEncoding(Interface.CurrentOptions.TrainEncodings[j].Codepage);
											break;
										}
									}
								}
							} break;
						} else {
							System.IO.DirectoryInfo info = System.IO.Directory.GetParent(folder);
							if (info != null) {
								folder = info.FullName;
							} else {
								break;
							}
						}
					}
				}
				Game.Reset(false);
			}
			// --- load options and controls ---
			Interface.LoadOptions();
			Interface.LoadControls(null, out Interface.CurrentControls);
			{
				string f = OpenBveApi.Path.CombineFile(Program.FileSystem.GetDataFolder("Controls"), "Default keyboard assignment.controls");
				Interface.Control[] c;
				Interface.LoadControls(f, out c);
				Interface.AddControls(ref Interface.CurrentControls, c);
			}
			// --- show the main menu if necessary ---
			if (result.RouteFile == null | result.TrainFolder == null) {
				result = formMain.ShowMainDialog();
			}
			// --- start the actual program ---
			if (result.Start) {
				if (Initialize()) {
					MainLoop.StartLoopEx(result);
				}
				Deinitialize();
			}
			// --- restart the program if necessary ---
			if (RestartArguments != null) {
				string arguments;
				if (FileSystem.RestartArguments.Length != 0 & RestartArguments.Length != 0) {
					arguments = FileSystem.RestartArguments + " " + RestartArguments;
				} else {
					arguments = FileSystem.RestartArguments + RestartArguments;
				}
				try {
					System.Diagnostics.Process.Start(FileSystem.RestartProcess, arguments);
				} catch (Exception ex) {
					MessageBox.Show(ex.Message + "\n\nProcess = " + FileSystem.RestartProcess + "\nArguments = " + arguments, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}
		
		/// <summary>Initializes the program. A matching call to deinitialize must be made when the program is terminated.</summary>
		/// <returns>Whether the initialization was successful.</returns>
		private static bool Initialize() {
			if (Sdl.SDL_Init(0) != 0) {
				MessageBox.Show("SDL failed to initialize", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return false;
			}
			if (!Screen.Initialize()) {
				MessageBox.Show("SDL failed to initialize the video subsystem.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return false;
			}
			if (!Joysticks.Initialize()) {
				MessageBox.Show("SDL failed to initialize the joystick subsystem.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return false;
			}
			SoundManager.Initialize();
			Plugins.LoadPlugins();
			// begin HACK //
			const double degrees = 0.0174532925199433;
			World.VerticalViewingAngle = 45.0 * degrees;
			World.HorizontalViewingAngle = 2.0 * Math.Atan(Math.Tan(0.5 * World.VerticalViewingAngle) * World.AspectRatio);
			World.OriginalVerticalViewingAngle = World.VerticalViewingAngle;
			World.ExtraViewingDistance = 50.0;
			World.ForwardViewingDistance = (double)Interface.CurrentOptions.ViewingDistance;
			World.BackwardViewingDistance = 0.0;
			World.BackgroundImageDistance = (double)Interface.CurrentOptions.ViewingDistance;
			// end HACK //
			return true;
		}
		
		/// <summary>Deinitializes the program.</summary>
		private static void Deinitialize() {
			Plugins.UnloadPlugins();
			SoundManager.Deinitialize();
			Joysticks.Deinitialize();
			Screen.Deinitialize();
			Sdl.SDL_Quit();
		}
		
	}
}
