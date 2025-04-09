namespace Edge_detection
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            checkBox2 = new System.Windows.Forms.CheckBox();
            checkBox3 = new System.Windows.Forms.CheckBox();
            checkBox4 = new System.Windows.Forms.CheckBox();
            checkBox5 = new System.Windows.Forms.CheckBox();
            label8 = new System.Windows.Forms.Label();
            button2 = new System.Windows.Forms.Button();
            button3 = new System.Windows.Forms.Button();
            button4 = new System.Windows.Forms.Button();
            button5 = new System.Windows.Forms.Button();
            button6 = new System.Windows.Forms.Button();
            pictureBox1 = new System.Windows.Forms.PictureBox();
            pictureBox2 = new System.Windows.Forms.PictureBox();
            pictureBox3 = new System.Windows.Forms.PictureBox();
            pictureBox7 = new System.Windows.Forms.PictureBox();
            pictureBox4 = new System.Windows.Forms.PictureBox();
            pictureBox5 = new System.Windows.Forms.PictureBox();
            pictureBox6 = new System.Windows.Forms.PictureBox();
            deltaBox = new System.Windows.Forms.ComboBox();
            textBox1 = new System.Windows.Forms.TextBox();
            blurBox = new System.Windows.Forms.ComboBox();
            colorBox = new System.Windows.Forms.ComboBox();
            button1 = new System.Windows.Forms.Button();
            yBox = new System.Windows.Forms.ComboBox();
            xBox = new System.Windows.Forms.ComboBox();
            checkBox1 = new System.Windows.Forms.CheckBox();
            button7 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(-1, 10);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(124, 15);
            label1.TabIndex = 0;
            label1.Text = "Original (click to load)";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(307, 10);
            label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(114, 15);
            label2.TabIndex = 1;
            label2.Text = "Original (color filter)";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(619, 10);
            label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(65, 15);
            label3.TabIndex = 2;
            label3.Text = "Filter (blur)";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(930, 10);
            label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(39, 15);
            label4.TabIndex = 3;
            label4.Text = "Result";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(14, 317);
            label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(46, 15);
            label5.TabIndex = 4;
            label5.Text = "Delta-X";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(307, 317);
            label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(46, 15);
            label6.TabIndex = 5;
            label6.Text = "Delta-Y";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(619, 317);
            label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(39, 15);
            label7.TabIndex = 6;
            label7.Text = "Deltas";
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Checked = true;
            checkBox2.CheckState = System.Windows.Forms.CheckState.Checked;
            checkBox2.Location = new System.Drawing.Point(622, 287);
            checkBox2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new System.Drawing.Size(86, 19);
            checkBox2.TabIndex = 7;
            checkBox2.Text = "Apply Filter";
            checkBox2.UseVisualStyleBackColor = true;
            checkBox2.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // checkBox3
            // 
            checkBox3.AutoSize = true;
            checkBox3.Location = new System.Drawing.Point(3, 598);
            checkBox3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new System.Drawing.Size(99, 19);
            checkBox3.TabIndex = 8;
            checkBox3.Text = "Apply Erosion";
            checkBox3.UseVisualStyleBackColor = true;
            checkBox3.CheckedChanged += checkBox2_CheckedChanged;
            // 
            // checkBox4
            // 
            checkBox4.AutoSize = true;
            checkBox4.Location = new System.Drawing.Point(311, 598);
            checkBox4.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            checkBox4.Name = "checkBox4";
            checkBox4.Size = new System.Drawing.Size(99, 19);
            checkBox4.TabIndex = 9;
            checkBox4.Text = "Apply Erosion";
            checkBox4.UseVisualStyleBackColor = true;
            checkBox4.CheckedChanged += checkBox3_CheckedChanged;
            // 
            // checkBox5
            // 
            checkBox5.AutoSize = true;
            checkBox5.Checked = true;
            checkBox5.CheckState = System.Windows.Forms.CheckState.Checked;
            checkBox5.Location = new System.Drawing.Point(622, 598);
            checkBox5.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            checkBox5.Name = "checkBox5";
            checkBox5.Size = new System.Drawing.Size(99, 19);
            checkBox5.TabIndex = 10;
            checkBox5.Text = "Apply Erosion";
            checkBox5.UseVisualStyleBackColor = true;
            checkBox5.CheckedChanged += checkBox4_CheckedChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new System.Drawing.Point(6, 287);
            label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(163, 15);
            label8.TabIndex = 11;
            label8.Text = "Redimension Largest Side To :";
            // 
            // button2
            // 
            button2.Location = new System.Drawing.Point(805, 290);
            button2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            button2.Name = "button2";
            button2.Size = new System.Drawing.Size(122, 27);
            button2.TabIndex = 12;
            button2.Text = "Copy to clipboard";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new System.Drawing.Point(186, 593);
            button3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            button3.Name = "button3";
            button3.Size = new System.Drawing.Size(122, 27);
            button3.TabIndex = 13;
            button3.Text = "Copy to clipboard";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new System.Drawing.Point(494, 593);
            button4.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            button4.Name = "button4";
            button4.Size = new System.Drawing.Size(122, 27);
            button4.TabIndex = 14;
            button4.Text = "Copy to clipboard";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Location = new System.Drawing.Point(805, 593);
            button5.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            button5.Name = "button5";
            button5.Size = new System.Drawing.Size(122, 27);
            button5.TabIndex = 15;
            button5.Text = "Copy to clipboard";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.Location = new System.Drawing.Point(1404, 593);
            button6.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            button6.Name = "button6";
            button6.Size = new System.Drawing.Size(122, 27);
            button6.TabIndex = 16;
            button6.Text = "Copy to clipboard";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = System.Drawing.SystemColors.Window;
            pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pictureBox1.Location = new System.Drawing.Point(3, 28);
            pictureBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(304, 255);
            pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 17;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = System.Drawing.SystemColors.Window;
            pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pictureBox2.Location = new System.Drawing.Point(311, 28);
            pictureBox2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new System.Drawing.Size(304, 255);
            pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 18;
            pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = System.Drawing.SystemColors.Window;
            pictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pictureBox3.Location = new System.Drawing.Point(622, 28);
            pictureBox3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new System.Drawing.Size(304, 255);
            pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 19;
            pictureBox3.TabStop = false;
            // 
            // pictureBox7
            // 
            pictureBox7.BackColor = System.Drawing.Color.AliceBlue;
            pictureBox7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pictureBox7.Location = new System.Drawing.Point(934, 28);
            pictureBox7.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pictureBox7.Name = "pictureBox7";
            pictureBox7.Size = new System.Drawing.Size(591, 562);
            pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            pictureBox7.TabIndex = 20;
            pictureBox7.TabStop = false;
            // 
            // pictureBox4
            // 
            pictureBox4.BackColor = System.Drawing.Color.Honeydew;
            pictureBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pictureBox4.Location = new System.Drawing.Point(3, 335);
            pictureBox4.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new System.Drawing.Size(304, 255);
            pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            pictureBox4.TabIndex = 21;
            pictureBox4.TabStop = false;
            // 
            // pictureBox5
            // 
            pictureBox5.BackColor = System.Drawing.Color.Honeydew;
            pictureBox5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pictureBox5.Location = new System.Drawing.Point(311, 335);
            pictureBox5.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new System.Drawing.Size(304, 255);
            pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            pictureBox5.TabIndex = 22;
            pictureBox5.TabStop = false;
            // 
            // pictureBox6
            // 
            pictureBox6.BackColor = System.Drawing.Color.LavenderBlush;
            pictureBox6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pictureBox6.Location = new System.Drawing.Point(622, 335);
            pictureBox6.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new System.Drawing.Size(304, 255);
            pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            pictureBox6.TabIndex = 23;
            pictureBox6.TabStop = false;
            // 
            // deltaBox
            // 
            deltaBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            deltaBox.FormattingEnabled = true;
            deltaBox.Items.AddRange(new object[] { "+", "-", "avg (best)" });
            deltaBox.Location = new System.Drawing.Point(721, 595);
            deltaBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            deltaBox.Name = "deltaBox";
            deltaBox.Size = new System.Drawing.Size(82, 23);
            deltaBox.TabIndex = 24;
            deltaBox.SelectedIndexChanged += deltaBox_SelectedIndexChanged;
            // 
            // textBox1
            // 
            textBox1.BackColor = System.Drawing.Color.LightSalmon;
            textBox1.Location = new System.Drawing.Point(190, 285);
            textBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            textBox1.Name = "textBox1";
            textBox1.Size = new System.Drawing.Size(80, 23);
            textBox1.TabIndex = 25;
            textBox1.Text = "2048";
            textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // blurBox
            // 
            blurBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            blurBox.FormattingEnabled = true;
            blurBox.Items.AddRange(new object[] { "Gaussian", "Mean", "Median" });
            blurBox.Location = new System.Drawing.Point(718, 292);
            blurBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            blurBox.Name = "blurBox";
            blurBox.Size = new System.Drawing.Size(78, 23);
            blurBox.TabIndex = 26;
            blurBox.SelectedIndexChanged += blurBox_SelectedIndexChanged;
            // 
            // colorBox
            // 
            colorBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            colorBox.FormattingEnabled = true;
            colorBox.Items.AddRange(new object[] { "Red", "Green", "Blue" });
            colorBox.Location = new System.Drawing.Point(407, 292);
            colorBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            colorBox.Name = "colorBox";
            colorBox.Size = new System.Drawing.Size(78, 23);
            colorBox.TabIndex = 27;
            colorBox.SelectedIndexChanged += colorBox_SelectedIndexChanged;
            // 
            // button1
            // 
            button1.Location = new System.Drawing.Point(494, 290);
            button1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(122, 27);
            button1.TabIndex = 28;
            button1.Text = "Copy to clipboard";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // yBox
            // 
            yBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            yBox.FormattingEnabled = true;
            yBox.Items.AddRange(new object[] { "+", "- (v1)", "- (v2)", "avg (best)" });
            yBox.Location = new System.Drawing.Point(410, 595);
            yBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            yBox.Name = "yBox";
            yBox.Size = new System.Drawing.Size(82, 23);
            yBox.TabIndex = 29;
            yBox.SelectedIndexChanged += yBox_SelectedIndexChanged;
            // 
            // xBox
            // 
            xBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            xBox.FormattingEnabled = true;
            xBox.Items.AddRange(new object[] { "+", "- (v1)", "- (v2)", "avg (best)" });
            xBox.Location = new System.Drawing.Point(101, 595);
            xBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            xBox.Name = "xBox";
            xBox.Size = new System.Drawing.Size(82, 23);
            xBox.TabIndex = 30;
            xBox.SelectedIndexChanged += xBox_SelectedIndexChanged;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Checked = true;
            checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            checkBox1.Location = new System.Drawing.Point(311, 287);
            checkBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new System.Drawing.Size(86, 19);
            checkBox1.TabIndex = 31;
            checkBox1.Text = "Apply Filter";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox5_CheckedChanged;
            // 
            // button7
            // 
            button7.Location = new System.Drawing.Point(190, 308);
            button7.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            button7.Name = "button7";
            button7.Size = new System.Drawing.Size(80, 25);
            button7.TabIndex = 32;
            button7.Text = "Generate";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1529, 650);
            Controls.Add(button7);
            Controls.Add(checkBox1);
            Controls.Add(xBox);
            Controls.Add(yBox);
            Controls.Add(button1);
            Controls.Add(colorBox);
            Controls.Add(blurBox);
            Controls.Add(textBox1);
            Controls.Add(deltaBox);
            Controls.Add(pictureBox6);
            Controls.Add(pictureBox5);
            Controls.Add(pictureBox4);
            Controls.Add(pictureBox7);
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(label8);
            Controls.Add(checkBox5);
            Controls.Add(checkBox4);
            Controls.Add(checkBox3);
            Controls.Add(checkBox2);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "Form1";
            Text = "Edge detection";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.ComboBox deltaBox;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox blurBox;
        private System.Windows.Forms.ComboBox colorBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox yBox;
        private System.Windows.Forms.ComboBox xBox;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button button7;
    }
}

