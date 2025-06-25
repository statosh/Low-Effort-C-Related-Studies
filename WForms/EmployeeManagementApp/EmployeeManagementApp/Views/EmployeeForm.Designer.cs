namespace EmployeeManagementApp.Views {
    partial class EmployeeForm {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.ListBox lstEmployees;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.TextBox txtPosition;
        private System.Windows.Forms.TextBox txtSalary;
        private System.Windows.Forms.TextBox txtSearch;

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSearch;

        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.Label lblPosition;
        private System.Windows.Forms.Label lblSalary;
        private System.Windows.Forms.Label lblSearch;

        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent() {
            this.lstEmployees = new System.Windows.Forms.ListBox();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.txtPosition = new System.Windows.Forms.TextBox();
            this.txtSalary = new System.Windows.Forms.TextBox();
            this.txtSearch = new System.Windows.Forms.TextBox();

            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();

            this.lblFirstName = new System.Windows.Forms.Label();
            this.lblLastName = new System.Windows.Forms.Label();
            this.lblPosition = new System.Windows.Forms.Label();
            this.lblSalary = new System.Windows.Forms.Label();
            this.lblSearch = new System.Windows.Forms.Label();

            this.SuspendLayout();

            // 
            // lstEmployees
            // 
            this.lstEmployees.FormattingEnabled = true;
            this.lstEmployees.ItemHeight = 16;
            this.lstEmployees.Location = new System.Drawing.Point(12, 12);
            this.lstEmployees.Name = "lstEmployees";
            this.lstEmployees.Size = new System.Drawing.Size(300, 340);
            this.lstEmployees.TabIndex = 0;

            // 
            // lblFirstName
            // 
            this.lblFirstName.Location = new System.Drawing.Point(330, 12);
            this.lblFirstName.Size = new System.Drawing.Size(100, 20);
            this.lblFirstName.Text = "Имя:";

            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(430, 12);
            this.txtFirstName.Size = new System.Drawing.Size(200, 22);

            // 
            // lblLastName
            // 
            this.lblLastName.Location = new System.Drawing.Point(330, 50);
            this.lblLastName.Size = new System.Drawing.Size(100, 20);
            this.lblLastName.Text = "Фамилия:";

            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(430, 50);
            this.txtLastName.Size = new System.Drawing.Size(200, 22);

            // 
            // lblPosition
            // 
            this.lblPosition.Location = new System.Drawing.Point(330, 88);
            this.lblPosition.Size = new System.Drawing.Size(100, 20);
            this.lblPosition.Text = "Должность:";

            // 
            // txtPosition
            // 
            this.txtPosition.Location = new System.Drawing.Point(430, 88);
            this.txtPosition.Size = new System.Drawing.Size(200, 22);

            // 
            // lblSalary
            // 
            this.lblSalary.Location = new System.Drawing.Point(330, 126);
            this.lblSalary.Size = new System.Drawing.Size(100, 20);
            this.lblSalary.Text = "Зарплата:";

            // 
            // txtSalary
            // 
            this.txtSalary.Location = new System.Drawing.Point(430, 126);
            this.txtSalary.Size = new System.Drawing.Size(200, 22);

            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(330, 170);
            this.btnAdd.Size = new System.Drawing.Size(90, 30);
            this.btnAdd.Text = "Добавить";

            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(430, 170);
            this.btnEdit.Size = new System.Drawing.Size(90, 30);
            this.btnEdit.Text = "Редакт.";

            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(540, 170);
            this.btnDelete.Size = new System.Drawing.Size(90, 30);
            this.btnDelete.Text = "Удалить";

            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(330, 210);
            this.btnSave.Size = new System.Drawing.Size(150, 30);
            this.btnSave.Text = "Сохранить";

            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(480, 210);
            this.btnCancel.Size = new System.Drawing.Size(150, 30);
            this.btnCancel.Text = "Отмена";

            // 
            // lblSearch
            // 
            this.lblSearch.Location = new System.Drawing.Point(330, 260);
            this.lblSearch.Size = new System.Drawing.Size(100, 20);
            this.lblSearch.Text = "Поиск:";

            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(430, 260);
            this.txtSearch.Size = new System.Drawing.Size(200, 22);

            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(430, 290);
            this.btnSearch.Size = new System.Drawing.Size(200, 30);
            this.btnSearch.Text = "Найти";

            // 
            // EmployeeForm
            // 
            this.ClientSize = new System.Drawing.Size(660, 370);
            this.Controls.Add(this.lstEmployees);
            this.Controls.Add(this.lblFirstName);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.lblLastName);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.lblPosition);
            this.Controls.Add(this.txtPosition);
            this.Controls.Add(this.lblSalary);
            this.Controls.Add(this.txtSalary);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnSearch);
            this.Name = "EmployeeForm";
            this.Text = "Управление сотрудниками";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
