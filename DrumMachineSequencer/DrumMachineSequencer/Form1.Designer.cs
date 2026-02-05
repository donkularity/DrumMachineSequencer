namespace DrumMachineSequencer
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
            btnPlay = new Button();
            btnStop = new Button();
            numBpm = new NumericUpDown();
            lblBpm = new Label();
            gridPanel = new TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)numBpm).BeginInit();
            SuspendLayout();
            // 
            // btnPlay
            // 
            btnPlay.Location = new Point(27, 316);
            btnPlay.Name = "btnPlay";
            btnPlay.Size = new Size(164, 99);
            btnPlay.TabIndex = 0;
            btnPlay.Text = "PLAY";
            btnPlay.UseVisualStyleBackColor = true;
            btnPlay.Click += btnPlay_Click;
            // 
            // btnStop
            // 
            btnStop.Location = new Point(224, 316);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(164, 99);
            btnStop.TabIndex = 1;
            btnStop.Text = "STOP";
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += btnStop_Click;
            // 
            // numBpm
            // 
            numBpm.Location = new Point(451, 316);
            numBpm.Name = "numBpm";
            numBpm.Size = new Size(131, 23);
            numBpm.TabIndex = 2;
            // 
            // lblBpm
            // 
            lblBpm.AutoSize = true;
            lblBpm.Location = new Point(513, 726);
            lblBpm.Name = "lblBpm";
            lblBpm.Size = new Size(38, 15);
            lblBpm.TabIndex = 3;
            lblBpm.Text = "label1";
            lblBpm.Click += lblBpm_Click;
            // 
            // gridPanel
            // 
            gridPanel.ColumnCount = 16;
            gridPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 51.31579F));
            gridPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 48.68421F));
            gridPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 73F));
            gridPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 104F));
            gridPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 125F));
            gridPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 99F));
            gridPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 94F));
            gridPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
            gridPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 95F));
            gridPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 93F));
            gridPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 94F));
            gridPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 88F));
            gridPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 88F));
            gridPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 75F));
            gridPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 64F));
            gridPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 48F));
            gridPanel.Dock = DockStyle.Top;
            gridPanel.Location = new Point(0, 0);
            gridPanel.Name = "gridPanel";
            gridPanel.RowCount = 3;
            gridPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            gridPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            gridPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 92F));
            gridPanel.Size = new Size(1393, 289);
            gridPanel.TabIndex = 4;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1393, 856);
            Controls.Add(gridPanel);
            Controls.Add(lblBpm);
            Controls.Add(numBpm);
            Controls.Add(btnStop);
            Controls.Add(btnPlay);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)numBpm).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnPlay;
        private Button btnStop;
        private NumericUpDown numBpm;
        private Label lblBpm;
        private TableLayoutPanel gridPanel;
    }
}