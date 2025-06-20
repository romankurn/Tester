namespace QuestionHandler.TestHandler
{
	public interface ITestHandler
	{
		public List<List<string>> PrepareInformationForSavingText(InformationForSavingTest info);

		public InformationForLoadingTest DownloadInformation(List<List<string>> uploadedInformation);
	}
}
