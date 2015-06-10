using System;
using System.Windows;
using TCBackupUtility.Core;
using TCBackupUtility.Infrastructure;

namespace TCBackupUtility
{
	public partial class MainWindow : Window
	{
		private static TcManager _tcManager;
		private static Win32Helper _win32Helper;

		public MainWindow()
		{
			InitializeComponent();
			InitializeApp();
		}

		private static void InitializeApp()
		{
			_win32Helper = new Win32Helper();
			_tcManager = new TcManager(new FileManager(), _win32Helper);
		}

		private void ExportSettingsIni(object sender, RoutedEventArgs args)
		{
			try
			{
				var dafaultPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
				var outputPath = _win32Helper.ShowSaveDialog(TcManager.TcSettingsFileName, dafaultPath);

				var isSuccessed = _tcManager.ExportSettingsTo(outputPath);
				if (isSuccessed)
				{
					var message = string.Format("Successfully exported in: {0}", outputPath);
					MessageBox.Show(message);
				}
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
			}
		}

		private void ImportSettingsIni(object sender, RoutedEventArgs args)
		{
			try
			{
				var inputPath = _win32Helper.ShowOpenDialog();

				var isSuccessed = _tcManager.ImportSettingsFrom(inputPath);
				if (isSuccessed)
				{
					MessageBox.Show("Successfully imported!");
				}
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
			}
		}
	}
}