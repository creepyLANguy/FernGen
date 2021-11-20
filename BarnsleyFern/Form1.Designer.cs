namespace BarnsleyFern
{
    partial class Form1
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
      this.label1 = new System.Windows.Forms.Label();
      this.StepsInput = new System.Windows.Forms.TextBox();
      this.GoButton = new System.Windows.Forms.Button();
      this.ConfigPanel = new System.Windows.Forms.Panel();
      this.ColourButton = new System.Windows.Forms.Button();
      this.advancedButton = new System.Windows.Forms.Button();
      this.label4 = new System.Windows.Forms.Label();
      this.DimensionInput = new System.Windows.Forms.TextBox();
      this.StopButton = new System.Windows.Forms.Button();
      this.PauseButton = new System.Windows.Forms.Button();
      this.ImagePanel = new System.Windows.Forms.Panel();
      this.OpenImageButton = new System.Windows.Forms.Button();
      this.ImageAutoOpenCheckbox = new System.Windows.Forms.CheckBox();
      this.label3 = new System.Windows.Forms.Label();
      this.SaveButton = new System.Windows.Forms.Button();
      this.CheckProgressButton = new System.Windows.Forms.Button();
      this.panel1 = new System.Windows.Forms.Panel();
      this.linkLabel1 = new System.Windows.Forms.LinkLabel();
      this.FilePanel = new System.Windows.Forms.Panel();
      this.OpenPointsFileButton = new System.Windows.Forms.Button();
      this.GeneratePointsListCheckBox = new System.Windows.Forms.CheckBox();
      this.AutoOpenPointsFileCheckBox = new System.Windows.Forms.CheckBox();
      this.GenerateImageFileCheckBox = new System.Windows.Forms.CheckBox();
      this.ConfigPanel.SuspendLayout();
      this.ImagePanel.SuspendLayout();
      this.panel1.SuspendLayout();
      this.FilePanel.SuspendLayout();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(17, 9);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(37, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "Steps:";
      // 
      // StepsInput
      // 
      this.StepsInput.Location = new System.Drawing.Point(20, 25);
      this.StepsInput.Name = "StepsInput";
      this.StepsInput.Size = new System.Drawing.Size(109, 20);
      this.StepsInput.TabIndex = 1;
      this.StepsInput.Text = "5000000";
      this.StepsInput.TextChanged += new System.EventHandler(this.StepsInput_TextChanged);
      // 
      // GoButton
      // 
      this.GoButton.Location = new System.Drawing.Point(20, 9);
      this.GoButton.Name = "GoButton";
      this.GoButton.Size = new System.Drawing.Size(108, 32);
      this.GoButton.TabIndex = 2;
      this.GoButton.Text = "Go!";
      this.GoButton.UseVisualStyleBackColor = true;
      this.GoButton.Click += new System.EventHandler(this.GoButton_Click);
      // 
      // ConfigPanel
      // 
      this.ConfigPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.ConfigPanel.Controls.Add(this.ColourButton);
      this.ConfigPanel.Controls.Add(this.advancedButton);
      this.ConfigPanel.Controls.Add(this.label4);
      this.ConfigPanel.Controls.Add(this.DimensionInput);
      this.ConfigPanel.Controls.Add(this.label1);
      this.ConfigPanel.Controls.Add(this.StepsInput);
      this.ConfigPanel.Location = new System.Drawing.Point(12, 32);
      this.ConfigPanel.Name = "ConfigPanel";
      this.ConfigPanel.Size = new System.Drawing.Size(150, 143);
      this.ConfigPanel.TabIndex = 3;
      // 
      // ColourButton
      // 
      this.ColourButton.Image = ((System.Drawing.Image)(resources.GetObject("ColourButton.Image")));
      this.ColourButton.Location = new System.Drawing.Point(104, 106);
      this.ColourButton.Name = "ColourButton";
      this.ColourButton.Size = new System.Drawing.Size(25, 24);
      this.ColourButton.TabIndex = 11;
      this.ColourButton.UseVisualStyleBackColor = true;
      this.ColourButton.Click += new System.EventHandler(this.ColourButton_Click);
      // 
      // advancedButton
      // 
      this.advancedButton.Location = new System.Drawing.Point(21, 106);
      this.advancedButton.Name = "advancedButton";
      this.advancedButton.Size = new System.Drawing.Size(78, 24);
      this.advancedButton.TabIndex = 8;
      this.advancedButton.Text = "Advanced";
      this.advancedButton.UseVisualStyleBackColor = true;
      this.advancedButton.Click += new System.EventHandler(this.advancedButton_Click);
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(17, 57);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(81, 13);
      this.label4.TabIndex = 6;
      this.label4.Text = "Image w/h (px):";
      // 
      // DimensionInput
      // 
      this.DimensionInput.Location = new System.Drawing.Point(20, 73);
      this.DimensionInput.Name = "DimensionInput";
      this.DimensionInput.Size = new System.Drawing.Size(109, 20);
      this.DimensionInput.TabIndex = 7;
      this.DimensionInput.Text = "3500";
      this.DimensionInput.TextChanged += new System.EventHandler(this.DimensionInput_TextChanged);
      // 
      // StopButton
      // 
      this.StopButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.StopButton.Location = new System.Drawing.Point(78, 85);
      this.StopButton.Name = "StopButton";
      this.StopButton.Size = new System.Drawing.Size(49, 32);
      this.StopButton.TabIndex = 3;
      this.StopButton.Text = "Stop";
      this.StopButton.UseVisualStyleBackColor = true;
      this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
      // 
      // PauseButton
      // 
      this.PauseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.PauseButton.Location = new System.Drawing.Point(20, 47);
      this.PauseButton.Name = "PauseButton";
      this.PauseButton.Size = new System.Drawing.Size(49, 32);
      this.PauseButton.TabIndex = 2;
      this.PauseButton.Text = "Pause";
      this.PauseButton.UseVisualStyleBackColor = true;
      this.PauseButton.Click += new System.EventHandler(this.PauseButton_Click);
      // 
      // ImagePanel
      // 
      this.ImagePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.ImagePanel.Controls.Add(this.GenerateImageFileCheckBox);
      this.ImagePanel.Controls.Add(this.OpenImageButton);
      this.ImagePanel.Controls.Add(this.ImageAutoOpenCheckbox);
      this.ImagePanel.Location = new System.Drawing.Point(12, 421);
      this.ImagePanel.Name = "ImagePanel";
      this.ImagePanel.Size = new System.Drawing.Size(150, 108);
      this.ImagePanel.TabIndex = 5;
      // 
      // OpenImageButton
      // 
      this.OpenImageButton.Location = new System.Drawing.Point(16, 70);
      this.OpenImageButton.Name = "OpenImageButton";
      this.OpenImageButton.Size = new System.Drawing.Size(109, 23);
      this.OpenImageButton.TabIndex = 1;
      this.OpenImageButton.Text = "Open Image";
      this.OpenImageButton.UseVisualStyleBackColor = true;
      this.OpenImageButton.Click += new System.EventHandler(this.OpenImageButton_Click);
      // 
      // ImageAutoOpenCheckbox
      // 
      this.ImageAutoOpenCheckbox.AutoSize = true;
      this.ImageAutoOpenCheckbox.Checked = true;
      this.ImageAutoOpenCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
      this.ImageAutoOpenCheckbox.Location = new System.Drawing.Point(16, 37);
      this.ImageAutoOpenCheckbox.Name = "ImageAutoOpenCheckbox";
      this.ImageAutoOpenCheckbox.Size = new System.Drawing.Size(106, 17);
      this.ImageAutoOpenCheckbox.TabIndex = 0;
      this.ImageAutoOpenCheckbox.Text = "Auto open image";
      this.ImageAutoOpenCheckbox.UseVisualStyleBackColor = true;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(29, 9);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(121, 13);
      this.label3.TabIndex = 6;
      this.label3.Text = "Barnsley Fern Generator";
      // 
      // SaveButton
      // 
      this.SaveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.SaveButton.Location = new System.Drawing.Point(78, 47);
      this.SaveButton.Name = "SaveButton";
      this.SaveButton.Size = new System.Drawing.Size(49, 32);
      this.SaveButton.TabIndex = 8;
      this.SaveButton.Text = "Save";
      this.SaveButton.UseVisualStyleBackColor = true;
      this.SaveButton.Click += new System.EventHandler(this.saveButton_Click);
      // 
      // CheckProgressButton
      // 
      this.CheckProgressButton.Location = new System.Drawing.Point(21, 85);
      this.CheckProgressButton.Name = "CheckProgressButton";
      this.CheckProgressButton.Size = new System.Drawing.Size(48, 32);
      this.CheckProgressButton.TabIndex = 9;
      this.CheckProgressButton.Text = "Check";
      this.CheckProgressButton.UseVisualStyleBackColor = true;
      this.CheckProgressButton.Click += new System.EventHandler(this.CheckProgressButton_Click);
      // 
      // panel1
      // 
      this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.panel1.Controls.Add(this.CheckProgressButton);
      this.panel1.Controls.Add(this.GoButton);
      this.panel1.Controls.Add(this.SaveButton);
      this.panel1.Controls.Add(this.PauseButton);
      this.panel1.Controls.Add(this.StopButton);
      this.panel1.Location = new System.Drawing.Point(12, 181);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(150, 126);
      this.panel1.TabIndex = 10;
      // 
      // linkLabel1
      // 
      this.linkLabel1.AutoSize = true;
      this.linkLabel1.Location = new System.Drawing.Point(12, 542);
      this.linkLabel1.Name = "linkLabel1";
      this.linkLabel1.Size = new System.Drawing.Size(150, 13);
      this.linkLabel1.TabIndex = 11;
      this.linkLabel1.TabStop = true;
      this.linkLabel1.Text = "Created by Altamish Mahomed";
      this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
      // 
      // FilePanel
      // 
      this.FilePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.FilePanel.Controls.Add(this.AutoOpenPointsFileCheckBox);
      this.FilePanel.Controls.Add(this.OpenPointsFileButton);
      this.FilePanel.Controls.Add(this.GeneratePointsListCheckBox);
      this.FilePanel.Location = new System.Drawing.Point(12, 313);
      this.FilePanel.Name = "FilePanel";
      this.FilePanel.Size = new System.Drawing.Size(150, 102);
      this.FilePanel.TabIndex = 6;
      // 
      // OpenPointsFileButton
      // 
      this.OpenPointsFileButton.Location = new System.Drawing.Point(20, 63);
      this.OpenPointsFileButton.Name = "OpenPointsFileButton";
      this.OpenPointsFileButton.Size = new System.Drawing.Size(109, 23);
      this.OpenPointsFileButton.TabIndex = 1;
      this.OpenPointsFileButton.Text = "Open Points File";
      this.OpenPointsFileButton.UseVisualStyleBackColor = true;
      // 
      // GeneratePointsListCheckBox
      // 
      this.GeneratePointsListCheckBox.AutoSize = true;
      this.GeneratePointsListCheckBox.Checked = true;
      this.GeneratePointsListCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
      this.GeneratePointsListCheckBox.Location = new System.Drawing.Point(16, 12);
      this.GeneratePointsListCheckBox.Name = "GeneratePointsListCheckBox";
      this.GeneratePointsListCheckBox.Size = new System.Drawing.Size(117, 17);
      this.GeneratePointsListCheckBox.TabIndex = 0;
      this.GeneratePointsListCheckBox.Text = "Generate points file";
      this.GeneratePointsListCheckBox.UseVisualStyleBackColor = true;
      this.GeneratePointsListCheckBox.CheckedChanged += new System.EventHandler(this.GeneratePointsListCheckBox_CheckedChanged);
      // 
      // AutoOpenPointsFileCheckBox
      // 
      this.AutoOpenPointsFileCheckBox.AutoSize = true;
      this.AutoOpenPointsFileCheckBox.Checked = true;
      this.AutoOpenPointsFileCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
      this.AutoOpenPointsFileCheckBox.Location = new System.Drawing.Point(16, 35);
      this.AutoOpenPointsFileCheckBox.Name = "AutoOpenPointsFileCheckBox";
      this.AutoOpenPointsFileCheckBox.Size = new System.Drawing.Size(122, 17);
      this.AutoOpenPointsFileCheckBox.TabIndex = 2;
      this.AutoOpenPointsFileCheckBox.Text = "Auto open points file";
      this.AutoOpenPointsFileCheckBox.UseVisualStyleBackColor = true;
      // 
      // GenerateImageFileCheckBox
      // 
      this.GenerateImageFileCheckBox.AutoSize = true;
      this.GenerateImageFileCheckBox.Checked = true;
      this.GenerateImageFileCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
      this.GenerateImageFileCheckBox.Location = new System.Drawing.Point(16, 14);
      this.GenerateImageFileCheckBox.Name = "GenerateImageFileCheckBox";
      this.GenerateImageFileCheckBox.Size = new System.Drawing.Size(117, 17);
      this.GenerateImageFileCheckBox.TabIndex = 2;
      this.GenerateImageFileCheckBox.Text = "Generate image file";
      this.GenerateImageFileCheckBox.UseVisualStyleBackColor = true;
      this.GenerateImageFileCheckBox.CheckedChanged += new System.EventHandler(this.GenerateImageFileCheckBox_CheckedChanged);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(176, 568);
      this.Controls.Add(this.FilePanel);
      this.Controls.Add(this.linkLabel1);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.ImagePanel);
      this.Controls.Add(this.ConfigPanel);
      this.Controls.Add(this.panel1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MaximizeBox = false;
      this.Name = "Form1";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "FernGen";
      this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
      this.ConfigPanel.ResumeLayout(false);
      this.ConfigPanel.PerformLayout();
      this.ImagePanel.ResumeLayout(false);
      this.ImagePanel.PerformLayout();
      this.panel1.ResumeLayout(false);
      this.FilePanel.ResumeLayout(false);
      this.FilePanel.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox StepsInput;
        private System.Windows.Forms.Button GoButton;
        private System.Windows.Forms.Panel ConfigPanel;
        private System.Windows.Forms.Button StopButton;
        private System.Windows.Forms.Button PauseButton;
        private System.Windows.Forms.Panel ImagePanel;
        private System.Windows.Forms.Button OpenImageButton;
        private System.Windows.Forms.CheckBox ImageAutoOpenCheckbox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox DimensionInput;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button advancedButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button CheckProgressButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button ColourButton;
        private System.Windows.Forms.LinkLabel linkLabel1;
    private System.Windows.Forms.Panel FilePanel;
    private System.Windows.Forms.CheckBox AutoOpenPointsFileCheckBox;
    private System.Windows.Forms.Button OpenPointsFileButton;
    private System.Windows.Forms.CheckBox GeneratePointsListCheckBox;
    private System.Windows.Forms.CheckBox GenerateImageFileCheckBox;
  }
}

