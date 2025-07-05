namespace FileHandler.Exceptions
{
	public class FileHandlerException : Exception
	{
		public FileHandlerException(string message, Exception innerException = null)
		: base(message, innerException) { }
	}
}
