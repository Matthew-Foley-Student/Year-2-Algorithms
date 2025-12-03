namespace SplooshKaboom
{
    partial class frmComputerPlacements
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
            pnlEnemyBoard = new Panel();
            lblSub = new Label();
            lblDestroy = new Label();
            lblCruis = new Label();
            pnlPlayerBoard = new Panel();
            groupBox1 = new GroupBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // pnlEnemyBoard
            // 
            pnlEnemyBoard.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlEnemyBoard.Location = new Point(63, 44);
            pnlEnemyBoard.Name = "pnlEnemyBoard";
            pnlEnemyBoard.Size = new Size(400, 400);
            pnlEnemyBoard.TabIndex = 0;
            // 
            // lblSub
            // 
            lblSub.AutoSize = true;
            lblSub.Font = new Font("Stencil", 15.75F);
            lblSub.Location = new Point(6, 133);
            lblSub.Name = "lblSub";
            lblSub.Size = new Size(130, 25);
            lblSub.TabIndex = 1;
            lblSub.Text = "Submarine";
            // 
            // lblDestroy
            // 
            lblDestroy.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblDestroy.AutoSize = true;
            lblDestroy.Font = new Font("Stencil", 15.75F);
            lblDestroy.Location = new Point(6, 253);
            lblDestroy.Name = "lblDestroy";
            lblDestroy.Size = new Size(130, 25);
            lblDestroy.TabIndex = 2;
            lblDestroy.Text = "Destroyer";
            // 
            // lblCruis
            // 
            lblCruis.Anchor = AnchorStyles.Top;
            lblCruis.AutoSize = true;
            lblCruis.Font = new Font("Stencil", 15.75F);
            lblCruis.Location = new Point(6, 28);
            lblCruis.Name = "lblCruis";
            lblCruis.Size = new Size(100, 25);
            lblCruis.TabIndex = 3;
            lblCruis.Text = "Cruiser";
            // 
            // pnlPlayerBoard
            // 
            pnlPlayerBoard.Location = new Point(104, 471);
            pnlPlayerBoard.Name = "pnlPlayerBoard";
            pnlPlayerBoard.Size = new Size(300, 300);
            pnlPlayerBoard.TabIndex = 4;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = SystemColors.Control;
            groupBox1.Controls.Add(lblCruis);
            groupBox1.Controls.Add(lblSub);
            groupBox1.Controls.Add(lblDestroy);
            groupBox1.Font = new Font("Stencil", 9F);
            groupBox1.Location = new Point(492, 62);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(149, 303);
            groupBox1.TabIndex = 8;
            groupBox1.TabStop = false;
            groupBox1.Text = "Enemy Ships";
            // 
            // frmComputerPlacements
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(653, 783);
            Controls.Add(groupBox1);
            Controls.Add(pnlPlayerBoard);
            Controls.Add(pnlEnemyBoard);
            Name = "frmComputerPlacements";
            Text = "ComputerPlacements";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlEnemyBoard;
        private Label lblSub;
        private Label lblDestroy;
        private Label lblCruis;
        private Panel pnlPlayerBoard;
        private GroupBox groupBox1;
        private Label lblShots;
        private GroupBox lblDestroyerPlayer;
    }
}