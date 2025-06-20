namespace TesterApp.ServiceClasses
{
	public class TestCompletionController
	{
		public bool TestCanBeContinued { get; private set; }

		public TestCompletionController()
		{
			TestCanBeContinued = true;
		}

		public void BlockContinue()
		{
			TestCanBeContinued = false;
		}
	}
}
