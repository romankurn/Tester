namespace GeneralInformation.Events
{
	public class GoToAnotherQuestion : EventArgs
	{
		public int QuestionNumber { get; set; }
	}
}
