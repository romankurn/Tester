namespace TesterApp
{
	partial class TestNavigationForm
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
			this._description = new System.Windows.Forms.Label();
			this._wrongAnswer = new System.Windows.Forms.TextBox();
			this._correctAnswer = new System.Windows.Forms.TextBox();
			this._indicators = new System.Windows.Forms.Label();
			this._wrongAnswerLabel = new System.Windows.Forms.Label();
			this._correctAnswerLabel = new System.Windows.Forms.Label();
			this._finishTestButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// _description
			// 
			this._description.AutoSize = true;
			this._description.BackColor = System.Drawing.SystemColors.Control;
			this._description.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this._description.Location = new System.Drawing.Point(12, 9);
			this._description.Name = "_description";
			this._description.Size = new System.Drawing.Size(657, 26);
			this._description.TabIndex = 4;
			this._description.Text = "Щёлкните по номеру вопроса в таблице, чтобы дать на него ответ";
			// 
			// _wrongAnswer
			// 
			this._wrongAnswer.BackColor = System.Drawing.Color.Yellow;
			this._wrongAnswer.Cursor = System.Windows.Forms.Cursors.Hand;
			this._wrongAnswer.Enabled = false;
			this._wrongAnswer.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this._wrongAnswer.Location = new System.Drawing.Point(12, 285);
			this._wrongAnswer.Name = "_wrongAnswer";
			this._wrongAnswer.ReadOnly = true;
			this._wrongAnswer.Size = new System.Drawing.Size(34, 34);
			this._wrongAnswer.TabIndex = 36;
			// 
			// _correctAnswer
			// 
			this._correctAnswer.BackColor = System.Drawing.Color.White;
			this._correctAnswer.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this._correctAnswer.Location = new System.Drawing.Point(12, 245);
			this._correctAnswer.Name = "_correctAnswer";
			this._correctAnswer.ReadOnly = true;
			this._correctAnswer.Size = new System.Drawing.Size(34, 34);
			this._correctAnswer.TabIndex = 37;
			// 
			// _indicators
			// 
			this._indicators.AutoSize = true;
			this._indicators.BackColor = System.Drawing.SystemColors.Control;
			this._indicators.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this._indicators.Location = new System.Drawing.Point(12, 207);
			this._indicators.Name = "_indicators";
			this._indicators.Size = new System.Drawing.Size(138, 26);
			this._indicators.TabIndex = 38;
			this._indicators.Text = "Индикаторы:";
			// 
			// _wrongAnswerLabel
			// 
			this._wrongAnswerLabel.AutoSize = true;
			this._wrongAnswerLabel.BackColor = System.Drawing.SystemColors.Control;
			this._wrongAnswerLabel.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this._wrongAnswerLabel.Location = new System.Drawing.Point(52, 288);
			this._wrongAnswerLabel.Name = "_wrongAnswerLabel";
			this._wrongAnswerLabel.Size = new System.Drawing.Size(212, 26);
			this._wrongAnswerLabel.TabIndex = 39;
			this._wrongAnswerLabel.Text = "На вопрос дан ответ";
			// 
			// _correctAnswerLabel
			// 
			this._correctAnswerLabel.AutoSize = true;
			this._correctAnswerLabel.BackColor = System.Drawing.SystemColors.Control;
			this._correctAnswerLabel.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this._correctAnswerLabel.Location = new System.Drawing.Point(52, 248);
			this._correctAnswerLabel.Name = "_correctAnswerLabel";
			this._correctAnswerLabel.Size = new System.Drawing.Size(220, 26);
			this._correctAnswerLabel.TabIndex = 40;
			this._correctAnswerLabel.Text = "На вопрос нет ответа";
			// 
			// _finishTestButton
			// 
			this._finishTestButton.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this._finishTestButton.Location = new System.Drawing.Point(12, 446);
			this._finishTestButton.Name = "_finishTestButton";
			this._finishTestButton.Size = new System.Drawing.Size(229, 39);
			this._finishTestButton.TabIndex = 41;
			this._finishTestButton.Text = "Завершить тест";
			this._finishTestButton.UseVisualStyleBackColor = true;
			this._finishTestButton.Click += new System.EventHandler(this.FinishTestButtonClick);
			// 
			// TestNavigationForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(1003, 553);
			this.Controls.Add(this._finishTestButton);
			this.Controls.Add(this._correctAnswerLabel);
			this.Controls.Add(this._wrongAnswerLabel);
			this.Controls.Add(this._indicators);
			this.Controls.Add(this._correctAnswer);
			this.Controls.Add(this._wrongAnswer);
			this.Controls.Add(this._description);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "TestNavigationForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "TestNavigationForm";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TestNavigationForm_FormClosed);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Label _description;
		private System.Windows.Forms.TextBox _wrongAnswer;
		private System.Windows.Forms.TextBox _correctAnswer;
		private System.Windows.Forms.Label _indicators;
		private System.Windows.Forms.Label _wrongAnswerLabel;
		private System.Windows.Forms.Label _correctAnswerLabel;
		private System.Windows.Forms.Button _finishTestButton;
	}
}