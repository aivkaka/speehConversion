namespace WinFormsApp2
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
            Label label1;
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            chooseFile = new Button();
            comboBox1 = new ComboBox();
            textBox1 = new TextBox();
            openFileDialog1 = new OpenFileDialog();
            recognize = new Button();
            textBox2 = new TextBox();
            richTextBox1 = new RichTextBox();
            createSpeech = new Button();
            comboBox2 = new ComboBox();
            label5 = new Label();
            comboBox3 = new ComboBox();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            trackBar1 = new TrackBar();
            trackBar2 = new TrackBar();
            trackBar3 = new TrackBar();
            label10 = new Label();
            comboBox4 = new ComboBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar3).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(39, 40);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(110, 31);
            label1.TabIndex = 0;
            label1.Text = "语音识别";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(39, 157);
            label2.Margin = new Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new Size(110, 31);
            label2.TabIndex = 1;
            label2.Text = "音频格式";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(39, 295);
            label3.Margin = new Padding(5, 0, 5, 0);
            label3.Name = "label3";
            label3.Size = new Size(110, 31);
            label3.TabIndex = 2;
            label3.Text = "识别结果";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(613, 40);
            label4.Margin = new Padding(5, 0, 5, 0);
            label4.Name = "label4";
            label4.Size = new Size(110, 31);
            label4.TabIndex = 3;
            label4.Text = "语音合成";
            // 
            // chooseFile
            // 
            chooseFile.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            chooseFile.Location = new Point(428, 82);
            chooseFile.Margin = new Padding(5);
            chooseFile.Name = "chooseFile";
            chooseFile.Size = new Size(146, 45);
            chooseFile.TabIndex = 4;
            chooseFile.Text = "选择文件";
            chooseFile.UseVisualStyleBackColor = true;
            chooseFile.Click += button1_Click;
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "amr", "pcm", "wav", "m4a" });
            comboBox1.Location = new Point(217, 157);
            comboBox1.Margin = new Padding(5);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(174, 39);
            comboBox1.TabIndex = 5;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(39, 85);
            textBox1.Margin = new Padding(5);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(377, 38);
            textBox1.TabIndex = 6;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // recognize
            // 
            recognize.Location = new Point(428, 215);
            recognize.Margin = new Padding(5);
            recognize.Name = "recognize";
            recognize.Size = new Size(146, 45);
            recognize.TabIndex = 7;
            recognize.Text = "开始识别";
            recognize.UseVisualStyleBackColor = true;
            recognize.Click += button2_Click;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(39, 331);
            textBox2.Margin = new Padding(5);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(533, 437);
            textBox2.TabIndex = 8;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(613, 82);
            richTextBox1.Margin = new Padding(5);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(662, 322);
            richTextBox1.TabIndex = 9;
            richTextBox1.Text = "";
            // 
            // createSpeech
            // 
            createSpeech.Location = new Point(1105, 716);
            createSpeech.Margin = new Padding(5);
            createSpeech.Name = "createSpeech";
            createSpeech.Size = new Size(157, 52);
            createSpeech.TabIndex = 10;
            createSpeech.Text = "开始合成";
            createSpeech.UseVisualStyleBackColor = true;
            createSpeech.Click += createSpeech_Click;
            // 
            // comboBox2
            // 
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "普通话", "英语", "粤语", "四川话" });
            comboBox2.Location = new Point(217, 221);
            comboBox2.Margin = new Padding(5);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(174, 39);
            comboBox2.TabIndex = 11;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(59, 224);
            label5.Name = "label5";
            label5.Size = new Size(62, 31);
            label5.TabIndex = 12;
            label5.Text = "语种";
            // 
            // comboBox3
            // 
            comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox3.FormattingEnabled = true;
            comboBox3.Items.AddRange(new object[] { "度小宇", "度小美", "度逍遥", "度丫丫" });
            comboBox3.Location = new Point(727, 446);
            comboBox3.Margin = new Padding(5);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(174, 39);
            comboBox3.TabIndex = 13;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(613, 446);
            label6.Margin = new Padding(5, 0, 5, 0);
            label6.Name = "label6";
            label6.Size = new Size(86, 31);
            label6.TabIndex = 14;
            label6.Text = "发音人";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(613, 512);
            label7.Margin = new Padding(5, 0, 5, 0);
            label7.Name = "label7";
            label7.Size = new Size(62, 31);
            label7.TabIndex = 15;
            label7.Text = "语速";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(613, 571);
            label8.Margin = new Padding(5, 0, 5, 0);
            label8.Name = "label8";
            label8.Size = new Size(62, 31);
            label8.TabIndex = 16;
            label8.Text = "音调";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(613, 630);
            label9.Margin = new Padding(5, 0, 5, 0);
            label9.Name = "label9";
            label9.Size = new Size(62, 31);
            label9.TabIndex = 17;
            label9.Text = "音量";
            // 
            // trackBar1
            // 
            trackBar1.LargeChange = 10;
            trackBar1.Location = new Point(727, 512);
            trackBar1.Maximum = 15;
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size(529, 90);
            trackBar1.TabIndex = 18;
            trackBar1.Value = 5;
            // 
            // trackBar2
            // 
            trackBar2.Location = new Point(727, 571);
            trackBar2.Maximum = 15;
            trackBar2.Name = "trackBar2";
            trackBar2.Size = new Size(529, 90);
            trackBar2.TabIndex = 19;
            trackBar2.Value = 5;
            // 
            // trackBar3
            // 
            trackBar3.Location = new Point(727, 630);
            trackBar3.Maximum = 15;
            trackBar3.Name = "trackBar3";
            trackBar3.Size = new Size(529, 90);
            trackBar3.TabIndex = 20;
            trackBar3.Value = 5;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(947, 449);
            label10.Margin = new Padding(5, 0, 5, 0);
            label10.Name = "label10";
            label10.Size = new Size(110, 31);
            label10.TabIndex = 21;
            label10.Text = "输出格式";
            // 
            // comboBox4
            // 
            comboBox4.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox4.ForeColor = Color.Black;
            comboBox4.FormattingEnabled = true;
            comboBox4.Items.AddRange(new object[] { "mp3", "pcm-16k", "pcm-8k", "wav" });
            comboBox4.Location = new Point(1058, 446);
            comboBox4.Margin = new Padding(5);
            comboBox4.Name = "comboBox4";
            comboBox4.Size = new Size(174, 39);
            comboBox4.TabIndex = 22;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(14F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(1311, 799);
            Controls.Add(comboBox4);
            Controls.Add(label10);
            Controls.Add(trackBar3);
            Controls.Add(trackBar2);
            Controls.Add(trackBar1);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(comboBox3);
            Controls.Add(label5);
            Controls.Add(comboBox2);
            Controls.Add(createSpeech);
            Controls.Add(richTextBox1);
            Controls.Add(textBox2);
            Controls.Add(recognize);
            Controls.Add(textBox1);
            Controls.Add(comboBox1);
            Controls.Add(chooseFile);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new Padding(5);
            Name = "Form1";
            Text = "语音演示程序";
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar2).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button chooseFile;
        private ComboBox comboBox1;
        private TextBox textBox1;
        private OpenFileDialog openFileDialog1;
        private Button recognize;
        private TextBox textBox2;
        private RichTextBox richTextBox1;
        private Button createSpeech;
        private ComboBox comboBox2;
        private Label label5;
        private ComboBox comboBox3;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private TrackBar trackBar1;
        private TrackBar trackBar2;
        private TrackBar trackBar3;
        private Label label10;
        private ComboBox comboBox4;
    }
}
