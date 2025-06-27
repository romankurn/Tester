namespace FileHandler.Interfaces
{
	public interface ICryptor
	{
		Task<IEnumerable<string>> EncryptAsync(IEnumerable<string> data);

		Task<IEnumerable<string>> DecryptAsync(IEnumerable<string> encryptedData);
	}
}
