namespace _19_06_2 {
    partial class Form1 {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent() {
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtSurname = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnShowNames = new System.Windows.Forms.Button();
            this.btnShowSurnames = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(15, 25);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(176, 20);
            this.txtName.TabIndex = 0;
            // 
            // txtSurname
            // 
            this.txtSurname.Location = new System.Drawing.Point(15, 64);
            this.txtSurname.Name = "txtSurname";
            this.txtSurname.Size = new System.Drawing.Size(176, 20);
            this.txtSurname.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Имя";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Фамилия";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(15, 90);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(176, 20);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Запомнить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnShowNames
            // 
            this.btnShowNames.Location = new System.Drawing.Point(15, 116);
            this.btnShowNames.Name = "btnShowNames";
            this.btnShowNames.Size = new System.Drawing.Size(176, 20);
            this.btnShowNames.TabIndex = 5;
            this.btnShowNames.Text = "Показать имена";
            this.btnShowNames.UseVisualStyleBackColor = true;
            this.btnShowNames.Click += new System.EventHandler(this.btnShowNames_Click);
            // 
            // btnShowSurnames
            // 
            this.btnShowSurnames.Location = new System.Drawing.Point(15, 142);
            this.btnShowSurnames.Name = "btnShowSurnames";
            this.btnShowSurnames.Size = new System.Drawing.Size(176, 20);
            this.btnShowSurnames.TabIndex = 6;
            this.btnShowSurnames.Text = "Показать фамилии";
            this.btnShowSurnames.UseVisualStyleBackColor = true;
            this.btnShowSurnames.Click += new System.EventHandler(this.btnShowSurnames_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(203, 177);
            this.Controls.Add(this.btnShowSurnames);
            this.Controls.Add(this.btnShowNames);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSurname);
            this.Controls.Add(this.txtName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtSurname;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnShowNames;
        private System.Windows.Forms.Button btnShowSurnames;
    }
}

