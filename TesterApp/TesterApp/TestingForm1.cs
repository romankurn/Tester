using System.Diagnostics;

namespace TesterApp
{
	public partial class TestingForm1 : Form
	{
		private string[] filesNames = new[] { "file1name.csv", "file2name.csv", "file3name.csv", "file4name.csv" };

		public TestingForm1()
		{
			InitializeComponent();
		}

		private async void TesterApp_Load(object sender, EventArgs e)
		{
			await LoadQuestionsAsync();

			_questionLabel.Text = "Вопрос";

			this.Size = new Size(500, 500);
			button1.Enabled = true;
		}

		private async Task LoadQuestionsAsync()
		{
			try
			{
				await Task.Delay(2000);

				Debug.WriteLine("sdfdfs");

			}
			catch (Exception ex)
			{

			}
		}

		private void button1_Click(object sender, EventArgs e)
		{

			_questionLabel.Text += "Туче";

			var questionCount = 30;
			var questionTableNavigation = new TextBox[questionCount];


			var size = 30;
			var startPositionX = 200;
			var startPositionY = 100;
			var questionNumber = 1;
			for (var i = 0; i < questionTableNavigation.Length; i++)
			{
				questionTableNavigation[i] = new TextBox();

				var cell = questionTableNavigation[i];

				cell.Size = new Size(size, size);

				//номер вопроса
				cell.Text = questionNumber.ToString();
				//cell.Enabled = false;
				cell.Location = new Point(startPositionX + size * questionNumber, startPositionY);

				questionNumber++;

				cell.MouseDown += Cell_MouseDown;

			}

			this.Controls.AddRange(questionTableNavigation);
		}

		private void Cell_MouseDown(object sender, MouseEventArgs e)
		{
			var questionNumber = int.Parse(((TextBox)sender).Text);

			//переход к выбранному вопросу
		}

		private void textbox_click(object sender, EventArgs e)
		{

		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{

		}
	}
}
