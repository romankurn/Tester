namespace GeneralInformation.Events
{
	public class AnswerReceivedEvent : EventArgs
	{
		public int QuestionNumber { get; set; }
	}
}
