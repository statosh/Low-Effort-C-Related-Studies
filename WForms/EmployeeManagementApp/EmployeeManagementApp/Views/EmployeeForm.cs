using System;
using System.Collections.Generic;
using System.Windows.Forms;
using EmployeeManagementApp.Models;

namespace EmployeeManagementApp.Views {
    public partial class EmployeeForm : Form, IEmployeeView {
        public EmployeeForm() {
            InitializeComponent();
            btnAdd.Click += (s, e) => AddEmployee?.Invoke();
            btnEdit.Click += (s, e) => EditEmployee?.Invoke();
            btnDelete.Click += (s, e) => DeleteEmployee?.Invoke();
            btnSave.Click += (s, e) => SaveEmployee?.Invoke();
            btnCancel.Click += (s, e) => CancelEdit?.Invoke();
            btnSearch.Click += (s, e) => SearchEmployees?.Invoke();
            lstEmployees.SelectedIndexChanged += (s, e) => EmployeeSelected?.Invoke();
        }

        public void DisplayEmployees(List<Employee> employees) {
            lstEmployees.DataSource = null;
            lstEmployees.DataSource = employees;
        }

        public void ClearInputs() {
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtPosition.Text = "";
            txtSalary.Text = "";
        }

        public void SetFormMode(bool isEditMode) {
            btnAdd.Enabled = !isEditMode;
            btnEdit.Enabled = !isEditMode;
            btnDelete.Enabled = !isEditMode;
            btnSave.Enabled = isEditMode;
            btnCancel.Enabled = isEditMode;
        }

        public Employee SelectedEmployee => lstEmployees.SelectedItem as Employee;

        public string FirstName => txtFirstName.Text;
        public string LastName => txtLastName.Text;
        public string Position => txtPosition.Text;
        public decimal Salary => decimal.TryParse(txtSalary.Text, out var salary) ? salary : 0;
        public string SearchQuery => txtSearch.Text;

        public event Action AddEmployee;
        public event Action EditEmployee;
        public event Action DeleteEmployee;
        public event Action SaveEmployee;
        public event Action CancelEdit;
        public event Action SearchEmployees;
        public event Action EmployeeSelected;
    }
}
