namespace PolyMangement.View
{
    partial class RedopantView
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtStartYear = new System.Windows.Forms.TextBox();
            this.txtStartMD = new System.Windows.Forms.TextBox();
            this.txtStartHM = new System.Windows.Forms.TextBox();
            this.txtEndHM = new System.Windows.Forms.TextBox();
            this.txtEndMD = new System.Windows.Forms.TextBox();
            this.txtEndYear = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lb3 = new System.Windows.Forms.Label();
            this.comboboxNeckTimes = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbReal = new System.Windows.Forms.Label();
            this.lbRedopantTime = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbRedopantWeight = new System.Windows.Forms.Label();
            this.btnRecipe1 = new System.Windows.Forms.Button();
            this.btnRecipe2 = new System.Windows.Forms.Button();
            this.btnRecipe3 = new System.Windows.Forms.Button();
            this.btnRecipe4 = new System.Windows.Forms.Button();
            this.btnRecipe5 = new System.Windows.Forms.Button();
            this.lbRecipeName = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(133, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Dopant時間";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(503, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 37);
            this.label2.TabIndex = 1;
            this.label2.Text = "熔完時間";
            // 
            // txtStartYear
            // 
            this.txtStartYear.Location = new System.Drawing.Point(49, 91);
            this.txtStartYear.Name = "txtStartYear";
            this.txtStartYear.Size = new System.Drawing.Size(62, 22);
            this.txtStartYear.TabIndex = 2;
            this.txtStartYear.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnlyNumberAndBacksapce);
            // 
            // txtStartMD
            // 
            this.txtStartMD.Location = new System.Drawing.Point(138, 91);
            this.txtStartMD.Name = "txtStartMD";
            this.txtStartMD.Size = new System.Drawing.Size(100, 22);
            this.txtStartMD.TabIndex = 3;
            this.txtStartMD.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnlySlashAndNumberAndBacksapce);
            // 
            // txtStartHM
            // 
            this.txtStartHM.Location = new System.Drawing.Point(264, 91);
            this.txtStartHM.Name = "txtStartHM";
            this.txtStartHM.Size = new System.Drawing.Size(100, 22);
            this.txtStartHM.TabIndex = 4;
            this.txtStartHM.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnlyNumberAndBacksapce);
            // 
            // txtEndHM
            // 
            this.txtEndHM.Location = new System.Drawing.Point(634, 91);
            this.txtEndHM.Name = "txtEndHM";
            this.txtEndHM.Size = new System.Drawing.Size(100, 22);
            this.txtEndHM.TabIndex = 7;
            this.txtEndHM.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnlyNumberAndBacksapce);
            // 
            // txtEndMD
            // 
            this.txtEndMD.Location = new System.Drawing.Point(510, 91);
            this.txtEndMD.Name = "txtEndMD";
            this.txtEndMD.Size = new System.Drawing.Size(100, 22);
            this.txtEndMD.TabIndex = 6;
            this.txtEndMD.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnlySlashAndNumberAndBacksapce);
            // 
            // txtEndYear
            // 
            this.txtEndYear.Location = new System.Drawing.Point(427, 91);
            this.txtEndYear.Name = "txtEndYear";
            this.txtEndYear.Size = new System.Drawing.Size(62, 22);
            this.txtEndYear.TabIndex = 5;
            this.txtEndYear.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnlyNumberAndBacksapce);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(49, 194);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(315, 700);
            this.dataGridView1.TabIndex = 8;
            // 
            // lb3
            // 
            this.lb3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lb3.AutoSize = true;
            this.lb3.Font = new System.Drawing.Font("微軟正黑體", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lb3.Location = new System.Drawing.Point(783, 28);
            this.lb3.Name = "lb3";
            this.lb3.Size = new System.Drawing.Size(147, 37);
            this.lb3.TabIndex = 9;
            this.lb3.Text = "Neck次數";
            // 
            // comboboxNeckTimes
            // 
            this.comboboxNeckTimes.FormattingEnabled = true;
            this.comboboxNeckTimes.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7"});
            this.comboboxNeckTimes.Location = new System.Drawing.Point(790, 91);
            this.comboboxNeckTimes.Name = "comboboxNeckTimes";
            this.comboboxNeckTimes.Size = new System.Drawing.Size(140, 20);
            this.comboboxNeckTimes.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微軟正黑體", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(473, 213);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 37);
            this.label3.TabIndex = 11;
            this.label3.Text = "實際時間";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微軟正黑體", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(758, 213);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(133, 37);
            this.label4.TabIndex = 12;
            this.label4.Text = "延引時間";
            // 
            // lbReal
            // 
            this.lbReal.AutoSize = true;
            this.lbReal.Font = new System.Drawing.Font("微軟正黑體", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbReal.Location = new System.Drawing.Point(503, 299);
            this.lbReal.Name = "lbReal";
            this.lbReal.Size = new System.Drawing.Size(75, 37);
            this.lbReal.TabIndex = 14;
            this.lbReal.Text = "實際";
            // 
            // lbRedopantTime
            // 
            this.lbRedopantTime.AutoSize = true;
            this.lbRedopantTime.Font = new System.Drawing.Font("微軟正黑體", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbRedopantTime.ForeColor = System.Drawing.Color.Blue;
            this.lbRedopantTime.Location = new System.Drawing.Point(783, 299);
            this.lbRedopantTime.Name = "lbRedopantTime";
            this.lbRedopantTime.Size = new System.Drawing.Size(75, 37);
            this.lbRedopantTime.TabIndex = 15;
            this.lbRedopantTime.Text = "延引";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微軟正黑體", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.Location = new System.Drawing.Point(587, 403);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(213, 37);
            this.label5.TabIndex = 13;
            this.label5.Text = "Redopant克數";
            // 
            // lbRedopantWeight
            // 
            this.lbRedopantWeight.AutoSize = true;
            this.lbRedopantWeight.Font = new System.Drawing.Font("微軟正黑體", 99.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbRedopantWeight.ForeColor = System.Drawing.Color.Blue;
            this.lbRedopantWeight.Location = new System.Drawing.Point(534, 484);
            this.lbRedopantWeight.Name = "lbRedopantWeight";
            this.lbRedopantWeight.Size = new System.Drawing.Size(336, 167);
            this.lbRedopantWeight.TabIndex = 16;
            this.lbRedopantWeight.Text = "克數";
            // 
            // btnRecipe1
            // 
            this.btnRecipe1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRecipe1.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnRecipe1.Location = new System.Drawing.Point(1074, 190);
            this.btnRecipe1.Name = "btnRecipe1";
            this.btnRecipe1.Size = new System.Drawing.Size(156, 49);
            this.btnRecipe1.TabIndex = 17;
            this.btnRecipe1.Text = "RecipeA";
            this.btnRecipe1.UseVisualStyleBackColor = true;
            // 
            // btnRecipe2
            // 
            this.btnRecipe2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRecipe2.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnRecipe2.Location = new System.Drawing.Point(1074, 295);
            this.btnRecipe2.Name = "btnRecipe2";
            this.btnRecipe2.Size = new System.Drawing.Size(156, 49);
            this.btnRecipe2.TabIndex = 18;
            this.btnRecipe2.Text = "RecipeB";
            this.btnRecipe2.UseVisualStyleBackColor = true;
            // 
            // btnRecipe3
            // 
            this.btnRecipe3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRecipe3.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnRecipe3.Location = new System.Drawing.Point(1074, 403);
            this.btnRecipe3.Name = "btnRecipe3";
            this.btnRecipe3.Size = new System.Drawing.Size(156, 49);
            this.btnRecipe3.TabIndex = 19;
            this.btnRecipe3.Text = "RecipeC";
            this.btnRecipe3.UseVisualStyleBackColor = true;
            // 
            // btnRecipe4
            // 
            this.btnRecipe4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRecipe4.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnRecipe4.Location = new System.Drawing.Point(1074, 515);
            this.btnRecipe4.Name = "btnRecipe4";
            this.btnRecipe4.Size = new System.Drawing.Size(156, 49);
            this.btnRecipe4.TabIndex = 20;
            this.btnRecipe4.Text = "RecipeD";
            this.btnRecipe4.UseVisualStyleBackColor = true;
            // 
            // btnRecipe5
            // 
            this.btnRecipe5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRecipe5.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnRecipe5.Location = new System.Drawing.Point(1074, 623);
            this.btnRecipe5.Name = "btnRecipe5";
            this.btnRecipe5.Size = new System.Drawing.Size(156, 49);
            this.btnRecipe5.TabIndex = 21;
            this.btnRecipe5.Text = "RecipeE";
            this.btnRecipe5.UseVisualStyleBackColor = true;
            // 
            // lbRecipeName
            // 
            this.lbRecipeName.AutoSize = true;
            this.lbRecipeName.Font = new System.Drawing.Font("微軟正黑體", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbRecipeName.Location = new System.Drawing.Point(116, 138);
            this.lbRecipeName.Name = "lbRecipeName";
            this.lbRecipeName.Size = new System.Drawing.Size(170, 37);
            this.lbRecipeName.TabIndex = 22;
            this.lbRecipeName.Text = "Recipe名稱";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微軟正黑體", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label6.ForeColor = System.Drawing.Color.Blue;
            this.label6.Location = new System.Drawing.Point(1063, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(186, 120);
            this.label6.TabIndex = 23;
            this.label6.Text = "PH";
            // 
            // RedopantView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 715);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lbRecipeName);
            this.Controls.Add(this.btnRecipe5);
            this.Controls.Add(this.btnRecipe4);
            this.Controls.Add(this.btnRecipe3);
            this.Controls.Add(this.btnRecipe2);
            this.Controls.Add(this.btnRecipe1);
            this.Controls.Add(this.lbRedopantWeight);
            this.Controls.Add(this.lbRedopantTime);
            this.Controls.Add(this.lbReal);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboboxNeckTimes);
            this.Controls.Add(this.lb3);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.txtEndHM);
            this.Controls.Add(this.txtEndMD);
            this.Controls.Add(this.txtEndYear);
            this.Controls.Add(this.txtStartHM);
            this.Controls.Add(this.txtStartMD);
            this.Controls.Add(this.txtStartYear);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "RedopantView";
            this.Text = "RedopantView";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtStartYear;
        private System.Windows.Forms.TextBox txtStartMD;
        private System.Windows.Forms.TextBox txtStartHM;
        private System.Windows.Forms.TextBox txtEndHM;
        private System.Windows.Forms.TextBox txtEndMD;
        private System.Windows.Forms.TextBox txtEndYear;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lb3;
        private System.Windows.Forms.ComboBox comboboxNeckTimes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbReal;
        private System.Windows.Forms.Label lbRedopantTime;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbRedopantWeight;
        private System.Windows.Forms.Button btnRecipe1;
        private System.Windows.Forms.Button btnRecipe2;
        private System.Windows.Forms.Button btnRecipe3;
        private System.Windows.Forms.Button btnRecipe4;
        private System.Windows.Forms.Button btnRecipe5;
        private System.Windows.Forms.Label lbRecipeName;
        private System.Windows.Forms.Label label6;
    }
}