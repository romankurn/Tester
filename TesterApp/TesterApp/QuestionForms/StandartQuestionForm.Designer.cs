namespace TesterApp.QuestionForms
{
	partial class StandartQuestionForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this._questionText = new System.Windows.Forms.Label();
			this._backButton = new System.Windows.Forms.Button();
			this._nextButton = new System.Windows.Forms.Button();
			this._replyButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// _questionText
			// 
			this._questionText.AutoSize = true;
			this._questionText.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this._questionText.Location = new System.Drawing.Point(12, 18);
			this._questionText.MaximumSize = new System.Drawing.Size(1250, 0);
			this._questionText.Name = "_questionText";
			this._questionText.Size = new System.Drawing.Size(1249, 26);
			this._questionText.TabIndex = 0;
			this._questionText.Text = "укапаввапрваравправправрпоапоапорварварваравпрапраптаптоапотапроапротьапртоапртоа" +
    "проапроампоапоапоапоапоапоапо";
			// 
			// _backButton
			// 
			this._backButton.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this._backButton.Location = new System.Drawing.Point(435, 508);
			this._backButton.Name = "_backButton";
			this._backButton.Size = new System.Drawing.Size(140, 35);
			this._backButton.TabIndex = 2;
			this._backButton.Text = "Назад";
			this._backButton.UseVisualStyleBackColor = true;
			this._backButton.Click += new System.EventHandler(this.BackButtonClick);
			// 
			// _nextButton
			// 
			this._nextButton.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this._nextButton.Location = new System.Drawing.Point(727, 508);
			this._nextButton.Name = "_nextButton";
			this._nextButton.Size = new System.Drawing.Size(140, 35);
			this._nextButton.TabIndex = 5;
			this._nextButton.Text = "Следующий";
			this._nextButton.UseVisualStyleBackColor = true;
			this._nextButton.Click += new System.EventHandler(this.NextButtonClick);
			// 
			// _replyButton
			// 
			this._replyButton.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this._replyButton.Location = new System.Drawing.Point(581, 508);
			this._replyButton.Name = "_replyButton";
			this._replyButton.Size = new System.Drawing.Size(140, 35);
			this._replyButton.TabIndex = 6;
			this._replyButton.Text = "Ответить";
			this._replyButton.UseVisualStyleBackColor = true;
			this._replyButton.Click += new System.EventHandler(this.ReplyButtonClick);
			// 
			// StandartQuestionForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1307, 555);
			this.Controls.Add(this._replyButton);
			this.Controls.Add(this._nextButton);
			this.Controls.Add(this._backButton);
			this.Controls.Add(this._questionText);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "StandartQuestionForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Блок А Вопрос №";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label _questionText;
		private System.Windows.Forms.Button _backButton;
		private System.Windows.Forms.Button _nextButton;
		private System.Windows.Forms.Button _replyButton;
	}
}