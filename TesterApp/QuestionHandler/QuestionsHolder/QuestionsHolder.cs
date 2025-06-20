using QuestionHandler.QuestionReader;
using QuestionHandler.QuestionsModels;
using QuestionHandler.TestHandler;

namespace QuestionHandler.QuestionsHolder
{
	public class QuestionsHolder : IQuestionsHolder
	{
		private int _questoinKey = 1;

		public Dictionary<int, QuestionBase> Questions { get; private set; }

		public double StudentPoints { get; private set; }

		public int MaximumPoints { get; private set; }

		public int StudentResult
		{
			get
			{
				return GetStudentResult();
			}
		}

		public QuestionsHolder()
		{
			Questions = new Dictionary<int, QuestionBase>();
		}

		public void CalculateUserPoints()
		{
			foreach (var question in Questions)
			{
				StudentPoints += question.Value.UserPoints;
			}
		}

		public void CreateTest(InitialInformationForCreatingTest initialInformationForCreatingTest)
		{
			var random = new Random();
			var usedQuestions = new List<int>();
			var questionNumber = 0;

			for (var i = 1; i <= initialInformationForCreatingTest.QuestionsNumberPerTest; i++)
			{
				while (true)
				{
					questionNumber = random.Next(0, initialInformationForCreatingTest.AllQuestions.Count);

					if (!usedQuestions.Contains(questionNumber))
					{
						usedQuestions.Add(questionNumber);
						break;
					}
				}

				var chosenQuestion = initialInformationForCreatingTest.AllQuestions[questionNumber];

				Questions.Add(_questoinKey++, chosenQuestion);

				MaximumPoints += chosenQuestion.MaximumPoints;
			}
		}

		public void LoadTest(InformationForLoadingTest info)
		{
			Questions = info.Questions;

			foreach (var question in Questions)
			{
				question.Value.CheckAnswer();
			}

			StudentPoints = info.UserPoints;
			MaximumPoints = info.MaximumPoints;
		}

		private int GetStudentResult()
		{
			var shareOfCorrectAnswers = StudentPoints / MaximumPoints * 100;

			if (shareOfCorrectAnswers < 50)
				return 2;
			else if (shareOfCorrectAnswers >= 50 && shareOfCorrectAnswers < 70)
				return 3;
			else if (shareOfCorrectAnswers >= 70 && shareOfCorrectAnswers < 85)
				return 4;
			else
				return 5;
		}
	}
}
