namespace SplooshKaboom
{
    partial class frmPlayerForm
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
            pnlBoard = new Panel();
            lblSub = new Label();
            lblDestroy = new Label();
            lblCruiser = new Label();
            lblExplination = new Label();
            SuspendLayout();
            // 
            // pnlBoard
            // 
            pnlBoard.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlBoard.Location = new Point(88, 82);
            pnlBoard.Name = "pnlBoard";
            pnlBoard.Size = new Size(700, 700);
            pnlBoard.TabIndex = 1;
            // 
            // lblSub
            // 
            lblSub.Anchor = AnchorStyles.Left;
            lblSub.AutoSize = true;
            lblSub.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSub.Location = new Point(12, 12);
            lblSub.Name = "lblSub";
            lblSub.Size = new Size(144, 37);
            lblSub.TabIndex = 2;
            lblSub.Text = "Submarine";
            // 
            // lblDestroy
            // 
            lblDestroy.Anchor = AnchorStyles.Right;
            lblDestroy.AutoSize = true;
            lblDestroy.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDestroy.Location = new Point(740, 12);
            lblDestroy.Name = "lblDestroy";
            lblDestroy.Size = new Size(131, 37);
            lblDestroy.TabIndex = 3;
            lblDestroy.Text = "Destroyer";
            // 
            // lblCruiser
            // 
            lblCruiser.AutoSize = true;
            lblCruiser.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCruiser.Location = new Point(389, 12);
            lblCruiser.Name = "lblCruiser";
            lblCruiser.Size = new Size(99, 37);
            lblCruiser.TabIndex = 4;
            lblCruiser.Text = "Cruiser";
            // 
            // lblExplination
            // 
            lblExplination.Anchor = AnchorStyles.Top;
            lblExplination.AutoSize = true;
            lblExplination.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblExplination.Location = new Point(270, 16);
            lblExplination.Name = "lblExplination";
            lblExplination.Size = new Size(318, 63);
            lblExplination.TabIndex = 5;
            lblExplination.Text = "Left click a square to attempt to place a ship\r\nMiddle click to change its rotation\r\nRight click to display the ship but not place it";
            // 
            // frmPlayerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(883, 794);
            Controls.Add(lblExplination);
            Controls.Add(lblCruiser);
            Controls.Add(lblDestroy);
            Controls.Add(lblSub);
            Controls.Add(pnlBoard);
            Name = "frmPlayerForm";
            Text = "Form1";
            Load += StartTheProgram;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Panel pnlBoard;
        private Label lblSub;
        private Label lblDestroy;
        private Label lblCruiser;
        private Label lblExplination;
    }
}
