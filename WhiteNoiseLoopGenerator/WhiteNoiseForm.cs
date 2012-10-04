using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Media;

using Microsoft.DirectX.DirectSound;
using DS = Microsoft.DirectX.DirectSound;

namespace WhiteNoiseLoopGenerator
{
    public partial class WhiteNoiseForm : Form
    {
        private bool soundPlaying = false;
        private DS.Device soundDevice;
        SecondaryBuffer activeSoundBuffer;
        String lastDurationVal;

        public WhiteNoiseForm()
        {
            InitializeComponent();
            InitializeSound();

            lastDurationVal = soundDurationTextBox.Text;
        }

        private void InitializeSound()
        {
            soundDevice = new DS.Device();
            soundDevice.SetCooperativeLevel(this, CooperativeLevel.Normal);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void startStopBtn_Click(object sender, EventArgs e)
        {
            if (soundPlaying)
            {
                stopPlayback();
                startStopBtn.Text = "Start";
                soundDurationTextBox.Enabled = true;
                soundDurationTextBox.Focus();
                soundDurationTextBox.SelectAll();
                soundPlaying = false;
            }
            else
            {
                startStopBtn.Text = "Stop";
                soundPlaying = true;
                soundDurationTextBox.Enabled = false;
                startPlaybackDirectSound();
            }
        }

        private void stopPlayback()
        {
            activeSoundBuffer.Stop();
        }

        
        private void startPlayback()
        {
            SoundPlayer simpleSound = new SoundPlayer(@"c:\Windows\Media\chimes.wav");
            simpleSound.Play();

        }

        
        private void startPlaybackDirectSound()
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
            desc.ControlVolume = true;
            double bytesEstimate = getSoundDuration() * ((double)format.AverageBytesPerSecond);
            desc.BufferBytes = Convert.ToInt32(bytesEstimate);

            // create the buffer         
            //Device ApplicationDevice = new Device();

            activeSoundBuffer = new SecondaryBuffer(desc, soundDevice);
            setVolume();


            //generate ramdom data (white noise)
            byte[] rawsamples = new byte[desc.BufferBytes];
            Random rnd = new System.Random();

            for (int i = 0; i < desc.BufferBytes; i++)
            {
                //-----------------------------------------------
                //Completely random
                //add a new audio sample to array
                rawsamples[i] = (byte)rnd.Next(255);
                //-----------------------------------------------
                 
            }


            //load audio samples to secondary buffer
            activeSoundBuffer.Write(0, rawsamples, LockFlag.EntireBuffer);

            activeSoundBuffer.Play(0, BufferPlayFlags.Looping);

        }

        private double getSoundDuration()
        {
            return Convert.ToDouble(soundDurationTextBox.Text);
        }

        private void volumeTrackBar_ValueChanged(object sender, EventArgs e)
        {
            setVolume();
        }

        private void setVolume()
        {
            double logVolume = Math.Log10(volumeTrackBar.Value);

            if (activeSoundBuffer != null)
                activeSoundBuffer.Volume = (int)((2 - logVolume) * -5000);
        }

        private void soundDurationTextBox_Enter(object sender, EventArgs e)
        {
            soundDurationTextBox.SelectAll();
        }

        private void soundDurationTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.') {
                if(soundDurationTextBox.Text.Contains("."))
                    e.Handled = true;
                else
                    e.Handled = false;
            }
            else if (Char.IsNumber(e.KeyChar) || Char.IsControl(e.KeyChar))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void soundDurationTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (getSoundDuration() > 15)
                soundDurationTextBox.Text = "15";
        }

    } 
}
