using GeneralInformation;

namespace QuestionHandler.QuestionsModels
{
	public class AdvancedQuestion : QuestionBase
	{
		public string QuestionText { get; private set; }

		public List<string> AnswerOptions { get; private set; }

		public int RightAnswer { get; private set; }

		public int UserAnswer { get; set; }

		public AdvancedQuestion(QuestionTypes questionType, string questionText, List<string> answerOptions, int rightAnswer) : base(questionType)
		{
			QuestionText = questionText;
			AnswerOptions = answerOptions;
			RightAnswer = rightAnswer;
			GetMaximumPoints();
		}

		public override void CheckAnswer()
		{
			if (RightAnswer == UserAnswer)
			{
				UserPoints = 1;
				return;
			}

			UserPoints = 0;
		}

		protected override void GetMaximumPoints()
		{
			MaximumPoints = 1;
		}

		public override void SetUserAnswer(List<int> userAnswer)
		{
			UserAnswer = userAnswer[0];

			CheckAnswer();
		}

		public override List<string> ConvertQuestionToList()
		{
			var questionList = new List<string>();

			questionList.Add(QuestionType.ToString());

			questionList.Add(QuestionText);

			questionList.Add($"{OptionsListToString(AnswerOptions)}");

			questionList.Add(RightAnswer.ToString());

			questionList.Add(UserAnswer.ToString());

			return questionList;
		}
	}
}
