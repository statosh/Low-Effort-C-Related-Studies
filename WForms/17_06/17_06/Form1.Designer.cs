namespace _17_06 {
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
            this.listBox_MainBox = new System.Windows.Forms.ListBox();
            this.button_RemoveElement = new System.Windows.Forms.Button();
            this.button_ClearListBox = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_InfoBox = new System.Windows.Forms.TextBox();
            this.textBox_AddElement = new System.Windows.Forms.TextBox();
            this.button_AddElement = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_LogBox = new System.Windows.Forms.TextBox();
            this.button_ClearLogs = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBox_MainBox
            // 
            this.listBox_MainBox.FormattingEnabled = true;
            this.listBox_MainBox.Location = new System.Drawing.Point(12, 12);
            this.listBox_MainBox.Name = "listBox_MainBox";
            this.listBox_MainBox.Size = new System.Drawing.Size(177, 277);
            this.listBox_MainBox.TabIndex = 0;
            this.listBox_MainBox.SelectedIndexChanged += new System.EventHandler(this.UpdateSelectedElementInfo);
            // 
            // button_RemoveElement
            // 
            this.button_RemoveElement.Location = new System.Drawing.Point(12, 296);
            this.button_RemoveElement.Name = "button_RemoveElement";
            this.button_RemoveElement.Size = new System.Drawing.Size(177, 23);
            this.button_RemoveElement.TabIndex = 1;
            this.button_RemoveElement.Text = "Удалить выбранный элемент";
            this.button_RemoveElement.UseVisualStyleBackColor = true;
            this.button_RemoveElement.Click += new System.EventHandler(this.button_RemoveElement_Click);
            // 
            // button_ClearListBox
            // 
            this.button_ClearListBox.Location = new System.Drawing.Point(12, 325);
            this.button_ClearListBox.Name = "button_ClearListBox";
            this.button_ClearListBox.Size = new System.Drawing.Size(177, 23);
            this.button_ClearListBox.TabIndex = 2;
            this.button_ClearListBox.Text = "Очистить весь список";
            this.button_ClearListBox.UseVisualStyleBackColor = true;
            this.button_ClearListBox.Click += new System.EventHandler(this.button_ClearListBox_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(196, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Информация о элементе";
            // 
            // textBox_InfoBox
            // 
            this.textBox_InfoBox.Location = new System.Drawing.Point(199, 28);
            this.textBox_InfoBox.Multiline = true;
            this.textBox_InfoBox.Name = "textBox_InfoBox";
            this.textBox_InfoBox.ReadOnly = true;
            this.textBox_InfoBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_InfoBox.Size = new System.Drawing.Size(237, 54);
            this.textBox_InfoBox.TabIndex = 4;
            this.textBox_InfoBox.Text = "Элемент не выбран";
            // 
            // textBox_AddElement
            // 
            this.textBox_AddElement.ForeColor = System.Drawing.Color.Gray;
            this.textBox_AddElement.Location = new System.Drawing.Point(199, 102);
            this.textBox_AddElement.Name = "textBox_AddElement";
            this.textBox_AddElement.Size = new System.Drawing.Size(237, 20);
            this.textBox_AddElement.TabIndex = 5;
            this.textBox_AddElement.Text = "Введите элемент для добавления";
            this.textBox_AddElement.TextChanged += new System.EventHandler(this.textBox_AddElement_TextChanged);
            this.textBox_AddElement.MouseEnter += new System.EventHandler(this.textBox_AddElement_MouseEnter);
            this.textBox_AddElement.MouseLeave += new System.EventHandler(this.textBox_AddElement_MouseLeave);
            // 
            // button_AddElement
            // 
            this.button_AddElement.Location = new System.Drawing.Point(344, 128);
            this.button_AddElement.Name = "button_AddElement";
            this.button_AddElement.Size = new System.Drawing.Size(92, 23);
            this.button_AddElement.TabIndex = 6;
            this.button_AddElement.Text = "Добавить";
            this.button_AddElement.UseVisualStyleBackColor = true;
            this.button_AddElement.Click += new System.EventHandler(this.button_AddElement_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(196, 154);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "События списка";
            // 
            // textBox_LogBox
            // 
            this.textBox_LogBox.Location = new System.Drawing.Point(199, 170);
            this.textBox_LogBox.Multiline = true;
            this.textBox_LogBox.Name = "textBox_LogBox";
            this.textBox_LogBox.ReadOnly = true;
            this.textBox_LogBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_LogBox.Size = new System.Drawing.Size(237, 149);
            this.textBox_LogBox.TabIndex = 8;
            // 
            // button_ClearLogs
            // 
            this.button_ClearLogs.Location = new System.Drawing.Point(316, 325);
            this.button_ClearLogs.Name = "button_ClearLogs";
            this.button_ClearLogs.Size = new System.Drawing.Size(120, 23);
            this.button_ClearLogs.TabIndex = 9;
            this.button_ClearLogs.Text = "Очистить историю";
            this.button_ClearLogs.UseVisualStyleBackColor = true;
            this.button_ClearLogs.Click += new System.EventHandler(this.button_ClearLogs_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 360);
            this.Controls.Add(this.button_ClearLogs);
            this.Controls.Add(this.textBox_LogBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button_AddElement);
            this.Controls.Add(this.textBox_AddElement);
            this.Controls.Add(this.textBox_InfoBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_ClearListBox);
            this.Controls.Add(this.button_RemoveElement);
            this.Controls.Add(this.listBox_MainBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox_MainBox;
        private System.Windows.Forms.Button button_RemoveElement;
        private System.Windows.Forms.Button button_ClearListBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_InfoBox;
        private System.Windows.Forms.TextBox textBox_AddElement;
        private System.Windows.Forms.Button button_AddElement;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_LogBox;
        private System.Windows.Forms.Button button_ClearLogs;
    }
}

