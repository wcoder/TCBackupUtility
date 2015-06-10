using System.IO;
using TCBackupUtility.Interfaces;

namespace TCBackupUtility.Infrastructure
{
	class FileManager : IFileManager
	{
		public bool OwereadingCopy(string inputPath, string outputPath)
		{
			if (string.IsNullOrEmpty(inputPath)) return false;
			if (string.IsNullOrEmpty(outputPath)) return false;

			File.Copy(inputPath, outputPath, true);

			return true;
		}
	}
}
