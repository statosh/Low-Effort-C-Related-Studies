using EmployeeManagementApp.Models;
using EmployeeManagementApp.Views;
using System.Collections.Generic;

namespace EmployeeManagementApp.Presenters {
    public class EmployeePresenter {
        private readonly IEmployeeView view;
        private readonly IEmployeeRepository repository;
        private bool isEditing = false;
        private Employee editingEmployee;

        public EmployeePresenter(IEmployeeView view, IEmployeeRepository repository) {
            this.view = view;
            this.repository = repository;

            this.view.AddEmployee += OnAddEmployee;
            this.view.EditEmployee += OnEditEmployee;
            this.view.DeleteEmployee += OnDeleteEmployee;
            this.view.SaveEmployee += OnSaveEmployee;
            this.view.CancelEdit += OnCancelEdit;
            this.view.SearchEmployees += OnSearchEmployees;
            this.view.EmployeeSelected += OnEmployeeSelected;

            LoadEmployees();
            view.SetFormMode(false);
        }

        private void LoadEmployees() {
            view.DisplayEmployees(repository.GetAll());
        }

        private void OnAddEmployee() {
            var employee = new Employee {
                FirstName = view.FirstName,
                LastName = view.LastName,
                Position = view.Position,
                Salary = view.Salary
            };
            repository.Add(employee);
            LoadEmployees();
            view.ClearInputs();
        }

        private void OnEditEmployee() {
            if (view.SelectedEmployee != null) {
                editingEmployee = view.SelectedEmployee;
                view.SetFormMode(true);
            }
        }

        private void OnDeleteEmployee() {
            if (view.SelectedEmployee != null) {
                repository.Delete(view.SelectedEmployee);
                LoadEmployees();
                view.ClearInputs();
            }
        }

        private void OnSaveEmployee() {
            if (editingEmployee != null) {
                editingEmployee.FirstName = view.FirstName;
                editingEmployee.LastName = view.LastName;
                editingEmployee.Position = view.Position;
                editingEmployee.Salary = view.Salary;
                repository.Update(editingEmployee);
                LoadEmployees();
                view.ClearInputs();
                view.SetFormMode(false);
                editingEmployee = null;
            }
        }

        private void OnCancelEdit() {
            view.ClearInputs();
            view.SetFormMode(false);
            editingEmployee = null;
        }

        private void OnSearchEmployees() {
            List<Employee> result = repository.Search(view.SearchQuery);
            view.DisplayEmployees(result);
        }

        private void OnEmployeeSelected() {
            if (view.SelectedEmployee != null) {
                var emp = view.SelectedEmployee;
                view.ClearInputs();
            }
        }
    }
}
