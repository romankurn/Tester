using GeneralInformation;
using GeneralInformation.Events;
using TesterApp.QuestionForms;

namespace TesterApp.ServiceClasses.QuestionFormCreators
{
	public class QuestionFormCreator
	{
		public event EventHandler OnAswerReceived;

		public event EventHandler OnAnotherQuestionSelected;

		public QuestionFormCreator()
		{

		}

		public void CreateForm(int questionNumber)
		{
			var questionType = ServicesHolder.QuestionsHolder.Questions[questionNumber].QuestionType;

			switch (questionType)
			{
				case (QuestionTypes.StandartQuestion):
					{
						var standartQuestionForm = new StandartQuestionForm(questionNumber);

						standartQuestionForm.Show();

						standartQuestionForm.OnReplyButtonClick += StandartQuestionFormOnReplyButtonClick;

						standartQuestionForm.OnNavigationButtonClick += StandartQuestionFormOnNavigationButtonClick;

						break;
					}

				case (QuestionTypes.YesNoQuestion):
					{
						break;
					}

				case (QuestionTypes.AdvancedQuestion):
					{
						break;
					}

				case (QuestionTypes.MatchQuestion):
					{
						break;
					}
			}

		}

		private void StandartQuestionFormOnNavigationButtonClick(object? sender, EventArgs e)
		{
			OnAnotherQuestionSelected?.Invoke(this, e);
		}

		private void StandartQuestionFormOnReplyButtonClick(object? sender, EventArgs e)
		{
			var answerReceivedEvent = (AnswerReceivedEvent)e;

			OnAswerReceived?.Invoke(this, answerReceivedEvent);
		}
	}
}
