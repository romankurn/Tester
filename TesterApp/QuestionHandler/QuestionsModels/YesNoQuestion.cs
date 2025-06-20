using GeneralInformation;

namespace QuestionHandler.QuestionsModels
{
	public class YesNoQuestion : QuestionBase
	{
		public string QuestionText { get; private set; }

		public string[] AnswerOptions { get; } = new string[] { "Верно", "Неверно" };

		public int RightAnswer { get; private set; }

		public int UserAnswer { get; set; }

		public YesNoQuestion(QuestionTypes questionType, string questionText, int rightAnswer, int userAnswer = 0) : base(questionType)
		{
			QuestionText = questionText;
			RightAnswer = rightAnswer;
			UserAnswer = userAnswer;
			GetMaximumPoints();
		}

		public override void CheckAnswer()
		{
			if (UserAnswer != RightAnswer)
			{
				UserPoints = 0;
				return;
			}

			UserPoints = 1;
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

			questionList.Add(RightAnswer.ToString());

			questionList.Add(UserAnswer.ToString());

			return questionList;
		}
	}
}
