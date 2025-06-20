using GeneralInformation.Events;

namespace TesterApp.ServiceClasses
{
	public class TestTimer
	{
		private bool _pauseEnabled = false;

		public int RemainingSeconds { get; private set; }

		public string RemainingTime { get; private set; }

		public event EventHandler OnTimeIsOver;

		public event EventHandler OnTimerTick;

		public TestTimer()
		{

		}

		public async Task StartTimer(int time)
		{
			RemainingSeconds = time;

			RemainingTime = GetRemainingTime();

			while (RemainingSeconds >= 1)
			{
				await Task.Delay(1000);

				if (_pauseEnabled)
					continue;

				RemainingSeconds--;
				RemainingTime = GetRemainingTime();

				OnTimerTick?.Invoke(this, new TimerTickEvent { RemainingTime = RemainingTime });
			}

			StopTimer();
		}

		public void Pause()
		{
			_pauseEnabled = true;
		}

		public void Continue()
		{
			_pauseEnabled = false;
		}

		public void StopTimer()
		{
			RemainingSeconds = 0;

			ServicesHolder.TestCompletionController.BlockContinue();

			_pauseEnabled = true;

			OnTimeIsOver?.Invoke(this, EventArgs.Empty);
		}

		private string GetRemainingTime()
		{
			var min = RemainingSeconds / 60;
			var sec = RemainingSeconds % 60;

			if (sec < 10)
				return $"{min}:0{sec}";

			return $"{min}:{sec}";
		}
	}
}
