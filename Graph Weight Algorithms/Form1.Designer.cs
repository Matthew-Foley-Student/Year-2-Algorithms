namespace Graph_Weight_Algorithms
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
            label2 = new Label();
            btnDisplay = new Button();
            rchTxtSolution = new RichTextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(217, 9);
            label1.Name = "label1";
            label1.Size = new Size(312, 30);
            label1.TabIndex = 0;
            label1.Text = "Supplied Data From the Graph";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(291, 39);
            label2.Name = "label2";
            label2.Size = new Size(155, 192);
            label2.TabIndex = 1;
            label2.Text = "W=\r\n(0,3,∞,∞,1)\r\n(∞,0,6,∞,3)\r\n(1.,∞,0,∞,∞)\r\n(-4,∞,5,0,∞)\r\n(∞,∞,2,2,0)";
            // 
            // btnDisplay
            // 
            btnDisplay.Location = new Point(302, 234);
            btnDisplay.Name = "btnDisplay";
            btnDisplay.Size = new Size(132, 52);
            btnDisplay.TabIndex = 2;
            btnDisplay.Text = "Display Results";
            btnDisplay.UseVisualStyleBackColor = true;
            btnDisplay.Click += VisibleLbl;
            // 
            // rchTxtSolution
            // 
            rchTxtSolution.Location = new Point(12, 292);
            rchTxtSolution.Name = "rchTxtSolution";
            rchTxtSolution.Size = new Size(776, 146);
            rchTxtSolution.TabIndex = 3;
            rchTxtSolution.Text = "";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(rchTxtSolution);
            Controls.Add(btnDisplay);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Button btnDisplay;
        private RichTextBox rchTxtSolution;
    }
}
