namespace WhiteNoiseLoopGenerator
{
    partial class WhiteNoiseForm
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
            this.durationLbl = new System.Windows.Forms.Label();
            this.soundDurationTextBox = new System.Windows.Forms.TextBox();
            this.startStopBtn = new System.Windows.Forms.Button();
            this.volumeTrackBar = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.volumeTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // durationLbl
            // 
            this.durationLbl.AutoSize = true;
            this.durationLbl.Location = new System.Drawing.Point(30, 12);
            this.durationLbl.Name = "durationLbl";
            this.durationLbl.Size = new System.Drawing.Size(94, 13);
            this.durationLbl.TabIndex = 0;
            this.durationLbl.Text = "Noise Duration (s):";
            this.durationLbl.Click += new System.EventHandler(this.label1_Click);
            // 
            // soundDurationTextBox
            // 
            this.soundDurationTextBox.Location = new System.Drawing.Point(131, 9);
            this.soundDurationTextBox.MaxLength = 5;
            this.soundDurationTextBox.Name = "soundDurationTextBox";
            this.soundDurationTextBox.Size = new System.Drawing.Size(39, 20);
            this.soundDurationTextBox.TabIndex = 1;
            this.soundDurationTextBox.Text = "0.85";
            this.soundDurationTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.soundDurationTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.soundDurationTextBox_KeyPress);
            this.soundDurationTextBox.Enter += new System.EventHandler(this.soundDurationTextBox_Enter);
            this.soundDurationTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.soundDurationTextBox_Validating);
            // 
            // startStopBtn
            // 
            this.startStopBtn.Location = new System.Drawing.Point(72, 39);
            this.startStopBtn.Name = "startStopBtn";
            this.startStopBtn.Size = new System.Drawing.Size(75, 23);
            this.startStopBtn.TabIndex = 2;
            this.startStopBtn.Text = "Start";
            this.startStopBtn.UseVisualStyleBackColor = true;
            this.startStopBtn.Click += new System.EventHandler(this.startStopBtn_Click);
            // 
            // volumeTrackBar
            // 
            this.volumeTrackBar.Location = new System.Drawing.Point(197, 5);
            this.volumeTrackBar.Maximum = 100;
            this.volumeTrackBar.Minimum = 1;
            this.volumeTrackBar.Name = "volumeTrackBar";
            this.volumeTrackBar.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.volumeTrackBar.Size = new System.Drawing.Size(45, 65);
            this.volumeTrackBar.TabIndex = 3;
            this.volumeTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.volumeTrackBar.Value = 60;
            this.volumeTrackBar.ValueChanged += new System.EventHandler(this.volumeTrackBar_ValueChanged);
            // 
            // WhiteNoiseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(254, 74);
            this.Controls.Add(this.volumeTrackBar);
            this.Controls.Add(this.startStopBtn);
            this.Controls.Add(this.soundDurationTextBox);
            this.Controls.Add(this.durationLbl);
            this.Name = "WhiteNoiseForm";
            this.Text = "White Noise Loop Generator";
            ((System.ComponentModel.ISupportInitialize)(this.volumeTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label durationLbl;
        private System.Windows.Forms.TextBox soundDurationTextBox;
        private System.Windows.Forms.Button startStopBtn;
        private System.Windows.Forms.TrackBar volumeTrackBar;
    }
}

