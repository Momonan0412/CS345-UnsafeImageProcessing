namespace Image_Processing
{
    partial class ImageProcessingForm
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
            menuStrip1 = new MenuStrip();
            openToolStripMenuItem = new ToolStripMenuItem();
            openToolStripMenuItem1 = new ToolStripMenuItem();
            saveToolStripMenuItem = new ToolStripMenuItem();
            dIPToolStripMenuItem = new ToolStripMenuItem();
            pixelCopyToolStripMenuItem = new ToolStripMenuItem();
            grayscallingToolStripMenuItem = new ToolStripMenuItem();
            mirrorToolStripMenuItem = new ToolStripMenuItem();
            sepiaToolStripMenuItem = new ToolStripMenuItem();
            mirrorToolStripMenuItem1 = new ToolStripMenuItem();
            mirrorVerticalToolStripMenuItem = new ToolStripMenuItem();
            histogramToolStripMenuItem = new ToolStripMenuItem();
            openFileDialog1 = new OpenFileDialog();
            saveFileDialog1 = new SaveFileDialog();
            sourcePictureBox = new PictureBox();
            processedPictureBox = new PictureBox();
            brightnessTrackBar = new TrackBar();
            label1 = new Label();
            equalizationTrackBar = new TrackBar();
            label2 = new Label();
            rotationTrackBar = new TrackBar();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)sourcePictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)processedPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)brightnessTrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)equalizationTrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)rotationTrackBar).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { openToolStripMenuItem, dIPToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1124, 32);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { openToolStripMenuItem1, saveToolStripMenuItem });
            openToolStripMenuItem.Font = new Font("Agency FB", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.Size = new Size(43, 28);
            openToolStripMenuItem.Text = "File";
            openToolStripMenuItem.Click += openToolStripMenuItem_Click;
            // 
            // openToolStripMenuItem1
            // 
            openToolStripMenuItem1.Name = "openToolStripMenuItem1";
            openToolStripMenuItem1.Size = new Size(124, 28);
            openToolStripMenuItem1.Text = "Open";
            openToolStripMenuItem1.Click += openToolStripMenuItem1_Click;
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.Size = new Size(124, 28);
            saveToolStripMenuItem.Text = "Save";
            saveToolStripMenuItem.Click += saveToolStripMenuItem_Click;
            // 
            // dIPToolStripMenuItem
            // 
            dIPToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { pixelCopyToolStripMenuItem, grayscallingToolStripMenuItem, mirrorToolStripMenuItem, sepiaToolStripMenuItem, mirrorToolStripMenuItem1, mirrorVerticalToolStripMenuItem, histogramToolStripMenuItem });
            dIPToolStripMenuItem.Font = new Font("Agency FB", 12F, FontStyle.Bold | FontStyle.Italic);
            dIPToolStripMenuItem.Name = "dIPToolStripMenuItem";
            dIPToolStripMenuItem.Size = new Size(46, 28);
            dIPToolStripMenuItem.Text = "DIP";
            // 
            // pixelCopyToolStripMenuItem
            // 
            pixelCopyToolStripMenuItem.Name = "pixelCopyToolStripMenuItem";
            pixelCopyToolStripMenuItem.Size = new Size(224, 28);
            pixelCopyToolStripMenuItem.Text = "Pixel Copy";
            pixelCopyToolStripMenuItem.Click += pixelCopyToolStripMenuItem_Click;
            // 
            // grayscallingToolStripMenuItem
            // 
            grayscallingToolStripMenuItem.Name = "grayscallingToolStripMenuItem";
            grayscallingToolStripMenuItem.Size = new Size(224, 28);
            grayscallingToolStripMenuItem.Text = "Grayscaling";
            grayscallingToolStripMenuItem.Click += grayscallingToolStripMenuItem_Click;
            // 
            // mirrorToolStripMenuItem
            // 
            mirrorToolStripMenuItem.Name = "mirrorToolStripMenuItem";
            mirrorToolStripMenuItem.Size = new Size(224, 28);
            mirrorToolStripMenuItem.Text = "Inversion";
            mirrorToolStripMenuItem.Click += mirrorToolStripMenuItem_Click;
            // 
            // sepiaToolStripMenuItem
            // 
            sepiaToolStripMenuItem.Name = "sepiaToolStripMenuItem";
            sepiaToolStripMenuItem.Size = new Size(224, 28);
            sepiaToolStripMenuItem.Text = "Sepia";
            sepiaToolStripMenuItem.Click += sepiaToolStripMenuItem_Click;
            // 
            // mirrorToolStripMenuItem1
            // 
            mirrorToolStripMenuItem1.Name = "mirrorToolStripMenuItem1";
            mirrorToolStripMenuItem1.Size = new Size(224, 28);
            mirrorToolStripMenuItem1.Text = "Mirror Horizontal";
            mirrorToolStripMenuItem1.Click += mirrorToolStripMenuItem1_Click;
            // 
            // mirrorVerticalToolStripMenuItem
            // 
            mirrorVerticalToolStripMenuItem.Name = "mirrorVerticalToolStripMenuItem";
            mirrorVerticalToolStripMenuItem.Size = new Size(224, 28);
            mirrorVerticalToolStripMenuItem.Text = "Mirror Vertical";
            mirrorVerticalToolStripMenuItem.Click += mirrorVerticalToolStripMenuItem_Click;
            // 
            // histogramToolStripMenuItem
            // 
            histogramToolStripMenuItem.Name = "histogramToolStripMenuItem";
            histogramToolStripMenuItem.Size = new Size(224, 28);
            histogramToolStripMenuItem.Text = "Histogram";
            histogramToolStripMenuItem.Click += histogramToolStripMenuItem_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            openFileDialog1.FileOk += openFileDialog1_FileOk;
            // 
            // saveFileDialog1
            // 
            saveFileDialog1.FileOk += saveFileDialog1_FileOk;
            // 
            // sourcePictureBox
            // 
            sourcePictureBox.BackColor = SystemColors.ActiveCaption;
            sourcePictureBox.Location = new Point(12, 44);
            sourcePictureBox.Name = "sourcePictureBox";
            sourcePictureBox.Size = new Size(545, 451);
            sourcePictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            sourcePictureBox.TabIndex = 1;
            sourcePictureBox.TabStop = false;
            // 
            // processedPictureBox
            // 
            processedPictureBox.BackColor = SystemColors.ActiveCaption;
            processedPictureBox.Location = new Point(573, 44);
            processedPictureBox.Name = "processedPictureBox";
            processedPictureBox.Size = new Size(545, 451);
            processedPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            processedPictureBox.TabIndex = 2;
            processedPictureBox.TabStop = false;
            // 
            // brightnessTrackBar
            // 
            brightnessTrackBar.BackColor = SystemColors.ActiveCaption;
            brightnessTrackBar.Cursor = Cursors.Hand;
            brightnessTrackBar.Location = new Point(988, 527);
            brightnessTrackBar.Maximum = 50;
            brightnessTrackBar.Minimum = -50;
            brightnessTrackBar.Name = "brightnessTrackBar";
            brightnessTrackBar.Size = new Size(130, 56);
            brightnessTrackBar.TabIndex = 3;
            brightnessTrackBar.Scroll += trackBar1_Scroll;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Agency FB", 12F, FontStyle.Bold | FontStyle.Italic);
            label1.Location = new Point(1015, 499);
            label1.Name = "label1";
            label1.Size = new Size(74, 24);
            label1.TabIndex = 4;
            label1.Text = "Brightness";
            label1.Click += label1_Click;
            // 
            // equalizationTrackBar
            // 
            equalizationTrackBar.BackColor = SystemColors.ActiveCaption;
            equalizationTrackBar.Cursor = Cursors.Hand;
            equalizationTrackBar.Location = new Point(852, 527);
            equalizationTrackBar.Maximum = 100;
            equalizationTrackBar.Minimum = -100;
            equalizationTrackBar.Name = "equalizationTrackBar";
            equalizationTrackBar.Size = new Size(130, 56);
            equalizationTrackBar.TabIndex = 5;
            equalizationTrackBar.Scroll += trackBar2_Scroll_1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Agency FB", 12F, FontStyle.Bold | FontStyle.Italic);
            label2.Location = new Point(877, 499);
            label2.Name = "label2";
            label2.Size = new Size(79, 24);
            label2.TabIndex = 6;
            label2.Text = "Equalization";
            // 
            // rotationTrackBar
            // 
            rotationTrackBar.BackColor = SystemColors.ActiveCaption;
            rotationTrackBar.Cursor = Cursors.Hand;
            rotationTrackBar.Location = new Point(573, 527);
            rotationTrackBar.Maximum = 360;
            rotationTrackBar.Minimum = -360;
            rotationTrackBar.Name = "rotationTrackBar";
            rotationTrackBar.Size = new Size(273, 56);
            rotationTrackBar.TabIndex = 7;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1124, 589);
            Controls.Add(rotationTrackBar);
            Controls.Add(label2);
            Controls.Add(equalizationTrackBar);
            Controls.Add(label1);
            Controls.Add(brightnessTrackBar);
            Controls.Add(processedPictureBox);
            Controls.Add(sourcePictureBox);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "CS345 Image Processing";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)sourcePictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)processedPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)brightnessTrackBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)equalizationTrackBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)rotationTrackBar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem1;
        private ToolStripMenuItem dIPToolStripMenuItem;
        private ToolStripMenuItem pixelCopyToolStripMenuItem;
        private ToolStripMenuItem grayscallingToolStripMenuItem;
        private ToolStripMenuItem mirrorToolStripMenuItem;
        private OpenFileDialog openFileDialog1;
        private SaveFileDialog saveFileDialog1;
        private PictureBox sourcePictureBox;
        private PictureBox processedPictureBox;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem sepiaToolStripMenuItem;
        private ToolStripMenuItem mirrorToolStripMenuItem1;
        private ToolStripMenuItem histogramToolStripMenuItem;
        private TrackBar brightnessTrackBar;
        private Label label1;
        private TrackBar equalizationTrackBar;
        private Label label2;
        private ToolStripMenuItem mirrorVerticalToolStripMenuItem;
        private TrackBar rotationTrackBar;
    }
}
