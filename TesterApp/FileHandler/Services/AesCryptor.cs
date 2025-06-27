using FileHandler.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace FileHandler.Services
{
	public class AesCryptor : ICryptor, IDisposable
	{
		private readonly Aes _aes;
		private readonly ICryptoTransform _encryptor;
		private readonly ICryptoTransform _decryptor;

		public AesCryptor(byte[] key, byte[] iv)
		{
			_aes = Aes.Create();
			_aes.Key = key ?? throw new ArgumentNullException(nameof(key));
			_aes.IV = iv ?? throw new ArgumentNullException(nameof(iv));
			_encryptor = _aes.CreateEncryptor();
			_decryptor = _aes.CreateDecryptor();
		}

		public async Task<IEnumerable<string>> EncryptAsync(IEnumerable<string> data)
		{
			if (data == null) throw new ArgumentNullException(nameof(data));

			var results = new List<string>();

			foreach (var line in data)
			{
				await Task.Run(() =>
				{
					byte[] bytes = Encoding.UTF8.GetBytes(line);
					byte[] encryptedBytes = _encryptor.TransformFinalBlock(bytes, 0, bytes.Length);
					results.Add(Convert.ToBase64String(encryptedBytes));
				});
			}
			return results;
		}

		public async Task<IEnumerable<string>> DecryptAsync(IEnumerable<string> encryptedData)
		{
			if (encryptedData == null) throw new ArgumentNullException(nameof(encryptedData));

			var results = new List<string>();
			foreach (var line in encryptedData)
			{
				await Task.Run(() =>
				{
					byte[] bytes = Convert.FromBase64String(line);
					byte[] decryptedBytes = _decryptor.TransformFinalBlock(bytes, 0, bytes.Length);
					results.Add(Encoding.UTF8.GetString(decryptedBytes));
				});
			}
			return results;
		}

		public void Dispose()
		{
			_encryptor?.Dispose();
			_decryptor?.Dispose();
			_aes?.Dispose();
		}
	}
}
