using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace Noisey
{
    /// <summary>
    /// Very simple test form
    /// </summary>
    public class MainForm : System.Windows.Forms.Form
    {
        private System.Windows.Forms.Button buttonWhiteNoise;
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        Device applicationDevice;

        public MainForm()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            //
            // Add any constructor code after InitializeComponent call
            //
            applicationDevice = new Device();
            applicationDevice.SetCooperativeLevel(this, CooperativeLevel.Normal);
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
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
            this.buttonWhiteNoise = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonWhiteNoise
            // 
            this.buttonWhiteNoise.Location = new System.Drawing.Point(168, 48);
            this.buttonWhiteNoise.Name = "buttonWhiteNoise";
            this.buttonWhiteNoise.Size = new System.Drawing.Size(104, 23);
            this.buttonWhiteNoise.TabIndex = 0;
            this.buttonWhiteNoise.Text = "WhiteNoise";
            this.buttonWhiteNoise.Click += new System.EventHandler(this.buttonWhiteNoise_Click);
            // 
            // MainForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
            this.ClientSize = new System.Drawing.Size(292, 260);
            this.Controls.Add(this.buttonWhiteNoise);
            this.Name = "MainForm";
            this.Text = "Noisey";
            this.ResumeLayout(false);

        }
        #endregion

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.Run(new MainForm());
        }


        private void buttonWhiteNoise_Click(object sender, System.EventArgs e)
        {

            WaveFormat format = new WaveFormat();
            format.BitsPerSample = 8;
            format.Channels = 1;
            format.BlockAlign = 1;

            format.FormatTag = WaveFormatTag.Pcm;
            format.SamplesPerSecond = 8000; //sampling frequency of your data;   
            format.AverageBytesPerSecond = format.SamplesPerSecond * format.BlockAlign;

            // buffer description         
            BufferDescription desc = new BufferDescription(format);
            desc.DeferLocation = true;
            desc.BufferBytes = 3 * format.AverageBytesPerSecond;

            // create the buffer         
            //Device ApplicationDevice = new Device();

            SecondaryBuffer secondaryBuffer = new SecondaryBuffer(desc, applicationDevice);


            //generate ramdom data (white noise)
            byte[] rawsamples = new byte[22050];
            Random rnd1 = new System.Random();

            for (int i = 0; i < 22050; i++)
            {
                //-----------------------------------------------
                //Completely random
                //add a new audio sample to array
                rawsamples[i] = (byte)rnd1.Next(255);
                //-----------------------------------------------


                //-----------------------------------------------
                //-- Sine wave? (comment out for white noise)
                int convert = (int)(Math.Sin(i) * Math.PI);
                for (int index = 0; index < 2; index++)
                {
                    i += index;
                    rawsamples[i] = (byte)(convert >> (index * 8));
                }
                //-----------------------------------------------
            }

            //load audio samples to secondary buffer
            secondaryBuffer.Write(0, rawsamples, LockFlag.EntireBuffer);

            //play audio buffer			
            secondaryBuffer.Play(0, BufferPlayFlags.Default);

        }
    }
}


