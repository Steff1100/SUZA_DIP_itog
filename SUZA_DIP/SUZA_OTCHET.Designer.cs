namespace SUZA_DIP
{
    partial class SUZA_OTCHET
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SUZA_OTCHET));
            pictureBox1 = new PictureBox();
            button4 = new Button();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button5 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(-68, -8);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(564, 361);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // button4
            // 
            button4.Location = new Point(236, 157);
            button4.Name = "button4";
            button4.Size = new Size(173, 40);
            button4.TabIndex = 18;
            button4.Text = "Отчет по МОЛ";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button1
            // 
            button1.Location = new Point(12, 157);
            button1.Name = "button1";
            button1.Size = new Size(173, 40);
            button1.TabIndex = 19;
            button1.Text = "Отчет по обслуживанию";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(12, 111);
            button2.Name = "button2";
            button2.Size = new Size(173, 40);
            button2.TabIndex = 20;
            button2.Text = "Отчет  по запчастям";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(236, 111);
            button3.Name = "button3";
            button3.Size = new Size(173, 40);
            button3.TabIndex = 21;
            button3.Text = "Отчет по авто";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button5
            // 
            button5.Location = new Point(12, 230);
            button5.Name = "button5";
            button5.Size = new Size(173, 40);
            button5.TabIndex = 22;
            button5.Text = "Назад";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // SUZA_OTCHET
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(427, 281);
            Controls.Add(button5);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(button4);
            Controls.Add(pictureBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "SUZA_OTCHET";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Меню отчетов";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private Button button4;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button5;
    }
}