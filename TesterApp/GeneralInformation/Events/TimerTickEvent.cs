namespace GeneralInformation.Events
{
	public class TimerTickEvent : EventArgs
	{
		public string RemainingTime { get; set; }
	}
}
