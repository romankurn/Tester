namespace FileHandler.Exceptions
{
	public class CryptoException : Exception
	{
		public CryptoException(string message, Exception innerException = null)
			: base(message, innerException) { }
	}
}
