using FileHandler.Interfaces;
using System.Text;

namespace FileHandler.Services
{
	public class Cryptor : ICryptor
	{
		public IEnumerable<string> Encrypt(IEnumerable<string> line)
		{
			if (line == null) throw new ArgumentNullException(nameof(line));

			foreach (var column in line)
			{
				var bytes = Encoding.UTF8.GetBytes(column);
				var encodeColumn = Convert.ToBase64String(bytes);

				yield return encodeColumn;
			}
		}

		public IEnumerable<string> Decrypt(IEnumerable<string> line)
		{
			if (line == null) throw new ArgumentNullException(nameof(line));

			foreach (var column in line)
			{
				var bytes = Convert.FromBase64String(column);
				var decodeColumn = Encoding.UTF8.GetString(bytes);

				yield return decodeColumn;
			}
		}
	}
}
