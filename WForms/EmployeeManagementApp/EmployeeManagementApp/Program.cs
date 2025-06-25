using System;
using System.Windows.Forms;
using EmployeeManagementApp.Models;
using EmployeeManagementApp.Views;
using EmployeeManagementApp.Presenters;

namespace EmployeeManagementApp {
    static class Program {
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            IEmployeeRepository repository = new EmployeeRepository();
            EmployeeForm view = new EmployeeForm();
            _ = new EmployeePresenter(view, repository);

            Application.Run(view);
        }
    }
}
