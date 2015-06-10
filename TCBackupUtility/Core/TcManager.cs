using System;
using TCBackupUtility.Interfaces;

namespace TCBackupUtility.Core
{
	class TcManager
	{
		public const string TcSettingsFileName = "wincmd.ini";
		//private const string TcSettingsPath = @"%APPDATA%\GHISLER\wincmd.ini";
		private const string TcRegistryPath = @"HKEY_CURRENT_USER\Software\Ghisler\Total Commander";

		private readonly IFileManager _fileManager;
		private readonly IRegistryManager _registryManager;

		public TcManager(IFileManager fileManager, IRegistryManager registryManager)
		{
			_fileManager = fileManager;
			_registryManager = registryManager;
		}

		public bool ExportSettingsTo(string outputPath)
		{
			var inputPath = GetPathToSettingsFile();
			return _fileManager.OwereadingCopy(inputPath, outputPath);
		}

		public bool ImportSettingsFrom(string inputPath)
		{
			var outputPath = GetPathToSettingsFile();
			return _fileManager.OwereadingCopy(inputPath, outputPath);
		}

		private string GetPathFromRegistry(TcRegestryKeys key)
		{
			var path = _registryManager.GetValueFromRegistry(TcRegistryPath, key.ToString());
			return Environment.ExpandEnvironmentVariables(path);
		}

		private string GetPathToSettingsFile()
		{
			var path = GetPathFromRegistry(TcRegestryKeys.IniFileName);
			return Environment.ExpandEnvironmentVariables(path);
		}
	}

	enum TcRegestryKeys
	{
		IniFileName,
		FtpIniName,
		InstallDir
	}
}