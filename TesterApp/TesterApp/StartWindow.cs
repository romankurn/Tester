using GeneralInformation.Events;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using TesterApp.ServiceClasses;

namespace TesterApp
{
	public partial class StartWindow : Form
	{
		private TestNavigationForm _testNavigationForm;
		private string _fio;

		public StartWindow()
		{
			InitializeComponent();
		}

		private async void OnWindowLoaded(object sender, EventArgs e)
		{
			СonfigureСomponents();

			SelectTestCreationOption();
		}


		#region Evets
		private void OnStartButtonClick(object sender, EventArgs e)
		{
			var autorizationForm = new AutorizationForm();

			autorizationForm.Show();

			autorizationForm.OnStartButtonClicked += AutorizationFormOnStartButtonClicked;
			autorizationForm.FormClosing += OnAutorizationFormClosing;

			Enabled = false;
		}

		private void AutorizationFormOnStartButtonClicked(object? sender, EventArgs e)
		{
			_fio = ((FioEnteredEvent)e).Fio;
			var testTime = ServicesHolder.Config.InitialInformation.TestTime;

			_startButton.Visible = false;			
			_continueButton.Visible = true;

			ServicesHolder.Timer.StartTimer(testTime);
			
			ServicesHolder.AnswerFileHandler.SaveTest(_fio);

			PrepareTestNavigationForm();
		}

		private void OnAutorizationFormClosing(object? sender, FormClosingEventArgs e)
		{			
			if (_testNavigationForm == null)
			{
				Enabled = true;
			}			
		}

		private void OnDownloadButtonClick(object sender, EventArgs e)
		{
			var loadingInfo = ServicesHolder.AnswerFileHandler.GetInformationForLoadingTest();

			_fio = loadingInfo.StudentName;

			ServicesHolder.QuestionsHolder.LoadTest(loadingInfo);
			ServicesHolder.Timer.StartTimer(loadingInfo.RemainingTime);
			
			Enabled = false;			
			_downloadButton.Visible = false;
			_continueButton.Visible = true;

			PrepareTestNavigationForm();
		}
		
		private void OnTestNavigationFormClosing(object? sender, FormClosingEventArgs e)
		{
			Enabled = true;
			ServicesHolder.Timer.Pause();
			SaveTest();
		}
		
		private void OnContinueButtonClick(object sender, EventArgs e)
		{
			ServicesHolder.Timer.Continue();
			PrepareTestNavigationForm();
		}

		private void OnSaveNeeded(object? sender, EventArgs e)
		{
			SaveTest();
		}
		#endregion

		private async void SelectTestCreationOption()
		{
			var saveFileExists = File.Exists($"Результаты теста {ServicesHolder.Config.InitialInformation.LectureNumber}.csv");

			if (saveFileExists)
			{
				_downloadButton.Visible = true;
			}
			else
			{
				var testInitializer = new TestInitializer();

				await testInitializer.InitializeTest();

				_startButton.Visible = true;
			}

			ServicesHolder.Timer.OnTimeIsOver += OnSaveNeeded;
		}

		private void СonfigureСomponents()
		{
			var width = Convert.ToInt32(Screen.PrimaryScreen.Bounds.Width * 0.651);
			var height = Convert.ToInt32(Screen.PrimaryScreen.Bounds.Height * 0.509);

			_instruction.Location = new Point(Convert.ToInt32(width * 0.009), Convert.ToInt32(height * 0.014));

			var buttonLocation = new Point(Convert.ToInt32(width / 2 - _continueButton.Width / 2), Convert.ToInt32(height * 0.8));

			_startButton.Location = buttonLocation;
			_downloadButton.Location = buttonLocation;
			_continueButton.Location = buttonLocation;

			_startButton.Visible = false;
			_downloadButton.Visible = false;
			_continueButton.Visible = false;

			Size = new Size(width, height);

			var lectureNumber = ServicesHolder.Config.InitialInformation.LectureNumber;

			var time = ServicesHolder.Config.InitialInformation.TestTime;

			Text = $"Контрольные вопросы по Лекции {lectureNumber}";

			_instruction.Text = @$"На выполнение теста отводится {time / 60} минут.
			Тест может состоять из следующих блоков:
			Блок А. Вопросы с выбором ВСЕХ правильных вариантов из предложенного списка. За каждый правильно выбранный вариант +1 балл, за каждый неверный вариант -0,5 балла. 
			Блок Б. Вопросы с выбором ОДНОГО верного ответа из общего списка вариантов. Один вариант может быть верным ответом в разных вопросах. За правильный ответ +1 балл.
			Блок В. Вопросы на определение истинности утверждения. За правильный ответ +1 балл.
			Блок Г. Вопросы на установление соответствия или определение правильного порядка. За каждое верное расположение варианта ответа +1 балл.
			Итоговая оценка определяется, в зависимости от набранного % от максимально возможного балла, по шкале:
			[0%; 50%) максимального балла - оценка 2;
			[50%; 70%) - оценка 3;
			[70%; 85%) - оценка 4;
			[85%; 100%]- оценка 5.";
		}

		private void PrepareTestNavigationForm()
		{
			_testNavigationForm = new TestNavigationForm();
			_testNavigationForm.Show();
			_testNavigationForm.OnAnswerReceived += OnSaveNeeded;			
			_testNavigationForm.FormClosing += OnTestNavigationFormClosing;
		}

		private void SaveTest()
		{
			ServicesHolder.AnswerFileHandler.SaveTest(_fio);
		}
	}
}
