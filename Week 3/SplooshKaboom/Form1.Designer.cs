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
            lblShipType = new Label();
            btnRotateShip = new Button();
            lblConfirm = new Button();
            btnPlay = new Button();
            btnReset = new Button();
            SuspendLayout();
            // 
            // pnlBoard
            // 
            pnlBoard.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlBoard.Location = new Point(149, 61);
            pnlBoard.Name = "pnlBoard";
            pnlBoard.Size = new Size(600, 600);
            pnlBoard.TabIndex = 1;
            // 
            // lblShipType
            // 
            lblShipType.AutoSize = true;
            lblShipType.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblShipType.Location = new Point(394, 9);
            lblShipType.Name = "lblShipType";
            lblShipType.Size = new Size(76, 32);
            lblShipType.TabIndex = 2;
            lblShipType.Text = "label1";
            // 
            // btnRotateShip
            // 
            btnRotateShip.Font = new Font("Segoe UI", 12F);
            btnRotateShip.Location = new Point(211, 667);
            btnRotateShip.Name = "btnRotateShip";
            btnRotateShip.Size = new Size(106, 32);
            btnRotateShip.TabIndex = 3;
            btnRotateShip.Text = "Rotate Ship";
            btnRotateShip.UseVisualStyleBackColor = true;
            btnRotateShip.Click += btnRotateShip_ClickEH;
            // 
            // lblConfirm
            // 
            lblConfirm.Font = new Font("Segoe UI", 12F);
            lblConfirm.Location = new Point(534, 667);
            lblConfirm.Name = "lblConfirm";
            lblConfirm.Size = new Size(159, 32);
            lblConfirm.TabIndex = 4;
            lblConfirm.Text = "Confirm Placement";
            lblConfirm.UseVisualStyleBackColor = true;
            lblConfirm.Click += btnConfirm_ClickEH;
            // 
            // btnPlay
            // 
            btnPlay.Font = new Font("Segoe UI", 12F);
            btnPlay.Location = new Point(394, 731);
            btnPlay.Name = "btnPlay";
            btnPlay.Size = new Size(75, 37);
            btnPlay.TabIndex = 5;
            btnPlay.Text = "Play";
            btnPlay.UseVisualStyleBackColor = true;
            btnPlay.Click += btnPlay_ClickEH;
            // 
            // btnReset
            // 
            btnReset.Font = new Font("Segoe UI", 12F);
            btnReset.Location = new Point(395, 667);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(75, 32);
            btnReset.TabIndex = 6;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_ClickEH;
            // 
            // frmPlayerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(883, 794);
            Controls.Add(btnReset);
            Controls.Add(btnPlay);
            Controls.Add(lblConfirm);
            Controls.Add(btnRotateShip);
            Controls.Add(lblShipType);
            Controls.Add(pnlBoard);
            Name = "frmPlayerForm";
            Text = "Form1";
            Load += StartTheProgram;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Panel pnlBoard;
        private Label lblShipType;
        private Button btnRotateShip;
        private Button lblConfirm;
        private Button btnPlay;
        private Button btnReset;
    }
}
