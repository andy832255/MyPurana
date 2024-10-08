namespace MyKivotos
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
            this.dataGridView1 = new DataGridView();
            this.cbLevels = new ComboBox();
            this.label1 = new Label();
            this.label2 = new Label();
            this.cbSkillTypes = new ComboBox();
            this.btnSearch = new Button();
            this.label3 = new Label();
            this.cbEffectStats = new ComboBox();
            this.label4 = new Label();
            this.cbEffectStatTypes = new ComboBox();
            this.label5 = new Label();
            this.cbEffectTypes = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)this.dataGridView1).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new Point(22, 22);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new Size(1810, 646);
            this.dataGridView1.TabIndex = 0;
            // 
            // cbLevels
            // 
            this.cbLevels.FormattingEnabled = true;
            this.cbLevels.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" });
            this.cbLevels.Location = new Point(181, 693);
            this.cbLevels.Name = "cbLevels";
            this.cbLevels.Size = new Size(166, 25);
            this.cbLevels.TabIndex = 1;
            this.cbLevels.Text = "5";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new Font("微軟正黑體", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 136);
            this.label1.Location = new Point(22, 694);
            this.label1.Name = "label1";
            this.label1.Size = new Size(86, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "技能等級";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new Font("微軟正黑體", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 136);
            this.label2.Location = new Point(22, 753);
            this.label2.Name = "label2";
            this.label2.Size = new Size(86, 24);
            this.label2.TabIndex = 4;
            this.label2.Text = "技能類型";
            // 
            // cbSkillTypes
            // 
            this.cbSkillTypes.FormattingEnabled = true;
            this.cbSkillTypes.Items.AddRange(new object[] { "1", "2", "3", "4", "5" });
            this.cbSkillTypes.Location = new Point(181, 752);
            this.cbSkillTypes.Name = "cbSkillTypes";
            this.cbSkillTypes.Size = new Size(166, 25);
            this.cbSkillTypes.TabIndex = 3;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = Color.RosyBrown;
            this.btnSearch.Font = new Font("微軟正黑體", 14F, FontStyle.Bold);
            this.btnSearch.Location = new Point(417, 792);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new Size(108, 47);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "查詢";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += this.btnSearch_Click;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new Font("微軟正黑體", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 136);
            this.label3.Location = new Point(22, 803);
            this.label3.Name = "label3";
            this.label3.Size = new Size(108, 24);
            this.label3.TabIndex = 7;
            this.label3.Text = "EffectStats";
            // 
            // cbEffectStats
            // 
            this.cbEffectStats.FormattingEnabled = true;
            this.cbEffectStats.Items.AddRange(new object[] { "1", "2", "3", "4", "5" });
            this.cbEffectStats.Location = new Point(181, 802);
            this.cbEffectStats.Name = "cbEffectStats";
            this.cbEffectStats.Size = new Size(166, 25);
            this.cbEffectStats.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new Font("微軟正黑體", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 136);
            this.label4.Location = new Point(22, 860);
            this.label4.Name = "label4";
            this.label4.Size = new Size(152, 24);
            this.label4.TabIndex = 9;
            this.label4.Text = "EffectStatTypes";
            // 
            // cbEffectStatTypes
            // 
            this.cbEffectStatTypes.FormattingEnabled = true;
            this.cbEffectStatTypes.Items.AddRange(new object[] { "1", "2", "3", "4", "5" });
            this.cbEffectStatTypes.Location = new Point(181, 859);
            this.cbEffectStatTypes.Name = "cbEffectStatTypes";
            this.cbEffectStatTypes.Size = new Size(166, 25);
            this.cbEffectStatTypes.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new Font("微軟正黑體", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 136);
            this.label5.Location = new Point(22, 916);
            this.label5.Name = "label5";
            this.label5.Size = new Size(116, 24);
            this.label5.TabIndex = 11;
            this.label5.Text = "EffectTypes";
            // 
            // cbEffectTypes
            // 
            this.cbEffectTypes.FormattingEnabled = true;
            this.cbEffectTypes.Items.AddRange(new object[] { "1", "2", "3", "4", "5" });
            this.cbEffectTypes.Location = new Point(181, 915);
            this.cbEffectTypes.Name = "cbEffectTypes";
            this.cbEffectTypes.Size = new Size(166, 25);
            this.cbEffectTypes.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new SizeF(8F, 17F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(1862, 990);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbEffectTypes);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbEffectStatTypes);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbEffectStats);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbSkillTypes);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbLevels);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "MyKivotos";
            this.Load += this.Form1_Load;
            ((System.ComponentModel.ISupportInitialize)this.dataGridView1).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private ComboBox cbLevels;
        private Label label1;
        private Label label2;
        private ComboBox cbSkillTypes;
        private Button btnSearch;
        private Label label3;
        private ComboBox cbEffectStats;
        private Label label4;
        private ComboBox cbEffectStatTypes;
        private Label label5;
        private ComboBox cbEffectTypes;
    }
}
