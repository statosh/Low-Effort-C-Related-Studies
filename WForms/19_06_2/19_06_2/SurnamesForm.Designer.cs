namespace _19_06_2 {
    partial class SurnamesForm {
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
            this.listBoxSurnames = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // listBoxSurnames
            // 
            this.listBoxSurnames.FormattingEnabled = true;
            this.listBoxSurnames.Location = new System.Drawing.Point(12, 12);
            this.listBoxSurnames.Name = "listBoxSurnames";
            this.listBoxSurnames.Size = new System.Drawing.Size(154, 225);
            this.listBoxSurnames.TabIndex = 0;
            // 
            // SurnamesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(178, 246);
            this.Controls.Add(this.listBoxSurnames);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "SurnamesForm";
            this.Text = "SurnamesForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxSurnames;
    }
}