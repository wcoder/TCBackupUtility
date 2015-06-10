namespace TCBackupUtility.Interfaces
{
	interface IRegistryManager
	{
		string GetValueFromRegistry(string path, string key);
	}
}
