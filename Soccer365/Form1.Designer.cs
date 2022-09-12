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
            this.SuspendLayout();
            // 
            // btn_Soccer365
            // 
            this.btn_Soccer365.Location = new System.Drawing.Point(141, 92);
            this.btn_Soccer365.Name = "btn_Soccer365";
            this.btn_Soccer365.Size = new System.Drawing.Size(201, 84);
            this.btn_Soccer365.TabIndex = 0;
            this.btn_Soccer365.Text = "Начать парсить";
            this.btn_Soccer365.UseVisualStyleBackColor = true;
            this.btn_Soccer365.Click += new System.EventHandler(this.btn_Soccer365_Click);
            // 
            // cmB_years_game
            // 
            this.cmB_years_game.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.cmB_years_game.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmB_years_game.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmB_years_game.FormattingEnabled = true;
            this.cmB_years_game.Items.AddRange(new object[] {
            "2022/2023",
            "2021/2022",
            "2020/2021",
            "2019/2020",
            "2018/2019",
            "2017/2018",
            "2016/2017",
            "2015/2016"});
            this.cmB_years_game.Location = new System.Drawing.Point(141, 65);
            this.cmB_years_game.Name = "cmB_years_game";
            this.cmB_years_game.Size = new System.Drawing.Size(201, 21);
            this.cmB_years_game.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(494, 256);
            this.Controls.Add(this.cmB_years_game);
            this.Controls.Add(this.btn_Soccer365);
            this.Name = "Form1";
            this.Text = "Парсер";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Soccer365;
        private System.Windows.Forms.ComboBox cmB_years_game;
    }
}

