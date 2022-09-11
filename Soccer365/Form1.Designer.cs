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
            this.lbl = new System.Windows.Forms.Label();
            this.lbl_Percent = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_Soccer365
            // 
            this.btn_Soccer365.Location = new System.Drawing.Point(273, 359);
            this.btn_Soccer365.Name = "btn_Soccer365";
            this.btn_Soccer365.Size = new System.Drawing.Size(111, 23);
            this.btn_Soccer365.TabIndex = 0;
            this.btn_Soccer365.Text = "Начать парсить";
            this.btn_Soccer365.UseVisualStyleBackColor = true;
            this.btn_Soccer365.Click += new System.EventHandler(this.btn_Soccer365_Click);
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl.Location = new System.Drawing.Point(12, 64);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(77, 20);
            this.lbl.TabIndex = 1;
            this.lbl.Text = "Команда";
            // 
            // lbl_Percent
            // 
            this.lbl_Percent.AutoSize = true;
            this.lbl_Percent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_Percent.Location = new System.Drawing.Point(95, 64);
            this.lbl_Percent.Name = "lbl_Percent";
            this.lbl_Percent.Size = new System.Drawing.Size(126, 20);
            this.lbl_Percent.TabIndex = 2;
            this.lbl_Percent.Text = "Процент побед";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(667, 450);
            this.Controls.Add(this.lbl_Percent);
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.btn_Soccer365);
            this.Name = "Form1";
            this.Text = "Парсер";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Soccer365;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.Label lbl_Percent;
    }
}

