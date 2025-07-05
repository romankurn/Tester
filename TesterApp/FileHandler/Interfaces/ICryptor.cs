namespace FileHandler.Interfaces
{
	public interface ICryptor
	{
		IEnumerable<string> Encrypt(IEnumerable<string> line);

		IEnumerable<string> Decrypt(IEnumerable<string> line);
	}
}
