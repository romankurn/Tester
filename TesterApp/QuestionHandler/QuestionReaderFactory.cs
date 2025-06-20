using GeneralInformation;
using QuestionHandler.QuestionReader;

namespace QuestionHandler
{
	public class QuestionReaderFactory
	{
		private StandartQuestionReader _standartQuestionReader;
		private YesNoQuestionReader _yesNoQuestionReader;
		private MatchQuestionReader _matchQuestionReader;
		private AdvancedQuestionReader _advancedQuestionReader;

		public QuestionReaderFactory()
		{
			_standartQuestionReader = new StandartQuestionReader();
			_yesNoQuestionReader = new YesNoQuestionReader();
			_matchQuestionReader = new MatchQuestionReader();
			_advancedQuestionReader = new AdvancedQuestionReader();
		}

		public QuestionReaderBase GetQuestionReader(QuestionTypes questionType)
		{
			switch (questionType)
			{
				case (QuestionTypes.StandartQuestion):
					return _standartQuestionReader;

				case (QuestionTypes.YesNoQuestion):
					return _yesNoQuestionReader;

				case (QuestionTypes.MatchQuestion):
					return _matchQuestionReader;

				case (QuestionTypes.AdvancedQuestion):
					return _advancedQuestionReader;

				default:
					throw new ArgumentException();
			}
		}
	}
}
