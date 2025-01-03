namespace SUZA_DIP
{
    partial class SUZA_OTCH_ZAP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SUZA_OTCH_ZAP));
            pictureBox1 = new PictureBox();
            button5 = new Button();
            button1 = new Button();
            label3 = new Label();
            dataGridView1 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(-130, -59);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(925, 763);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // button5
            // 
            button5.Location = new Point(68, 493);
            button5.Name = "button5";
            button5.Size = new Size(173, 40);
            button5.TabIndex = 23;
            button5.Text = "Назад";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button1
            // 
            button1.Location = new Point(439, 493);
            button1.Name = "button1";
            button1.Size = new Size(173, 40);
            button1.TabIndex = 24;
            button1.Text = "Печать";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 13F);
            label3.Location = new Point(68, 445);
            label3.Name = "label3";
            label3.RightToLeft = RightToLeft.Yes;
            label3.Size = new Size(232, 25);
            label3.TabIndex = 28;
            label3.Text = "Сумма списаний запчастей";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.GridColor = SystemColors.ScrollBar;
            dataGridView1.Location = new Point(68, 259);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(544, 183);
            dataGridView1.TabIndex = 29;
            // 
            // SUZA_OTCH_ZAP
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(678, 564);
            Controls.Add(dataGridView1);
            Controls.Add(label3);
            Controls.Add(button1);
            Controls.Add(button5);
            Controls.Add(pictureBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "SUZA_OTCH_ZAP";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Отчет по запчастям";
            Load += SUZA_OTCH_ZAP_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Button button5;
        private Button button1;
        private Label label3;
        private DataGridView dataGridView1;
    }
}