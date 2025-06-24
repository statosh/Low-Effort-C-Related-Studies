namespace _19_06 {
    partial class PasswordListForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.listBoxPasswords = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // listBoxPasswords
            // 
            this.listBoxPasswords.FormattingEnabled = true;
            this.listBoxPasswords.Location = new System.Drawing.Point(12, 12);
            this.listBoxPasswords.Name = "listBoxPasswords";
            this.listBoxPasswords.Size = new System.Drawing.Size(304, 238);
            this.listBoxPasswords.TabIndex = 0;
            // 
            // PasswordListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 262);
            this.Controls.Add(this.listBoxPasswords);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "PasswordListForm";
            this.Text = "PasswordListForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxPasswords;
    }
}