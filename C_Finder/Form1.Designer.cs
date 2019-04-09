namespace C_Finder
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
            this.el_b_start = new System.Windows.Forms.Button();
            this.el_tb_WordToFind = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // el_b_start
            // 
            this.el_b_start.Location = new System.Drawing.Point(12, 38);
            this.el_b_start.Name = "el_b_start";
            this.el_b_start.Size = new System.Drawing.Size(316, 49);
            this.el_b_start.TabIndex = 0;
            this.el_b_start.Text = "Start";
            this.el_b_start.UseVisualStyleBackColor = true;
            this.el_b_start.Click += new System.EventHandler(this.el_b_start_Click);
            // 
            // el_tb_WordToFind
            // 
            this.el_tb_WordToFind.Location = new System.Drawing.Point(13, 13);
            this.el_tb_WordToFind.Name = "el_tb_WordToFind";
            this.el_tb_WordToFind.Size = new System.Drawing.Size(315, 20);
            this.el_tb_WordToFind.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 99);
            this.Controls.Add(this.el_tb_WordToFind);
            this.Controls.Add(this.el_b_start);
            this.Name = "Form1";
            this.Text = "Finder";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button el_b_start;
        private System.Windows.Forms.TextBox el_tb_WordToFind;
    }
}

