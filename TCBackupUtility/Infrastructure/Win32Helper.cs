using Microsoft.Win32;
using TCBackupUtility.Interfaces;

namespace TCBackupUtility.Infrastructure
{
	class Win32Helper : IRegistryManager
	{
		public string GetValueFromRegistry(string path, string key)
		{
			return Registry.GetValue(path, key, 0).ToString();
		}

		public string ShowSaveDialog(string fileName, string path)
		{
			var dlg = new SaveFileDialog
			{
				FileName = fileName,
				DefaultExt = ".ini",
				InitialDirectory = path,
				Filter = "(.ini)|*.ini"
			};

			var result = dlg.ShowDialog();
			return result == true ? dlg.FileName : null;
		}

		public string ShowOpenDialog()
		{
			var dlg = new OpenFileDialog
			{
				Filter = "(.ini)|*.ini"
			};

			var result = dlg.ShowDialog();
			return result == true ? dlg.FileName : null;
		}
	}
}