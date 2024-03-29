﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Threading;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.IO;

namespace BarnsleyFern
{
  public partial class Form1 : Form
    {
        ColourPicker c;

        public static double[,] coeffs;

        double steps, stepsCompleted;

        DateTime startTime;

        bool isPlaying;

        bool isComplete;

        Bitmap fileBitMap = null;

        public static Color colour;

        double x, y;

        int dim;
        int xdisplacement;
        int multiplier;
        int maxY;

        private List<Tuple<double, double>> pointsList = new List<Tuple<double, double>>();

        string filenameImage;
        string filenamePoints;

        Thread logicThread;

        StatusForm s;

        bool isClosing;

        public Form1()
        {
            InitializeComponent();

            steps = stepsCompleted = 0;
            dim = 0;

            maxY = 0;

            TrySetVals();

            coeffs = new double[4, 7];
            SetDefaultCoeffs();

            isPlaying = false;

            isComplete = false;

            SetStates();

            x = y = 0;

            fileBitMap = null;

            colour = Color.Black;

            s = null;

            ColourButton.Enabled = false;
            c = new ColourPicker();
            ColourButton.Enabled = true;

            isClosing = false;
        }

        void TrySetVals()
        {
            try
            {
                steps = Convert.ToDouble(StepsInput.Text);

                dim = Convert.ToInt32(DimensionInput.Text);
                xdisplacement = dim / 2;
                multiplier = dim / 10;
                maxY = dim - 1;

                SetStates();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }


        void SetStates()
        {
            GoButton.Enabled = false;
            PauseButton.Enabled = false;
            StopButton.Enabled = false;
            SaveButton.Enabled = false;
            CheckProgressButton.Enabled = false;
            if (
                (steps > 0) &&
                (dim > 0)
                )
            {
                if (isPlaying == false)
                {
                    ConfigPanel.Enabled = true;
                    GoButton.Enabled = true;
                    PauseButton.Enabled = false;
                    StopButton.Enabled = false;
                    CheckProgressButton.Enabled = false;
                }
                else
                {
                    ConfigPanel.Enabled = false;
                    GoButton.Enabled = false;
                    PauseButton.Enabled = true;
                    StopButton.Enabled = true;
                    CheckProgressButton.Enabled = true;
                }
            }

            OpenImageButton.Enabled = isComplete;
            OpenPointsFileButton.Enabled = isComplete;
        }

        void SetDefaultCoeffs()
        {
            for (int row = 0; row < 4; ++row)
            {
                for (int col = 0; col < 7; ++col)
                {
                    coeffs[row, col] = BarnsleyCommon.defaultCoeffs[row, col];
                }
            }
        }

        private void StepsInput_TextChanged(object sender, EventArgs e)
        {
            TrySetVals();
        }

        private void DimensionInput_TextChanged(object sender, EventArgs e)
        {
            TrySetVals();
        }

        private void GoButton_Click(object sender, EventArgs e)
        {
            PauseButton.Text = "Pause";

            isPlaying = true;
            isComplete = false;
            SetStates();

            logicThread = new Thread(PlayGame);
            logicThread.Name = "LogicThread";
            logicThread.Start();
        }

        void PlayGame()
        { 
            if (GenerateImageFileCheckBox.Checked)
            {
              try
              {
                fileBitMap = new Bitmap(dim, dim, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
              }
              catch (Exception ex)
              {
                Console.WriteLine(ex.ToString());
                fileBitMap = null;
                Restart_Threadsafe();
                return;
              }
            }

            startTime = DateTime.Now;

            PlotPoint(); //Plots very first point x = y = 0;

            double random;

            Random rnd = new Random(DateTime.Now.Millisecond);

            stepsCompleted = 0;

            while (stepsCompleted < steps)
            {
                random = (double)rnd.Next(1, 101)/100;

                int f = -1;

                if (random < coeffs[1,6])//f2
                {
                    f = 1;
                }
                else if (random < (coeffs[1,6]+coeffs[2,6]) )//(f2+f3))
                {
                    f = 2;
                }
                else if (random < (coeffs[1,6] + coeffs[2,6] + coeffs[3,6]) )//(f2+f3+f4))
                {
                    f = 3;
                }
                else //Surely this will be f1
                {
                    f = 0;
                }

                double xtemp = x;
                double ytemp = y;
                x = (xtemp * coeffs[f,0]) + (ytemp * coeffs[f,1]) + coeffs[f,4];
                y = (xtemp * coeffs[f,2]) + (ytemp * coeffs[f,3]) + coeffs[f,5];

                PlotPoint();

                if (GeneratePointsListCheckBox.Checked)
                {
                  pointsList.Add(new Tuple<double, double>(x, y));
                }

                ++stepsCompleted;


                if (isClosing == true)
                {
                    break;
                }
            }

            SignalGameComplete_ThreadSafe();
        }

        void PlotPoint()
        {
            if (GenerateImageFileCheckBox.Checked == false)
            {
              return;
            }

            int xPixel = xdisplacement + (int)(multiplier * x);
            int yPixel = (int)(multiplier * y);

            if  (
                (xPixel < 0)    ||
                (yPixel < 0)    ||
                (xPixel >= dim) ||
                (yPixel >= dim)
                )
            {
                return;
            }

            //We flip each pixel vertically, seeing as the fern is otherwise being drawn upside down.
            yPixel = maxY - yPixel;

            fileBitMap.SetPixel(xPixel, yPixel, colour);
        }

        delegate void SignalGameCompleteCallback();
        private void SignalGameComplete_ThreadSafe()
        {
            if (this.InvokeRequired)
            {
                SignalGameCompleteCallback d = new SignalGameCompleteCallback(SignalGameComplete_ThreadSafe);
                this.Invoke(d, new object[] { });
            }
            else
            {
                Save_ThreadSafe();

                try
                {
                  s.Close();
                }
                catch (Exception e) { }

                isPlaying = false;
                isComplete = true;
                SetStates();
            }
        }

        delegate void Save_Callback();
        void Save_ThreadSafe()
        {
            if (this.InvokeRequired)
            {
              Save_Callback d = new Save_Callback(Save_ThreadSafe);
              this.Invoke(d, new object[] { });
            }
            else
            {
                if (GenerateImageFileCheckBox.Checked)
                {
                  PaintConfigInfo(fileBitMap);
                  filenameImage = "Fern_" + stepsCompleted + "_" + DateTime.Now.ToString("h.mm.ss.tt") + ".png";
                  fileBitMap.Save(filenameImage, ImageFormat.Png);
                  fileBitMap.Dispose();
                  GC.Collect();

                  if (ImageAutoOpenCheckbox.Checked)
                  {
                    OpenFile(filenameImage);
                  }
                }

                if (pointsList.Count > 0)
                {
                  filenamePoints = "Fern_" + stepsCompleted + "_" + DateTime.Now.ToString("h.mm.ss.tt") + ".txt";

                  WriteConfigToFile();

                  WritePointsToFile();

                  if (AutoOpenPointsFileCheckBox.Checked)
                  {
                    OpenFile(filenamePoints);
                  }
                }
            }
        }

        void PaintConfigInfo(Bitmap bmp)
        {
            string infoString = GetConfigInfoString();

            Graphics g = Graphics.FromImage(bmp);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.DrawString(infoString, new Font("Calibri", 14), Brushes.Black, new Point(5,5));
            g.Flush();
            g.Dispose();
        }

        string GetConfigInfoString()
        {
            string infoString = "";
            for (int row = 0; row < 4; ++row)
            {
              for (int col = 0; col < 7; ++col)
              {
                infoString += "[";
                infoString += Convert.ToString(coeffs[row, col]);
                infoString += "]";
              }
              infoString += "\n";
            }
            infoString += "Steps: " + stepsCompleted + " / " + steps + " (" + (int)((stepsCompleted / steps) * 100) + "%)" + "\n";

            infoString += "Dim: " + dim + "px\n";

            TimeSpan elapsed = DateTime.Now - startTime;
            infoString += "Time Taken: " + string.Format("{0:D2}h:{1:D2}m:{2:D2}s", elapsed.Hours, elapsed.Minutes, elapsed.Seconds) + "\n";

            return infoString;
        }

        void OpenFile(string filename) 
        {
            try
            {
                Process process = new Process();
                process.StartInfo.FileName = filename;
                process.Start();
            }
            catch(Exception ex)
            {
                ex.ToString();
                MessageBox.Show(Parent, "File '" + filename + "' may have been deleted from drive.");
            }
        }

        private void PauseButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (PauseButton.Text == "Pause")
                {
                    logicThread.Suspend();
                    isPlaying = false;
                    PauseButton.Text = "Play";
                    SaveButton.Enabled = true;
                }
                else
                {
                    logicThread.Resume();
                    isPlaying = true;
                    PauseButton.Text = "Pause";
                    SaveButton.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            isPlaying = false;
            isComplete = true;
            TryKillLogicThread();
            Save_ThreadSafe();
            SetStates();
        }

        private void advancedButton_Click(object sender, EventArgs e)
        {
            AdvancedForm advancedForm = new AdvancedForm();
            advancedForm.ShowDialog();
        }

        private void OpenImageButton_Click(object sender, EventArgs e)
        {
            OpenFile(filenameImage);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            isClosing = true;

            TryKillLogicThread();

            //Possibly have a forced close. 
            //Let's just save what we have. 
            if (isPlaying == true)
            {
                Save_ThreadSafe();
            }

            c.Close();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            Save_Intermediate();
        }

        void Save_Intermediate()
        {
            try
            {
                if (GenerateImageFileCheckBox.Checked)
                {
                    Bitmap btemp = new Bitmap(fileBitMap);
                    PaintConfigInfo(btemp);
                    filenameImage = "Fern_" + stepsCompleted + "_" + DateTime.Now.ToString("h.mm.ss.tt") + ".png";
                    btemp.Save(filenameImage, ImageFormat.Png);
                    btemp.Dispose();
                    GC.Collect();

                    if (ImageAutoOpenCheckbox.Checked)
                    {
                        OpenFile(filenameImage);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show(Parent, "Failed to save an image due to large dimensions chosen.\n\nA final image can be saved if you :\n\na) Click the 'Play' button and let the program complete its current run.\n\nor\n\nb) Click the 'Stop' button and end the current run.");
            }

            try
            {
              if (pointsList.Count > 0)
              {
                filenamePoints = "Fern_" + stepsCompleted + "_" + DateTime.Now.ToString("h.mm.ss.tt") + ".txt";
                
                WriteConfigToFile();

                WritePointsToFile();

                if (AutoOpenPointsFileCheckBox.Checked)
                {
                  OpenFile(filenamePoints);
                }
              }
            }
            catch (Exception ex)
            {
              Console.WriteLine(ex.ToString());
              MessageBox.Show(Parent, "Failed to save points file '" + filenamePoints + "' for some reason... :(");
            }
        }

        void WriteConfigToFile()
        {
            string infoString = GetConfigInfoString();
            StreamWriter sw = new StreamWriter(filenamePoints, true); 
            sw.WriteLine(infoString);
            sw.Close();
        }

        void WritePointsToFile()
        {
            StreamWriter sw = new StreamWriter(filenamePoints, true);
            foreach (var point in pointsList)
            {
              sw.WriteLine(point.Item1 + " , " + point.Item2);
            }
            sw.Close();
            pointsList.Clear();
            pointsList = new List<Tuple<double, double>>();
            GC.Collect();
        }

        public void CheckProgressButton_Click(object sender, EventArgs e)
        {
            InvokeSummaryForm();
        }

        void InvokeSummaryForm()
        {
            string ETAString = "[No accurate time remaining estimate available.\n\nHit 'Refresh' bitton.]";
            double percentComplete = Math.Round((stepsCompleted / steps) * 100, 2);
            if (percentComplete > 0)
            {
                double secondsPerPercent = (DateTime.Now - startTime).TotalSeconds / percentComplete;
                double ETASeconds = secondsPerPercent * (100 - percentComplete);
                TimeSpan t = TimeSpan.FromSeconds(ETASeconds);
                ETAString = string.Format("E.T.A: {0:D2}h:{1:D2}m:{2:D2}s", t.Hours, t.Minutes, t.Seconds) + "\n\n";
            }

            if (isPlaying == false)
            {
                ETAString += "Hit the 'resume' button to continue execution,\nor dismiss this dialog and hit the 'Play' button.";
            }

            string stepsString = "Steps Complete: " + stepsCompleted + " of " + steps + "\n\n";
            stepsString += "Percent Complete: " + percentComplete + "%\n\n";

            string header = "";
            if (isPlaying == true)
            {
                header = "In Progress";
            }
            else
            {
                header = "PAUSED";
            }

            s = new StatusForm(header, (stepsString + ETAString), isPlaying);

            DialogResult r = s.ShowDialog();
            if (r == DialogResult.Retry)
            {
                InvokeSummaryForm();
            }
            else if (r == DialogResult.Yes)
            {
                logicThread.Resume();
                isPlaying = true;
                PauseButton.Text = "Pause";
                SaveButton.Enabled = false;
            }
        }

        void TryKillLogicThread()
        {
            try
            {
                if (logicThread != null)
                {
                    logicThread.Abort();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void ColourButton_Click(object sender, EventArgs e)
        {
            c.ShowDialog();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            About about = new About();
            about.ShowDialog();
        }

    private void GeneratePointsListCheckBox_CheckedChanged(object sender, EventArgs e)
    {
      AutoOpenPointsFileCheckBox.Enabled = GeneratePointsListCheckBox.Checked;
      OpenPointsFileButton.Enabled = GeneratePointsListCheckBox.Checked && isComplete;
    }

    private void GenerateImageFileCheckBox_CheckedChanged(object sender, EventArgs e)
    {
      ImageAutoOpenCheckbox.Enabled = GenerateImageFileCheckBox.Checked;
      OpenImageButton.Enabled = GenerateImageFileCheckBox.Checked && isComplete;
    }

    delegate void RestartCallback();
        private void Restart_Threadsafe()
        {
            if (this.InvokeRequired)
            {
                RestartCallback d = new RestartCallback(Restart_Threadsafe);
                this.Invoke(d, new object[] { });
            }
            else
            {
                MessageBox.Show(Parent, "Failed to create bitmap - dimensions too large.\nPlease specify a smaller image width/height.");
                isPlaying = false;
                isComplete = true;
                SetStates();
            }
        }

    }
}
