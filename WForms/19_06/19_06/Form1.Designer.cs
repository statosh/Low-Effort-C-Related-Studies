namespace _19_06 {
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
            this.numericLength = new System.Windows.Forms.NumericUpDown();
            this.numericLetters = new System.Windows.Forms.NumericUpDown();
            this.numericDigits = new System.Windows.Forms.NumericUpDown();
            this.numericSpecial = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.btnShowList = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtResult = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericLetters)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericDigits)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericSpecial)).BeginInit();
            this.SuspendLayout();
            // 
            // numericLength
            // 
            this.numericLength.Location = new System.Drawing.Point(15, 25);
            this.numericLength.Name = "numericLength";
            this.numericLength.Size = new System.Drawing.Size(120, 20);
            this.numericLength.TabIndex = 0;
            this.numericLength.ValueChanged += new System.EventHandler(this.numeric_ValueChanged);
            // 
            // numericLetters
            // 
            this.numericLetters.Location = new System.Drawing.Point(152, 25);
            this.numericLetters.Name = "numericLetters";
            this.numericLetters.Size = new System.Drawing.Size(120, 20);
            this.numericLetters.TabIndex = 1;
            this.numericLetters.ValueChanged += new System.EventHandler(this.numeric_ValueChanged);
            // 
            // numericDigits
            // 
            this.numericDigits.Location = new System.Drawing.Point(15, 67);
            this.numericDigits.Name = "numericDigits";
            this.numericDigits.Size = new System.Drawing.Size(120, 20);
            this.numericDigits.TabIndex = 2;
            this.numericDigits.ValueChanged += new System.EventHandler(this.numeric_ValueChanged);
            // 
            // numericSpecial
            // 
            this.numericSpecial.Location = new System.Drawing.Point(152, 67);
            this.numericSpecial.Name = "numericSpecial";
            this.numericSpecial.Size = new System.Drawing.Size(120, 20);
            this.numericSpecial.TabIndex = 3;
            this.numericSpecial.ValueChanged += new System.EventHandler(this.numeric_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Длина";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(149, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Кол-во. символов";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Кол-во. цифр";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(149, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Кол-во. спец. символов";
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(152, 93);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(120, 23);
            this.btnGenerate.TabIndex = 8;
            this.btnGenerate.Text = "Генерировать";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // btnShowList
            // 
            this.btnShowList.Location = new System.Drawing.Point(15, 93);
            this.btnShowList.Name = "btnShowList";
            this.btnShowList.Size = new System.Drawing.Size(120, 23);
            this.btnShowList.TabIndex = 9;
            this.btnShowList.Text = "Показать список";
            this.btnShowList.UseVisualStyleBackColor = true;
            this.btnShowList.Click += new System.EventHandler(this.btnShowList_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 128);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Вывод";
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(15, 144);
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(257, 20);
            this.txtResult.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(288, 179);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnShowList);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericSpecial);
            this.Controls.Add(this.numericDigits);
            this.Controls.Add(this.numericLetters);
            this.Controls.Add(this.numericLength);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.numericLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericLetters)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericDigits)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericSpecial)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numericLength;
        private System.Windows.Forms.NumericUpDown numericLetters;
        private System.Windows.Forms.NumericUpDown numericDigits;
        private System.Windows.Forms.NumericUpDown numericSpecial;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Button btnShowList;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtResult;
    }
}

