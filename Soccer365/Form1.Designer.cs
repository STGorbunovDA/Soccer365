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
            this.cmB_name_game = new System.Windows.Forms.ComboBox();
            this.cmB_years_game_catch = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_Soccer365
            // 
            this.btn_Soccer365.Location = new System.Drawing.Point(166, 71);
            this.btn_Soccer365.Name = "btn_Soccer365";
            this.btn_Soccer365.Size = new System.Drawing.Size(201, 84);
            this.btn_Soccer365.TabIndex = 0;
            this.btn_Soccer365.Text = "Начать парсить";
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
            "2021/2022",
            "2020/2021",
            "2019/2020",
            "2018/2019",
            "2017/2018",
            "2016/2017",
            "2015/2016"});
            this.cmB_years_game.Location = new System.Drawing.Point(12, 24);
            this.cmB_years_game.Name = "cmB_years_game";
            this.cmB_years_game.Size = new System.Drawing.Size(122, 21);
            this.cmB_years_game.TabIndex = 3;
            // 
            // cmB_name_game
            // 
            this.cmB_name_game.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.cmB_name_game.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmB_name_game.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmB_name_game.FormattingEnabled = true;
            this.cmB_name_game.Items.AddRange(new object[] {
            "464",
            "12"});
            this.cmB_name_game.Location = new System.Drawing.Point(360, 24);
            this.cmB_name_game.Name = "cmB_name_game";
            this.cmB_name_game.Size = new System.Drawing.Size(122, 21);
            this.cmB_name_game.TabIndex = 4;
            // 
            // cmB_years_game_catch
            // 
            this.cmB_years_game_catch.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.cmB_years_game_catch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmB_years_game_catch.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmB_years_game_catch.FormattingEnabled = true;
            this.cmB_years_game_catch.Items.AddRange(new object[] {
            "2021",
            "2020",
            "2019",
            "2018",
            "2017",
            "2016",
            "2015"});
            this.cmB_years_game_catch.Location = new System.Drawing.Point(12, 60);
            this.cmB_years_game_catch.Name = "cmB_years_game_catch";
            this.cmB_years_game_catch.Size = new System.Drawing.Size(122, 21);
            this.cmB_years_game_catch.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(239, 209);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(128, 36);
            this.button1.TabIndex = 6;
            this.button1.Text = "2";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 209);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(104, 43);
            this.button2.TabIndex = 7;
            this.button2.Text = "Начать парсить";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(494, 256);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cmB_years_game_catch);
            this.Controls.Add(this.cmB_name_game);
            this.Controls.Add(this.cmB_years_game);
            this.Controls.Add(this.btn_Soccer365);
            this.Name = "Form1";
            this.Text = "Парсер";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Soccer365;
        private System.Windows.Forms.ComboBox cmB_years_game;
        private System.Windows.Forms.ComboBox cmB_name_game;
        private System.Windows.Forms.ComboBox cmB_years_game_catch;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

