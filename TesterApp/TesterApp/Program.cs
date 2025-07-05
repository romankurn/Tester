using FileHandler;
using FileHandler.Services;
using GeneralInformation;
using GeneralInformation.Info;
using System.Threading.Tasks;

namespace TesterApp
{
	internal static class Program
	{
		/// <summary>
		///  The main entry point for the application.
		/// </summary>
		[STAThread]
		static async Task Main()
		{
			var fileProcessor = new CsvFileProcessor(Constants.CellSeparator);

			var cryptor = new Cryptor();

			var fileCryptor = new FileCryptor(cryptor, fileProcessor);



			//шифр конфига

			await fileCryptor.EncryptDataFromExistingFileAsync("config.csv", "CE7DCC30-47B9-4DF5-A92F-8F1BDC77273C.csv");
			var config = new Config();







			Application.SetHighDpiMode(HighDpiMode.SystemAware);
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new StartWindow());
		}
	}
}