using GeneralInformation;

namespace QuestionHandler.QuestionsModels
{
	public class StandartQuestion : QuestionBase
	{
		public string QuestionText { get; private set; }

		public List<string> AnswerOptions { get; private set; }

		public List<int> RightAnswer { get; private set; }

		public List<int> UserAnswer { get; set; }

		public StandartQuestion(QuestionTypes questionType, string questionText, List<string> answerOptions, List<int> rightAnswer, List<int> userAnswer = null) : base(questionType)
		{
			QuestionText = questionText;
			AnswerOptions = answerOptions;
			RightAnswer = rightAnswer;
			UserAnswer = userAnswer;
			GetMaximumPoints();
		}

		public override void CheckAnswer()
		{
			if (UserAnswer == null)
			{
				UserPoints = 0;
				return;
			}

			var result = 0.0;

			foreach (var optoin in UserAnswer)
			{
				if (RightAnswer.Contains(optoin))
				{
					result += 1;
					continue;
				}

				result -= 0.5;
			}

			if (result < 0)
				result = 0;

			UserPoints = result;
		}

		protected override void GetMaximumPoints()
		{
			MaximumPoints = RightAnswer.Count;
		}

		public override void SetUserAnswer(List<int> userAnswer)
		{
			if (UserAnswer == null)
				UserAnswer = new List<int>();

			UserAnswer = userAnswer;

			CheckAnswer();
		}

		public override List<string> ConvertQuestionToList()
		{
			var questionList = new List<string>();

			questionList.Add(QuestionType.ToString());

			questionList.Add(QuestionText);

			questionList.Add($"{OptionsListToString(AnswerOptions)}");

			questionList.Add($"{OptionsListToString(RightAnswer)}");

			questionList.Add($"{OptionsListToString(UserAnswer)}");

			return questionList;
		}
	}
}
