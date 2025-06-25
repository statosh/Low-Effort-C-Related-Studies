using System;
using System.Collections.Generic;
using EmployeeManagementApp.Models;

namespace EmployeeManagementApp.Views {
    public interface IEmployeeView {
        void DisplayEmployees(List<Employee> employees);
        void ClearInputs();
        void SetFormMode(bool isEditMode);

        Employee SelectedEmployee { get; }
        string FirstName { get; }
        string LastName { get; }
        string Position { get; }
        decimal Salary { get; }
        string SearchQuery { get; }

        event Action AddEmployee;
        event Action EditEmployee;
        event Action DeleteEmployee;
        event Action SaveEmployee;
        event Action CancelEdit;
        event Action SearchEmployees;
        event Action EmployeeSelected;
    }
}
