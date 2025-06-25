using System.Collections.Generic;
using System.Linq;

namespace EmployeeManagementApp.Models {
    public class EmployeeRepository : IEmployeeRepository {
        private List<Employee> employees = new List<Employee>();
        private int nextId = 1;

        public List<Employee> GetAll() {
            return new List<Employee>(employees);
        }

        public void Add(Employee employee) {
            employee.Id = nextId++;
            employees.Add(employee);
        }

        public void Update(Employee employee) {
            var existing = employees.FirstOrDefault(e => e.Id == employee.Id);
            if (existing != null) {
                existing.FirstName = employee.FirstName;
                existing.LastName = employee.LastName;
                existing.Position = employee.Position;
                existing.Salary = employee.Salary;
            }
        }

        public void Delete(Employee employee) {
            employees.RemoveAll(e => e.Id == employee.Id);
        }

        public List<Employee> Search(string query) {
            return employees
                .Where(e => $"{e.FirstName} {e.LastName}".ToLower().Contains(query.ToLower())
                         || e.Position.ToLower().Contains(query.ToLower()))
                .ToList();
        }
    }
}
