namespace TowereOfHanoi
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
            txtTowerNumber = new TextBox();
            label1 = new Label();
            rtxtInfoDump = new RichTextBox();
            label2 = new Label();
            lblNumMoves = new Label();
            btnStart = new Button();
            SuspendLayout();
            // 
            // txtTowerNumber
            // 
            txtTowerNumber.Anchor = AnchorStyles.Top;
            txtTowerNumber.Location = new Point(621, 73);
            txtTowerNumber.Name = "txtTowerNumber";
            txtTowerNumber.Size = new Size(156, 23);
            txtTowerNumber.TabIndex = 0;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(350, 68);
            label1.Name = "label1";
            label1.Size = new Size(265, 25);
            label1.TabIndex = 1;
            label1.Text = "Number of ring on the Tower :";
            // 
            // rtxtInfoDump
            // 
            rtxtInfoDump.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            rtxtInfoDump.Location = new Point(287, 102);
            rtxtInfoDump.Name = "rtxtInfoDump";
            rtxtInfoDump.ScrollBars = RichTextBoxScrollBars.Vertical;
            rtxtInfoDump.Size = new Size(921, 486);
            rtxtInfoDump.TabIndex = 3;
            rtxtInfoDump.Text = "";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Bottom;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(304, 610);
            label2.Name = "label2";
            label2.Size = new Size(311, 37);
            label2.TabIndex = 4;
            label2.Text = "Total Number Of Moves :\r\n";
            // 
            // lblNumMoves
            // 
            lblNumMoves.Anchor = AnchorStyles.Bottom;
            lblNumMoves.AutoSize = true;
            lblNumMoves.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNumMoves.Location = new Point(611, 610);
            lblNumMoves.Name = "lblNumMoves";
            lblNumMoves.Size = new Size(114, 37);
            lblNumMoves.TabIndex = 5;
            lblNumMoves.Text = "Number";
            // 
            // btnStart
            // 
            btnStart.Location = new Point(783, 70);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(100, 27);
            btnStart.TabIndex = 6;
            btnStart.Text = "Start The Tower";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStartTowerClick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1442, 759);
            Controls.Add(btnStart);
            Controls.Add(lblNumMoves);
            Controls.Add(label2);
            Controls.Add(rtxtInfoDump);
            Controls.Add(label1);
            Controls.Add(txtTowerNumber);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtTowerNumber;
        private Label label1;
        private RichTextBox rtxtInfoDump;
        private Label label2;
        private Label lblNumMoves;
        private Button btnStart;
    }
}
