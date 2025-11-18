namespace AnagramFinder
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            lblAnswer = new Label();
            label3 = new Label();
            lblErrorWordOne = new Label();
            lblErrorWordTwo = new Label();
            label6 = new Label();
            btnCheck = new Button();
            txtWordOne = new TextBox();
            txtWordTwo = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Bottom;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(382, 429);
            label1.Name = "label1";
            label1.Size = new Size(473, 45);
            label1.TabIndex = 0;
            label1.Text = "Are these two words anagrams?";
            // 
            // lblAnswer
            // 
            lblAnswer.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblAnswer.AutoSize = true;
            lblAnswer.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAnswer.Location = new Point(175, 522);
            lblAnswer.Name = "lblAnswer";
            lblAnswer.Size = new Size(126, 45);
            lblAnswer.TabIndex = 1;
            lblAnswer.Text = "answer";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(217, 96);
            label3.Name = "label3";
            label3.Size = new Size(84, 21);
            label3.TabIndex = 2;
            label3.Text = "Word One:";
            // 
            // lblErrorWordOne
            // 
            lblErrorWordOne.Anchor = AnchorStyles.Top;
            lblErrorWordOne.AutoSize = true;
            lblErrorWordOne.ForeColor = Color.Red;
            lblErrorWordOne.Location = new Point(321, 142);
            lblErrorWordOne.Name = "lblErrorWordOne";
            lblErrorWordOne.Size = new Size(38, 15);
            lblErrorWordOne.TabIndex = 3;
            lblErrorWordOne.Text = "label4";
            // 
            // lblErrorWordTwo
            // 
            lblErrorWordTwo.Anchor = AnchorStyles.Top;
            lblErrorWordTwo.AutoSize = true;
            lblErrorWordTwo.ForeColor = Color.Red;
            lblErrorWordTwo.Location = new Point(833, 142);
            lblErrorWordTwo.Name = "lblErrorWordTwo";
            lblErrorWordTwo.Size = new Size(38, 15);
            lblErrorWordTwo.TabIndex = 4;
            lblErrorWordTwo.Text = "label5";
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top;
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(708, 96);
            label6.Name = "label6";
            label6.Size = new Size(81, 21);
            label6.TabIndex = 5;
            label6.Text = "Word two:";
            // 
            // btnCheck
            // 
            btnCheck.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnCheck.BackColor = SystemColors.Desktop;
            btnCheck.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCheck.Location = new Point(518, 247);
            btnCheck.Name = "btnCheck";
            btnCheck.Size = new Size(192, 81);
            btnCheck.TabIndex = 6;
            btnCheck.Text = "Check The Two Words";
            btnCheck.UseVisualStyleBackColor = false;
            btnCheck.Click += CheckWordsButton;
            // 
            // txtWordOne
            // 
            txtWordOne.Anchor = AnchorStyles.Top;
            txtWordOne.Location = new Point(307, 98);
            txtWordOne.Name = "txtWordOne";
            txtWordOne.Size = new Size(133, 23);
            txtWordOne.TabIndex = 7;
            txtWordOne.Leave += WordOneLeave;
            // 
            // txtWordTwo
            // 
            txtWordTwo.Anchor = AnchorStyles.Top;
            txtWordTwo.Location = new Point(795, 98);
            txtWordTwo.Name = "txtWordTwo";
            txtWordTwo.Size = new Size(133, 23);
            txtWordTwo.TabIndex = 8;
            txtWordTwo.Leave += WordTwoLeeave;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1183, 639);
            Controls.Add(txtWordTwo);
            Controls.Add(txtWordOne);
            Controls.Add(btnCheck);
            Controls.Add(label6);
            Controls.Add(lblErrorWordTwo);
            Controls.Add(lblErrorWordOne);
            Controls.Add(label3);
            Controls.Add(lblAnswer);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label lblAnswer;
        private Label label3;
        private Label lblErrorWordOne;
        private Label lblErrorWordTwo;
        private Label label6;
        private Button btnCheck;
        private TextBox txtWordOne;
        private TextBox txtWordTwo;
    }
}
