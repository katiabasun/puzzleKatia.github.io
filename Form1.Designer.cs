namespace WinFormsApp1
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
            panel1 = new Panel();
            button = new Button();
            previewBox = new PictureBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)previewBox).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Location = new Point(341, 60);
            panel1.Name = "panel1";
            panel1.Size = new Size(1000, 600);
            panel1.TabIndex = 0;
            // 
            // button
            // 
            button.BackColor = Color.BurlyWood;
            button.BackgroundImageLayout = ImageLayout.None;
            button.Cursor = Cursors.Hand;
            button.FlatStyle = FlatStyle.Popup;
            button.Font = new Font("Lucida Calligraphy", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button.ForeColor = SystemColors.ActiveCaptionText;
            button.Location = new Point(69, 243);
            button.Name = "button";
            button.Size = new Size(242, 31);
            button.TabIndex = 1;
            button.Text = "START";
            button.UseVisualStyleBackColor = false;
            button.Click += button_Click;
            // 
            // previewBox
            // 
            previewBox.BackColor = SystemColors.ControlLightLight;
            previewBox.BorderStyle = BorderStyle.FixedSingle;
            previewBox.Location = new Point(69, 60);
            previewBox.Name = "previewBox";
            previewBox.Size = new Size(242, 158);
            previewBox.SizeMode = PictureBoxSizeMode.Zoom;
            previewBox.TabIndex = 2;
            previewBox.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(69, 42);
            label1.Name = "label1";
            label1.Size = new Size(86, 15);
            label1.TabIndex = 3;
            label1.Text = "Preview Photo:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1384, 760);
            Controls.Add(label1);
            Controls.Add(previewBox);
            Controls.Add(button);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)previewBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Button button;
        private PictureBox previewBox;
        private Label label1;
    }
}
