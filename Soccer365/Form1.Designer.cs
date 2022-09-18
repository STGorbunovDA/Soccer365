namespace Soccer365
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_Soccer365 = new System.Windows.Forms.Button();
            this.cmB_years_game = new System.Windows.Forms.ComboBox();
            this.cmB_Percentage_draw = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmb_Occurs_more = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btn_Soccer365
            // 
            this.btn_Soccer365.Location = new System.Drawing.Point(-1, 12);
            this.btn_Soccer365.Name = "btn_Soccer365";
            this.btn_Soccer365.Size = new System.Drawing.Size(201, 87);
            this.btn_Soccer365.TabIndex = 0;
            this.btn_Soccer365.Text = "Парсить";
            this.btn_Soccer365.UseVisualStyleBackColor = true;
            this.btn_Soccer365.Click += new System.EventHandler(this.Btn_Soccer365_Click);
            // 
            // cmB_years_game
            // 
            this.cmB_years_game.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.cmB_years_game.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmB_years_game.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmB_years_game.FormattingEnabled = true;
            this.cmB_years_game.Items.AddRange(new object[] {
            "2021",
            "2020",
            "2019",
            "2018",
            "2017",
            "2016",
            "2015"});
            this.cmB_years_game.Location = new System.Drawing.Point(-1, 12);
            this.cmB_years_game.Name = "cmB_years_game";
            this.cmB_years_game.Size = new System.Drawing.Size(99, 21);
            this.cmB_years_game.TabIndex = 3;
            this.cmB_years_game.Visible = false;
            // 
            // cmB_Percentage_draw
            // 
            this.cmB_Percentage_draw.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.cmB_Percentage_draw.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmB_Percentage_draw.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmB_Percentage_draw.FormattingEnabled = true;
            this.cmB_Percentage_draw.Items.AddRange(new object[] {
            "69",
            "79",
            "89",
            "99"});
            this.cmB_Percentage_draw.Location = new System.Drawing.Point(206, 31);
            this.cmB_Percentage_draw.Name = "cmB_Percentage_draw";
            this.cmB_Percentage_draw.Size = new System.Drawing.Size(218, 21);
            this.cmB_Percentage_draw.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(206, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Процент не пройгрыша команд:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(206, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(219, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "В чемпионате не проигрывали более раз:";
            // 
            // cmb_Occurs_more
            // 
            this.cmb_Occurs_more.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.cmb_Occurs_more.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Occurs_more.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmb_Occurs_more.FormattingEnabled = true;
            this.cmb_Occurs_more.Items.AddRange(new object[] {
            "3",
            "4",
            "5",
            "6",
            "7"});
            this.cmb_Occurs_more.Location = new System.Drawing.Point(206, 78);
            this.cmb_Occurs_more.Name = "cmb_Occurs_more";
            this.cmb_Occurs_more.Size = new System.Drawing.Size(218, 21);
            this.cmb_Occurs_more.TabIndex = 12;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(436, 133);
            this.Controls.Add(this.cmb_Occurs_more);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmB_Percentage_draw);
            this.Controls.Add(this.btn_Soccer365);
            this.Controls.Add(this.cmB_years_game);
            this.Name = "Form1";
            this.Text = "Парсер";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Soccer365;
        private System.Windows.Forms.ComboBox cmB_years_game;
        private System.Windows.Forms.ComboBox cmB_Percentage_draw;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmb_Occurs_more;
    }
}

